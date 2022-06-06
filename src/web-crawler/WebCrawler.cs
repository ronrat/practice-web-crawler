namespace web_crawler;

public class WebPageLinks
{
  public string Url { get; set; }
  public List<WebPageLinks> LinkedPages { get; set; }

  public WebPageLinks(string url)
  {
    Url = url;
    LinkedPages = new List<WebPageLinks>();
  }
}

public class WebCrawler
{
  private readonly IWebsiteService websiteService;

  public WebCrawler(IWebsiteService websiteService)
  {
    this.websiteService = websiteService;
  }

  public IEnumerable<string> Crawl()
  {
    var url = websiteService.HomePageUrl();
    var visitedUrls = new HashSet<string>();
    var visitedUrlsInOrder = new List<string>();
    visitedUrls.Add(url);
    visitedUrlsInOrder.Add(url);

    CrawlUrl(url, visitedUrls, visitedUrlsInOrder);

    return visitedUrlsInOrder;
  }

  public void CrawlUrl(string url, HashSet<string> visitedUrls, List<string> visitedUrlsInOrder)
  {
    var pageHtml = websiteService.GetHtmlContent(url);
    var pageUrls = websiteService.GetLinksOnPage(pageHtml);

    foreach (var linkedUrl in pageUrls)
    {
      if (visitedUrls.Contains(linkedUrl)) continue;

      visitedUrls.Add(linkedUrl);
      visitedUrlsInOrder.Add(linkedUrl);
      CrawlUrl(linkedUrl, visitedUrls, visitedUrlsInOrder);
    }
  }
}
