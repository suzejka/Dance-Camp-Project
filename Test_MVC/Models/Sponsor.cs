namespace Test_MVC.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SponsorOpenEvent> SponsorOpenEvents { get; set; }

        /* public Sponsor(string name, List<string> contactDetails)
         {
             Name = name;
             ContactDetails = contactDetails;
         }

         public void AddOpenEvent(Open_Event open_Event, float amountReceivedFromSponsors)
         {
             new SponsorOpenEvent(this, open_Event, amountReceivedFromSponsors);

         }
         public void AddSponsorOpenEvent(SponsorOpenEvent sponsorOpenEvent)
         {
             if (!SponsorOpenEvents.Contains(sponsorOpenEvent))
             {
                 SponsorOpenEvents.Add(sponsorOpenEvent);
             }
         }

         public void ShowOpenEvents()
         {
             foreach (SponsorOpenEvent soe in SponsorOpenEvents)
             {
                 Console.WriteLine(soe.OpenEvent.ToString() + " kwota: " + soe.AmountReceivedFromSponsors);
             }
         }

         public override string ToString()
         {
             return "Sponsor - " + Name;
         }*/
    }
}
