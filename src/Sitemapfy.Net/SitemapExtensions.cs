using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Functional.DotNet;
using Microsoft.Extensions.DependencyInjection;

namespace Sitemapfy.Net
{
    public static class SitemapExtensions
    {
        public static string ToXml(this Sitemap sitemap)
        {
            var xmlSerializer = new XmlSerializer(typeof(Sitemap));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = false
            };

            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                xmlSerializer.Serialize(xmlWriter, sitemap);
                return stringWriter.ToString();
            }
        }

        public static Stream ToXmlStream(this Sitemap sitemap)
        {
            var xmlSerializer = new XmlSerializer(typeof(Sitemap));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = false
            };

            var memoryStream = new MemoryStream();
            using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                xmlSerializer.Serialize(xmlWriter, sitemap);
            }

            // Reset the position of the MemoryStream to the beginning.
            memoryStream.Position = 0;
            return memoryStream;
        }

        public static void AddSitemap<TService>(this IServiceCollection services) where TService : class, ISiteMapService
        {
            services.AddScoped<ISiteMapService, TService>();
        }

        public static RouteHandlerBuilder MapSitemap(this IEndpointRouteBuilder endpoints, string path = "sitemap.xml")
        {
            return endpoints.MapGet(path, async (ISiteMapService siteMapService) =>
            {
                var outcome = await siteMapService.GenerateLocationsAsync().Map(
                                    Completed: CreateSiteMapFile,
                                    Faulted: (_) => Results.Problem());
                return outcome;
            });
        }

        public static IResult CreateSiteMapFile(Sitemap sitemap) => Results.File(sitemap.ToXmlStream(), "application/xml");

        public static RouteHandlerBuilder WithSitemap(this RouteHandlerBuilder endpoint,
          string name, object? defaults = null)
            {
                return endpoint
                    .WithName(name);
            }

        public interface ISiteMapService
        {
            Task<Sitemap> GenerateLocationsAsync();
        }
    }
}
