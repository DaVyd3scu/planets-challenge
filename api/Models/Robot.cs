using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public int? CaptainId { get; set; }

        // Navigation properties
        public Captain? Captain { get; set; }
        public List<Visit>? Visits { get; set; }
    }
}
