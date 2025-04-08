# 🌦️ Weather Logger 

A weather data logging system that fetches weather information for selected cities using the OpenWeather API and displays temperature trends using charts. The backend is built with ASP.NET Core and the frontend with React + TypeScript + Chart.js.

![obraz](https://github.com/user-attachments/assets/153c10d0-255c-4325-863c-2c3da5baff4b)


---

## 🔧 Requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/en)
- OpenWeather API Key → [https://openweathermap.org/](https://openweathermap.org/)

---

## 🚀 Backend – ASP.NET Core Web API

### 1. Provide your API key in `appsettings.json`

In `WeatherLogger.WebApi/appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "OpenWeatherApiKey": "YOUR_API_KEY",
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WeatherDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "WeatherSettings": {
    "Locations": [
      {
        "City": "London",
        "Country": "UK"
      },
      {
        "City": "Manchester",
        "Country": "UK"
      },
      {
        "City": "Berlin",
        "Country": "Germany"
      },
      {
        "City": "Munich",
        "Country": "Germany"
      },
      {
        "City": "Paris",
        "Country": "France"
      },
      {
        "City": "Lyon",
        "Country": "France"
      }
    ]
  }
}
```

## To Run the tests 

```C#
 public WeatherApiServiceTests()
 {
     var httpClient = new HttpClient();

     var config = new ConfigurationBuilder()
         .AddInMemoryCollection(new Dictionary<string, string>
         {
             { "OpenWeatherApiKey", "YOUR_REAL_API_KEY" } 
         })
         .Build();

     _service = new WeatherApiService(httpClient, config);
 }

```

#UI

## Create a .env.local file and provide the backend API base URL:

```text

REACT_APP_API_BASE_URL=https://localhost:7069/api

```

## Install dependencies and start the development server

```bash
npm install
npm start

```

### The app will be available at http://localhost:3000

## To run frontend tests:

```bash

npm test


```





