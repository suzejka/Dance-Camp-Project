namespace Test_MVC.Models
{
    public class Training : Event
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual Room Room { get; set; }


        public override string ToString()
        {
            return StartDate + " " + EndDate;
        }
    }
}
