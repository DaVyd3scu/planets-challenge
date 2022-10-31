namespace api.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int RobotId { get; set; }

        public virtual Robot Robot { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
