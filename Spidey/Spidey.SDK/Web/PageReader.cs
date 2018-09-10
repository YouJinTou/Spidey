using System;
using System.Net;
using System.Threading.Tasks;

namespace Spidey.SDK.Web
{
    public class PageReader : IPageReader
    {
        public async Task<string> DownloadStringAsync(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    return await client.DownloadStringTaskAsync(new Uri(url));
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
