namespace web_crawler;

public interface IWebsiteService
{
  string HomePageUrl();
  string GetHtmlContent(string url);
  string[] GetLinksOnPage(string html);
}
