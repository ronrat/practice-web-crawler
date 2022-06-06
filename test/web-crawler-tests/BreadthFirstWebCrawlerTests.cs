using web_crawler;
using FluentAssertions;

namespace web_crawler_tests;

public class BreadthFirstWebCrawlerTests
{
  [Fact]
  public void ShouldReturnExpectedVisitedUrls()
  {
    var expectedUrls = new[] { "url1", "url2", "url3", "url5", "url6", "url4", "url7", };

    var crawledUrls = new BreadthFirstWebCrawler(new WebsiteService()).Crawl();

    crawledUrls.Should().Equal(expectedUrls);
  }
}
