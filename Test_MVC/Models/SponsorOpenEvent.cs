using Test_MVC.Data;

namespace Test_MVC.Models
{
    public class SponsorOpenEvent
    {
        public int Id { get; set; }
        public float AmountReceivedFromSponsors { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        public virtual Open_Event OpenEvent { get; set; }
        
    }
}
