using System;

namespace BlazorComponent.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int? TemperatureC { get; set; }

        public int TemperatureF => TemperatureC == null ? 0 : 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
