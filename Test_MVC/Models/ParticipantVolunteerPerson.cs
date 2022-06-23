namespace Test_MVC.Models
{
    public enum PersonType { Participant, Volunteer }
    public class ParticipantVolunteerPerson : Person
    {
        #region Participant properties

        public int? DormitoryNumber { get; set; }
        public int? RoomNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }

        #endregion

        #region Volunteer properties

        public double? AmountOfHoursWorked { get; set; }

        #endregion

        /// <summary>
        /// Overlapping - Participant and Volunteer
        /// </summary>
        public List<PersonType> personTypes = new();

        /// <summary>
        /// Person takes part in many events 
        /// </summary>
        public virtual ICollection<Event>? Events { get; set; }

    }
}
