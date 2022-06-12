namespace web_crawler;

public class BreadthFirstWebCrawler
{
  private readonly IWebsiteService websiteService;

  public BreadthFirstWebCrawler(IWebsiteService websiteService)
  {
    this.websiteService = websiteService;
  }

  public IEnumerable<string> Crawl()
  {
    var homeUrl = websiteService.HomePageUrl();
    var visitedUrls = new HashSet<string>();
    var visitedUrlsInOrder = new List<string>();
    visitedUrls.Add(homeUrl);
    visitedUrlsInOrder.Add(homeUrl);

    var urlQueue = new Queue<string>();
    urlQueue.Enqueue(homeUrl);

    while (urlQueue.TryDequeue(out var url))
    {
      var pageHtml = websiteService.GetHtmlContent(url);
      var pageUrls = websiteService.GetLinksOnPage(pageHtml);

      foreach (var pageUrl in pageUrls)
      {
        if (visitedUrls.Contains(pageUrl)) continue;

        visitedUrls.Add(pageUrl);
        visitedUrlsInOrder.Add(pageUrl);
        urlQueue.Enqueue(pageUrl);
      }
    }

    return visitedUrlsInOrder;
  }
}
