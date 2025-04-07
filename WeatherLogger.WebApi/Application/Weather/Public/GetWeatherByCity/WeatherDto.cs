namespace WeatherLogger.WebApi.Application.Weather.Public.GetWeatherData
{
    public class WeatherDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public float Temperature { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
