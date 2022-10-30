using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        // Navigation properties
        public List<Robot>? Robots { get; set; }
        public List<Planet>? Planets { get; set; }
    }
}
