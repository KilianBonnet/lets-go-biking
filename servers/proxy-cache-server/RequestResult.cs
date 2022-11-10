using System.Net;

class RequestResult
{
    public HttpStatusCode httpStatusCode;
    public string json;

    public RequestResult(HttpStatusCode httpStatusCode, string json)
    {
        this.httpStatusCode = httpStatusCode;
        this.json = json;
    }
}

