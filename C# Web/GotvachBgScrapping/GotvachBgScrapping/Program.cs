using AngleSharp.Dom;
using AngleSharp;

namespace GotvachBgScrapping
{
    public class Program
    {
        public static async Task Main()
        {
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);

            var document = await context.OpenAsync("https://recepti.gotvach.bg/r-160281");

            var elements = document.QuerySelectorAll(".products > ul > li");

            foreach (var item in elements)
            {
                Console.WriteLine(item.TextContent);
            }
        }
    }
}