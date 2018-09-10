using System.Collections.Generic;

namespace Spidey.SDK.Land.Parsers
{
    public interface IParser
    {
        IEnumerable<Ad> ParseContent(string content);
    }
}
