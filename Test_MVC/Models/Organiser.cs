namespace Test_MVC.Models
{
    public enum Sector
    {
        Social_media,
        Administration,
        Founder
    }

    public class Organiser : Person
    {
        public Sector WorkSector { get; set; }

    }
}
