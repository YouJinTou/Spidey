using Spidey.SDK.Land;
using Spidey.SDK.Land.Crawlers;
using Spidey.SDK.Land.Parsers;
using Spidey.SDK.Web;
using System;
using System.Collections.Generic;

namespace Spidey.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new List<SearchSetting>
            {
                new SearchSetting(Area.Dobrich, Region.Dobrich, Land.Lomnitsa)
            };
            var crawler = new ZemiBgCrawler(new PageReader(), new ZemiBgParser(), settings);
            var ads = crawler.GetAdsAsync().Result;
        }
    }
}
