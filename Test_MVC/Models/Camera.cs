using System.ComponentModel.DataAnnotations;

namespace Test_MVC.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string? Model { get; set; }
        public virtual ICollection<CameraUsage> CameraUsages { get; set; }

    }
}