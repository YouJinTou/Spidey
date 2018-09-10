using Spidey.SDK.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spidey.SDK.Land.Crawlers
{
    public abstract class Crawler
    {
        protected IPageReader reader;

        public Crawler(IPageReader reader)
        {
            this.reader = reader;
        }

        public abstract Task<IEnumerable<Ad>> GetAdsAsync();
    }
}
