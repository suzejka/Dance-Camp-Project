using System.Data;
using System.Data.SqlClient;

namespace Test_MVC.Models
{
    public enum PersonType {Participant, Volunteer}
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactDetails { get; set; }

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
        public List<PersonType>? personTypes = new();

        /// <summary>
        /// Person takes part in many events 
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }

    }
}
