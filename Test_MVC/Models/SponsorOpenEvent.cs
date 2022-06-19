namespace Test_MVC.Models
{
    public class SponsorOpenEvent
    {
        public int Id { get; set; }
        public float AmountReceivedFromSponsors { get; private set; }
        public virtual Sponsor Sponsor { get; private set; }
        public virtual Open_Event OpenEvent { get; private set; }
        

       /* public SponsorOpenEvent(Sponsor sponsor, Open_Event openEvent, float amountReceivedFromSponsors)
        {
            Sponsor = sponsor;
            OpenEvent = openEvent;
            AmountReceivedFromSponsors = amountReceivedFromSponsors;
            
            sponsor.AddSponsorOpenEvent(this);
            openEvent.AddSponsorOpenEvent(this);
        }

        public override string ToString()
        {
            return "Sponsor: " + Sponsor.Name + " \nWydarzenie: " + OpenEvent.Name + " \nKwota: " + AmountReceivedFromSponsors;
        }

      */  
    }
}
