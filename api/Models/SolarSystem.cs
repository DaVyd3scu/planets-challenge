using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class SolarSystem
    {
        [Key]
        [Column("id")]
        public int SolarSystemId { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual List<Planet>? Planets { get; set; }
    }
}
