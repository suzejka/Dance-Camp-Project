using static Test_MVC.Models.Event;

namespace Test_MVC.Models
{
    public class Trainer : Person
    {
        /// <summary>
        /// List of assigned tranings (max. 3)
        /// </summary>
        public virtual ICollection<Training> Trainings { get; set; }

        /// <summary>
        /// Trainer is able to perform in multiple shows
        /// </summary>
        public virtual ICollection<Show> Shows { get; set; }
        
        public static int MaximumNumberOfClasses = 3;

        /// <summary>
        /// Checks if the amount of assigned training is above the limit
        /// </summary>
        /// <returns>False or True</returns>
        public bool CanTrainingBeAssigned()
        {
            if (Trainings == null)
            {
                return true;
            }
            return Trainings.Count < MaximumNumberOfClasses;
        }
        
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
