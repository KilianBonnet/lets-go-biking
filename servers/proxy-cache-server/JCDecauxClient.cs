using System;
using System.Net.Http;
using System.Threading.Tasks;

class JCDecauxClient
{
    // Singleton design pattern
    public static JCDecauxClient Istance = new JCDecauxClient();

    // Client configuration
    private readonly HttpClient client = new HttpClient();
    private const string BASE_URL = "https://api.jcdecaux.com/vls/v1/";

    // Contract configuration
    private readonly TimeSpan contractRequestFrequency = new TimeSpan(0, 5, 0); // 5 minutes
    private DateTime contratsLastRequest;
    private string contractsJson = "";

    private JCDecauxClient(){}

    public async Task<string> getContractsAsync()
    {
        if (ContractsOutOfDate())
            contractsJson = await RequestContractsAsync();
        return contractsJson;
    }

    private bool ContractsOutOfDate()
    {
        return contractsJson == "" || (DateTime.Now - contratsLastRequest > contractRequestFrequency);
    }

    private async Task<string> RequestContractsAsync()
    {
        contratsLastRequest = DateTime.Now;

        string requestedURL = BASE_URL + "contracts?apiKey=" + Config.JC_DECAUX_API_KEY;
        HttpResponseMessage response = await client.GetAsync(requestedURL);
        return await response.Content.ReadAsStringAsync();
    }
}

