using System.Text.Json.Serialization;

namespace CarRegistrationsAPI.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public DateTime Year_of_foundation { get; set; }
        [JsonIgnore]
        public List<Car> Cars { get; set; }
    }
}
