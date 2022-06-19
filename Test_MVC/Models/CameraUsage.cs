namespace Test_MVC.Models
{
    public class CameraUsage
    {
        public int Id { get; set; }
        public virtual Camera Camera { get; set; }
        public virtual CameraOperator CameraOperator { get; set; }
    }
}
