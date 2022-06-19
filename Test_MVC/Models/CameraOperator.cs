namespace Test_MVC.Models
{
    public class CameraOperator : Operator
    {
        public int Id { get; set; }
        public virtual ICollection<CameraUsage> CameraUsages { get; set; }
    }
}
