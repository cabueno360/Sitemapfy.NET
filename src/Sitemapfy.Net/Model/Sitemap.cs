using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sitemapfy.Net
{
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public record struct Sitemap
    {
        [XmlElement("url")]
        public List<SitemapLocation> Locations { get; init; } = new List<SitemapLocation>();

        public Sitemap(IEnumerable<SitemapLocation> locations)
        {
            Locations = new List<SitemapLocation>(locations);
        }

        public static readonly Sitemap None = new Sitemap(new List<SitemapLocation>());

        public static Sitemap Create(IEnumerable<SitemapLocation> locations) => 
            new(locations ?? new List<SitemapLocation>());
        
    }
}
