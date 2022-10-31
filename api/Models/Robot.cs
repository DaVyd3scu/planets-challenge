using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Robot
    {
        [Key]
        [Column("id")]
        public int RobotId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        // Foreign keys
        [JsonIgnore]
        public virtual int? CaptainId { get; set; }

        // Navigation properties
        public virtual Captain? Captain { get; set; }

        [JsonIgnore]
        public virtual List<Visit>? Visits { get; set; }
    }
}
