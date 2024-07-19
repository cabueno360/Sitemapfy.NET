using System.Xml.Serialization;

public record struct SitemapLocation
{
    [XmlElement("loc")]
    public string Url { get; init; }

    [XmlElement("lastmod")]
    public DateTime LastModified { get; init; }


    public SitemapLocation(string url, DateTime lastModified)
    {
        Url = url;
        LastModified = lastModified;
    }

    public static readonly SitemapLocation None = 
        new(string.Empty, DateTime.MinValue);

    public static SitemapLocation Create(string url, DateTime lastModified) =>
        new(
            url: string.IsNullOrWhiteSpace(url) ? string.Empty : url,
            lastModified: lastModified == default ? DateTime.UtcNow : lastModified
           );

}