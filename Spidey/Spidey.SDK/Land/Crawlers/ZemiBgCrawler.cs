using Spidey.SDK.Land.Parsers;
using Spidey.SDK.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spidey.SDK.Land.Crawlers
{
    public class ZemiBgCrawler : Crawler
    {
        private const string Endpoint = "http://www.zemi.bg/adv-search.php?Areas={0}&Regions={1}&Lands={2}&aIDorderby=aFromDate&aIDdirection=desc&aIDpage=1";

        private IEnumerable<SearchSetting> searchSettings;

        public ZemiBgCrawler(
            IPageReader reader, IParser parser, IEnumerable<SearchSetting> searchSettings)
            : base(reader, parser)
        {
            this.searchSettings = searchSettings ?? 
                throw new ArgumentException(nameof(searchSettings));
        }

        public override async Task<IEnumerable<Ad>> GetAdsAsync()
        {
            var ads = new List<Ad>();

            foreach (var setting in this.searchSettings)
            {
                var formattedEndpoint = string.Format(
                    Endpoint, (int)setting.Area, (int)setting.Region, (int)setting.Land);
                var html = await this.reader.DownloadStringAsync(formattedEndpoint);

                ads.AddRange(this.parser.ParseContent(html));
            }

            return ads;
        }
    }
}
