using Spidey.SDK.Land.Parsers;
using Spidey.SDK.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spidey.SDK.Land.Crawlers
{
    public abstract class Crawler
    {
        protected IPageReader reader;
        protected IParser parser;

        public Crawler(IPageReader reader, IParser parser)
        {
            this.reader = reader ?? throw new ArgumentException(nameof(reader));
            this.parser = parser ?? throw new ArgumentException(nameof(parser));
        }

        public abstract Task<IEnumerable<Ad>> GetAdsAsync();
    }
}
