using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Planet
    {
        [Key]
        [Column("id")]
        public int PlanetId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        [Required]
        [Comment("Can only have the following values: OK, !OK, TODO, En Route")]
        public string Status { get; set; }

        // Foreign keys
        [JsonIgnore]
        public virtual int? CaptainId { get; set; }
        [JsonIgnore]
        public virtual int? SolarSystemId { get; set; }

        // Navigation properties
        public virtual Captain? Captain { get; set; }

        public virtual SolarSystem? SolarSystem { get; set; }

        [JsonIgnore]
        public virtual List<Visit>? Visits { get; set; }
    }
}
