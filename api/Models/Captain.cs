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

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [JsonIgnore]
        public string Username { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual List<Robot>? Robots { get; set; }

        [JsonIgnore]
        public virtual List<Planet>? Planets { get; set; }
    }
}
