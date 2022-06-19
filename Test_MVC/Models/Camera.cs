using System.ComponentModel.DataAnnotations;

namespace Test_MVC.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Company { get; set; }

        /// <summary>
        /// Camera model is optional
        /// </summary>
        public string? Model { get; set; }
        public virtual ICollection<CameraUsage> CameraUsages { get; set; }

    }
}