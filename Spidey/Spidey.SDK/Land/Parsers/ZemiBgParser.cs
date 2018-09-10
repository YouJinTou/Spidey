using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Spidey.SDK.Land.Parsers
{
    public class ZemiBgParser : IParser
    {
        public IEnumerable<Ad> ParseContent(string content)
        {
            try
            {
                var doc = new HtmlDocument();

                doc.LoadHtml(content);

                var adRows = doc.DocumentNode.SelectNodes("//tr[starts-with(@id, 'aIDtr')]");
                var ads = new List<Ad>();

                foreach (var row in adRows)
                {
                    try
                    {
                        var adCells = row.SelectNodes("//td[starts-with(@id, 'aIDtd')]");
                        var date = adCells[1].InnerText;
                        var area = adCells[2].InnerText;
                        var region = adCells[3].InnerText;
                        var land = adCells[4].InnerText;
                        var surfaceArea = adCells[5].InnerText;
                        var category = adCells[6].InnerText;
                        var type = adCells[7].InnerText;
                        var price = adCells[8].InnerText;
                        var ad = new Ad
                        {
                            Location = $"{area}, {region}, {land}",
                            Area = double.TryParse(surfaceArea, out double parsedArea) ?
                                parsedArea :
                                (double?)null,
                            ContactName = string.Empty,
                            ContactPhone = string.Empty,
                            DatePublished = date,
                            Description = string.Empty,
                            Price = decimal.TryParse(price, out decimal parsedPrice) ?
                                parsedPrice :
                                (decimal?)null
                        };

                        ads.Add(ad);
                    }
                    catch
                    {
                    }
                }

                return ads;
            }
            catch
            {
                throw new Exception("Could not parse HTML from zemi.bg.");
            }
        }
    }
}
