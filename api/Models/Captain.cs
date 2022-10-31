using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Captain
    {
        [Key]
        [Column("id")]
        public int CaptainId { get; set; }

        public virtual string? FirstName { get; set; }

        public virtual string? LastName { get; set; }

        [JsonIgnore]
        public virtual string? Username { get; set; }

        [JsonIgnore]
        public virtual string? Password { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual List<Robot>? Robots { get; set; }

        [JsonIgnore]
        public virtual List<Planet>? Planets { get; set; }
    }
}
