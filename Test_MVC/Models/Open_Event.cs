namespace Test_MVC.Models
{
    public class Open_Event : Event
    {
        public string StreetAddress { get; set; }
        public int MaxAmountOfPeople { get; set; }
        public virtual ICollection<SponsorOpenEvent> SponsorOpenEvents { get; set; }

        public Open_Event()
        {
            SponsorOpenEvents = new HashSet<SponsorOpenEvent>();
        }
    }
}
