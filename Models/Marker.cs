using System;
using System.ComponentModel.DataAnnotations;

namespace PollutionApi.Models
{
    public class Marker
    {
        [Key]
        public DateTime PollutionDate { get; set; }
        public string AddressName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public float NO2Mean { get; set; }
        public int NO2MaxValue { get; set; }
        public int NO2MaxHour { get; set; }
        public int NO2AQI { get; set; }
        public float O3Mean { get; set; }
        public int O3MaxValue { get; set; }
        public int O3MaxHour { get; set; }
        public int O3AQI { get; set; }
        public float SO2Mean { get; set; }
        public int SO2MaxValue { get; set; }
        public int SO2MaxHour { get; set; }
        public int SO2AQI { get; set; }
        public float COMean { get; set; }
        public int COMaxValue { get; set; }
        public int COMaxHour { get; set; }
        public int COAQI { get; set; }
    }
}