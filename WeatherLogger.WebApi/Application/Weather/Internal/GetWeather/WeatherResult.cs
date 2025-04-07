namespace WeatherLogger.WebApi.Application.Weather.Internal.GetWeather
{
    public class WeatherResult
    {
        public string Name { get; set; } 
        public SysData Sys { get; set; }
        public MainData Main { get; set; }

        // Dodatkowe wygodne property (opcjonalnie)
        public string City => Name;
        public string Country => Sys?.Country;
        public float Temperature => Main?.Temp ?? 0;

        public class SysData
        {
            public string Country { get; set; }
        }

        public class MainData
        {
            public float Temp { get; set; }
        }
    }


}
