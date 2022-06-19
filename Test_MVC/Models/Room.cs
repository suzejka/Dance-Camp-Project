namespace Test_MVC.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        /// <summary>
        /// Many trainings take place in the room
        /// </summary>
        public virtual ICollection<Training> Trainings { get; set; }

        public override string ToString()
        {
            return Name + " " + Area;
        }
    }
}
