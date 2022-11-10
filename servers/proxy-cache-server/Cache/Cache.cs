using System;

class Cache
{
    public TimeSpan lifeSpan;
    public DateTime lastUpdate;
    public string cachedJson;

    public Cache(TimeSpan lifeSpan)
    {
        this.lifeSpan = lifeSpan;
        lastUpdate = DateTime.MinValue;
        cachedJson = "{\"Error\":\"Bad Request\"}";
    }

    public bool IsOutdated()
    {
        return DateTime.Now - lastUpdate > lifeSpan;
    }
}
