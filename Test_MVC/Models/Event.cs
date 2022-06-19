namespace Test_MVC.Models
{
    public enum Status_Name
    {
        Scheduled,
        Cancelled,
        Completed
    }

    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status_Name Status { get; set; }
        public List<Show> Shows = new();
        public virtual ICollection<Person> Participants { get; set; }


        public void Cancel()
        {
            this.Status = Status_Name.Cancelled;
        }

        public void End()
        {
            this.Status = Status_Name.Completed;
        }


        public class Show
        {
            public int Id { get; set; }
            public double Duration { get; set; }
            public virtual ICollection<Trainer> Trainers { get; set; }
        }
    }
}
