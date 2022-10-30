using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        public int? CaptainId { get; set; }

        // Navigation properties
        public Captain? Captain { get; set; }
        public List<Visit>? Visits { get; set; }
    }
}
