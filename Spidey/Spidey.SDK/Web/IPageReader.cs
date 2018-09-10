using System.Threading.Tasks;

namespace Spidey.SDK.Web
{
    public interface IPageReader
    {
        Task<string> DownloadStringAsync(string url);
    }
}
