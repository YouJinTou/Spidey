namespace Spidey.SDK.Land
{
    public class SearchSetting
    {
        public SearchSetting(Area area, Region region, Land land)
        {
            this.Area = area;
            this.Region = region;
            this.Land = land;
        }

        public Area Area { get; set; }

        public Region Region { get; set; }

        public Land Land { get; set; }
    }
}
