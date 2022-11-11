using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class JCDecauxClient
{
    // Singleton design pattern
    public static JCDecauxClient Istance = new JCDecauxClient();

    // Client configuration
    private readonly HttpClient client = new HttpClient();
    private const string BASE_URL = "https://api.jcdecaux.com/vls/v1/";

    private JCDecauxClient(){}

    public async Task<string> RequestContractsAsync()
    {
        Thread.Sleep(2000); // For pedagogic purpose, will simulate a long server response time
        string requestedURL = BASE_URL + "contracts?apiKey=" + Config.JC_DECAUX_API_KEY;
        HttpResponseMessage response = await client.GetAsync(requestedURL);
        if(response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        return null;
    }

    public async Task<string> RequestStationsAsync(string contractName)
    {
        Thread.Sleep(2000); // For pedagogic purpose, will simulate a long server response time
        string requestedURL = BASE_URL + "stations?contract=" + contractName + "&apiKey=" + Config.JC_DECAUX_API_KEY;
        HttpResponseMessage response = await client.GetAsync(requestedURL);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        return null;
    }

    public async Task<string> RequestStationInfoAsync(string contractName, int stationNumber)
    {
        Thread.Sleep(2000); // For pedagogic purpose, will simulate a long server response time
        string requestedURL = BASE_URL + "stations/" + stationNumber + "?contract=" + contractName + "&apiKey=" + Config.JC_DECAUX_API_KEY;
        HttpResponseMessage response = await client.GetAsync(requestedURL);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        return null;
    }
}

