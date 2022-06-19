using Test_MVC.Data;

namespace Test_MVC.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SponsorOpenEvent> SponsorOpenEvents { get; set; }

        public Sponsor()
        {
            SponsorOpenEvents = new HashSet<SponsorOpenEvent>();
        }
    }
}
