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

        var request = new RestRequest($"{BASE_URL}/getentries", Method.Get);
        request.AddQueryParameter("token", _token!.Value);
        var response = await _client.ExecuteAsync<CloudEntryInformation[]>(request);
        return response.Data;
    }

    private async Task<bool> CheckCredentials()
    {
        //First load credentials from memory
        var credentialsIncorrect = false;
        var username = Settings.Default.Username;
        var password = Settings.Default.Password;

        //If server cannot be reached, the credential check has failed
        if (!await PingServer()) return false;

        //If credentials are not set or invalid, 
        while (username is null || password is null || (_token = await Login(username, password)) is null)
        {
            if (!LoginDialog.OpenWindow(credentialsIncorrect, out username, out password, out var register))
            {
                _token = null;
                return false;
            }

            //Try to register new user
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
        try
        {

            var requestUri = new RestRequest($"{BASE_URL}/user");
            requestUri.AddQueryParameter("username", username);
            requestUri.AddQueryParameter("password", password);

            var response = await _client.ExecuteGetAsync<int>(requestUri);
            return response.IsSuccessful ? response.Data : null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private async Task<bool> RegisterNewUser(string username, string password)
    {
        try
        {

            var requestUri = new RestRequest($"{BASE_URL}/user");
            requestUri.AddParameter("username", username);
            requestUri.AddParameter("password", password);

            return (await _client.PostAsync(requestUri)).IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> PingServer() => (await _client.GetAsync(new RestRequest(BASE_URL + "/ping"))).IsSuccessStatusCode;
}
