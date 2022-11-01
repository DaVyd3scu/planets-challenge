using System.ComponentModel.DataAnnotations;

namespace api.Models.ActionModels
{
    public class UpdatePlanet : Planet
    {
        [Required]
        public override string? Status { get => base.Status; set => base.Status = value; }
    }
}
