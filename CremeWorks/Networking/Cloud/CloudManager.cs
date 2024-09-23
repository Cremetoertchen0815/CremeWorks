using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Cloud;
using CremeWorks.App.Properties;
using RestSharp;

namespace CremeWorks.App.Networking.Cloud;
public class CloudManager(IDataParent parent)
{
    private int? _token = null;
    private readonly IDataParent _parent = parent;
    private readonly RestClient _client = new();

    private const string BASE_URL = "https://cremetoertchen.com/api/cremeworks";

    public async Task<CloudEntryInformation[]?> GetAllDatabases()
    {
        if (!await CheckCredentials()) return null;

        var request = new RestRequest($"{BASE_URL}/allentries", Method.Get);
        request.AddQueryParameter("token", _token!.Value);
        var response = await _client.ExecuteAsync<CloudEntryInformation[]>(request);
        return response.Data;
    }

    public async Task SyncProgress(Database db, string rawXml, bool save)
    {
        //Don't do anything if the database is not synced to the cloud
        if (db.CloudId is null) return;

        //Make sure the user has a valid session
        if (!await CheckCredentials()) return;

        //Fetch the "last saved" value
        var request = new RestRequest($"{BASE_URL}/entryinfo", Method.Get);
        request.AddQueryParameter("token", _token!.Value);
        var response = await _client.ExecuteAsync<CloudEntryInformation>(request);
        if (!response.IsSuccessful || response.Data is null) return;

        //Check if the data has stayed the same
        var newHash = rawXml.GetHashCode();
        if (newHash == response.Data.Hash) return;

        //Data has changed, so check which version to keep
        var decision = OverrideDecision.DoNothing;

        //Choose what syncing action to take
        if (save)
        {
            if (response.Data.LastTimeUpdated == db.LastServerSync)
            {
                //The cloud version and the local version are based on the same data
                //So we can just save the new data
                decision = OverrideDecision.OverrideWithLocal;
            } else
            {
                var result = MessageBox.Show("There is a conflict between your current version and the one in the cloud.\n"+
                    "Would you like to forcefully update the version in the cloud? Data loss may occur!\n" +
                    "(Yes = Force cloud update, No = Force loading from cloud, Cancel = Don't synchronize)",
                    "Conflict", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                decision = result switch
                {
                    DialogResult.Yes => OverrideDecision.OverrideWithLocal,
                    DialogResult.No => OverrideDecision.ForceFetch,
                    _ => OverrideDecision.DoNothing
                };
            }
        }
        else
        {
            //Loading a local database
            if (db.LastLocalSave > response.Data.LastTimeUpdated)
            {
                var result = MessageBox.Show("The local database is more recent than the cloud copy. " +
                                             "Would you like to update the cloud with this newer version?",
                                             "Cloud database out of date", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                decision = result switch
                {
                    DialogResult.Yes => OverrideDecision.OverrideWithLocal,
                    _ => OverrideDecision.DoNothing
                };
            }
            else
            {
                var result = MessageBox.Show("There is a more recent version available in the cloud. " +
                                             "Would you like to load the newest version?",
                                             "Local database out of date", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                decision = result switch
                {
                    DialogResult.Yes => OverrideDecision.ForceFetch,
                    _ => OverrideDecision.DoNothing
                };
            }
        }

        //Act on override decision
        switch (decision)
        {
            case OverrideDecision.OverrideWithLocal:
                //Update the last saved value
                db.LastServerSync = db.LastLocalSave;

                request = new RestRequest($"{BASE_URL}/entry", Method.Post);
                request.AddParameter("token", _token!.Value);
                request.AddParameter("id", db.CloudId!.Value);
                request.AddParameter("synctime", db.LastLocalSave.Ticks);
                request.AddBody(rawXml);
                await _client.ExecuteAsync(request);
                break;
            case OverrideDecision.ForceFetch:
                break;
            default:
                return;
        }

        //TODO: Implement seperate transfer format that doesn't contain meta data(-> hash actually signifies data change)
    }

    private async Task<bool> CheckCredentials()
    {

        //If server cannot be reached, the credential check has failed
        if (!await PingServer())
        {
            _token = null;
            return false;
        }

        //If we already have a token, make sure it still is valid
        if (_token is not null && await ValidateToken()) return true;
        _token = null;

        //Try to fetch new token
        //First load credentials from memory
        var credentialsIncorrect = false;
        var username = Settings.Default.Username;
        var password = Settings.Default.Password;

        //If credentials are not set or invalid, open window to reenter
        while (username is null || password is null || (_token = await Login(username, password)) is null)
        {
            if (!LoginDialog.OpenWindow(credentialsIncorrect, out username, out password, out var register))
            {
                _token = null;
                return false;
            }
            credentialsIncorrect = true; //Next time, show the "credentials incorrect" label

            //Try to register new user, if user selected that
            if (register && !await RegisterNewUser(username, password)) return false;
        }

        //Store the settings
        Settings.Default.Username = username;
        Settings.Default.Password = password;
        Settings.Default.Save();

        return true;
    }

    private async Task<int?> Login(string username, string password)
    {
        var requestUri = new RestRequest($"{BASE_URL}/user", Method.Get);
        requestUri.AddQueryParameter("username", username);
        requestUri.AddQueryParameter("password", password);

        var response = await _client.ExecuteAsync<int>(requestUri);
        return response.IsSuccessful ? response.Data : null;
    }

    private async Task<bool> RegisterNewUser(string username, string password)
    {
        var requestUri = new RestRequest($"{BASE_URL}/user", Method.Post);
        requestUri.AddParameter("username", username);
        requestUri.AddParameter("password", password);

        return (await _client.ExecuteAsync(requestUri)).IsSuccessStatusCode;
    }

    private async Task<bool> PingServer() => (await _client.ExecuteAsync(new RestRequest(BASE_URL + "/ping"), Method.Get)).IsSuccessful;
    private async Task<bool> ValidateToken()
    {
        if (_token is null) return false;
        var request = new RestRequest(BASE_URL + "/ping", Method.Get);
        request.AddParameter("token", _token.Value);
        return (await _client.ExecuteAsync(request)).IsSuccessful;
    }
}
