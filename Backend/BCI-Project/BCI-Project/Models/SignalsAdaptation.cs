namespace BCI_Project.Models
{
    public class SignalsAdaptation : BaseModel
    {
        public string PatientId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Decimal> FeatureArray { get; set; }


        public User Patient { get; set; }
    }
}
