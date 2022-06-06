namespace web_crawler;

public class WebsiteService : IWebsiteService
{
  private static Dictionary<string, string> pageHtml = new Dictionary<string, string>
  {
    {"url1", "page1Html"},
    {"url2", "page2Html"},
    {"url3", "page3Html"},
    {"url4", "page4Html"},
    {"url5", "page5Html"},
    {"url6", "page6Html"},
    {"url7", "page7Html"},
  };

  private static Dictionary<string, string[]> pageUrls = new Dictionary<string, string[]>
  {
    {"page1Html", new [] {"url2", "url3", "url5"}},
    {"page2Html", new [] {"url3", "url6"}},
    {"page3Html", new [] {"url1", "url2"}},
    {"page4Html", new [] {"url5", "url6"}},
    {"page5Html", new [] {"url4", "url7"}},
    {"page6Html", new string[0] },
    {"page7Html", new [] {"url2", "url1"}},
  };

  public string HomePageUrl()
  {
    return pageHtml.First().Key;
  }

  public string GetHtmlContent(string url)
  {
    if (pageHtml.TryGetValue(url, out var html)) return html;

    throw new ArgumentException("URL does not exist.");
  }

  public string[] GetLinksOnPage(string html)
  {
    if (pageUrls.TryGetValue(html, out var urls)) return urls;

    return Array.Empty<string>();
  }
}
