﻿using System.Text.Json.Serialization;

namespace CarRegistrationsAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public string License_plate { get; set; }
        public DateTime First_reg_date { get; set; }
        public int Power_kW { get; set; }
        public string Body_type { get; set; }
        public string Color { get; set; }
        [JsonIgnore]
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}
