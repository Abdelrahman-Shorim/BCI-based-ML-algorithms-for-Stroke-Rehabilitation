namespace BCI_Project.Models
{
    public class Comments : BaseModel
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }



        public User Patient { get; set; }
        public User Doctor { get; set; }
    }
}
