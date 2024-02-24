namespace BCI_Project.ViewModels
{
    public class SignalsAdaptaionVM
    {
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Decimal> FeatureArray { get; set; }
    }
}
