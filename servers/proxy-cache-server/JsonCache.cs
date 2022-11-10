using System;
using System.Diagnostics.Contracts;
using System.Net;

class JsonCache {
    public DateTime lastModified;
    public TimeSpan lifeSpan;
    private RequestResult requestResult;

    public JsonCache(RequestResult requestResult, TimeSpan lifeSpan)
    {
        this.requestResult = requestResult;
        this.lifeSpan = lifeSpan;
        lastModified = DateTime.Now;
    }

    public JsonCache(TimeSpan lifeSpan)
    {
        requestResult = new RequestResult(
            HttpStatusCode.BadRequest,
            "{error}: \"Bad request proxy side\""
        );
        this.lifeSpan = lifeSpan;
    }

    public void Update(RequestResult requestResult)
    {
        this.requestResult = requestResult;
        lastModified = DateTime.Now;
    }

    public RequestResult RequestResult()
    {
        return requestResult;
    }

    public bool IsOutOfDate()
    {
        return requestResult.httpStatusCode != HttpStatusCode.OK ||(DateTime.Now - lastModified > lifeSpan);
    }
}

