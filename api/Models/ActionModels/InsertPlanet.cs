using System.ComponentModel.DataAnnotations;

namespace api.Models.ActionModels
{
    public class InsertPlanet : Planet
    {
        [Required]
        public override string? Name { get => base.Name; set => base.Name = value; }

        [Required]
        public override int? SolarSystemId { get => base.SolarSystemId; set => base.SolarSystemId = value; }
    }
}
