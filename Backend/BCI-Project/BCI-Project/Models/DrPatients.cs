namespace BCI_Project.Models
{
    public class DrPatients : BaseModel
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }

        public User Patient { get; set; }
        public User Doctor { get; set; }


    }
}
