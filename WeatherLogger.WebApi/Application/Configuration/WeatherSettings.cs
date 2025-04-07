namespace WeatherLogger.WebApi.Application.Configuration
{
    public class WeatherSettings
    {
        public List<Location> Locations { get; set; } = new();

        public class Location
        {
            public string City { get; set; }
            public string Country { get; set; }
        }
    }
}
