using static Test_MVC.Models.Event;

namespace Test_MVC.Models
{
    public class Trainer : Person
    {
        public static readonly int MaximumNumberOfClasses = 3;

        /// <summary>
        /// List of assigned tranings (max. 3)
        /// </summary>
        public virtual List<Training> Trainings { get; set; }

        /// <summary>
        /// Trainer is able to perform in multiple shows, also none of them
        /// </summary>
        public virtual ICollection<Show>? Shows { get; set; }

        /// <summary>
        /// Counts all assigned trainings
        /// </summary>
        /// <returns>Number of assigned trainings</returns>
        public int NumberOfClassess()
        {
            return Trainings.Count;
        }
        /// <summary>
        /// Checks if the amount of assigned training is above the limit
        /// </summary>
        /// <returns>False or True</returns>
        public bool CanTrainingBeAdded()
        {
            if (NumberOfClassess() > MaximumNumberOfClasses)
            {
                return false;
            } 

            return true;
        }
    }
}
