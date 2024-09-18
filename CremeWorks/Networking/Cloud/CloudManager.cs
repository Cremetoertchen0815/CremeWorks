using CremeWorks.App.Data;
using CremeWorks.App.Dialogs.Cloud;
using CremeWorks.App.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

    public async Task SyncProgress(Database db, string rawXml)
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

        //TODO: Create algorithm to decide what version to override

        //Act on override decision
        switch (decision)
        {
            case OverrideDecision.OverrideWithLocal:
                break;
            case OverrideDecision.ForceFetch:
                break;
            default:
                return;
        }
    }

    private OverrideDecision AskUserForDecision()
    {
        var result = MessageBox.Show("There is a conflict between your current version and the one in the cloud. " +
            "Would you like to keep the local version?\n(Yes = Local version, No = Server version , Cancel = Do nothing",
            "Conflict", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

        return result switch
        {
            DialogResult.Yes => OverrideDecision.OverrideWithLocal,
            DialogResult.No => OverrideDecision.ForceFetch,
            _ => OverrideDecision.DoNothing
        };
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
