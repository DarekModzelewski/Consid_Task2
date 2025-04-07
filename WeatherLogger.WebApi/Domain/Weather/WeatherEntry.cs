namespace WeatherLogger.WebApi.Domain.Weather
{
    public class WeatherEntry
    {
        public int Id { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public float Temperature { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        private WeatherEntry(string city, string country, float temperature, DateTime updatedAt)
        {
            City = city;
            Country = country;
            Temperature = temperature;
            UpdatedAt = updatedAt;
        }


        private WeatherEntry() { } // optional parameterless constructor for EF 

        public static WeatherEntry Create(string city, string country, float temperature, DateTime updatedAt)
        {
            return new WeatherEntry(city, country, temperature, updatedAt);
        }

    }
}
