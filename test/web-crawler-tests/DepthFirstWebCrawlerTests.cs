using web_crawler;
using FluentAssertions;

namespace web_crawler_tests;

public class DepthFirstWebCrawlerTests
{
  [Fact]
  public void ShouldReturnExpectedVisitedUrls()
  {
    var expectedUrls = new[] { "url1", "url2", "url3", "url6", "url5", "url4", "url7", };

    var crawledUrls = new DepthFirstWebCrawler(new WebsiteService()).Crawl();

    crawledUrls.Should().Equal(expectedUrls);
  }
}
