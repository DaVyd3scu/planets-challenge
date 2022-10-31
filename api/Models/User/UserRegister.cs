using System.ComponentModel.DataAnnotations;

namespace api.Models.User
{
    public class UserRegister : Captain
    {
        [Required]
        public override string? FirstName
        {
            get { return base.FirstName; }
            set { base.FirstName = value; }
        }

        [Required]
        public override string? LastName
        {
            get { return base.LastName; }
            set { base.LastName = value; }
        }

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
