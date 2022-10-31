using System.ComponentModel.DataAnnotations;

namespace api.Models.User
{
    public class UserLogin : Captain
    {
        [Required]
        public override string? Username 
        { 
            get { return base.Username; } 
            set { base.Username = value; }
        }

        [Required]
        public override string? Password 
        {
            get { return base.Password; }
            set { base.Password = value; } 
        }
    }
}
