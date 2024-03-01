namespace BCI_Project.Models
{
    public class DrPatients : BaseModel
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }

        public User Patient { get; set; }
        public User Doctor { get; set; }


    }
}
