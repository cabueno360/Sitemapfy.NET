
namespace Sitemapfy.Net.Test
{
    public class SitemapExtensionsTests
    {
        [Fact]
        public void ToXml_ShouldReturnCorrectXml()
        {
            // Arrange
            var locations = new List<SitemapLocation>
        {
            SitemapLocation.Create("http://example.com/product1", DateTime.UtcNow),
            SitemapLocation.Create("http://example.com/product2", DateTime.UtcNow.AddDays(-1))
        };

            var sitemap = Sitemap.Create(locations);

            // Act
            var xml = sitemap.ToXml();

            // Assert
            Assert.NotNull(xml);
            Assert.Contains("<loc>http://example.com/product1</loc>", xml);
            Assert.Contains("<loc>http://example.com/product2</loc>", xml);
        }
    }
}