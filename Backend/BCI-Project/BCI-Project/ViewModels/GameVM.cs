namespace BCI_Project.ViewModels
{
    public class GameVM
    {
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public Guid GameTypeId { get; set; }
        public string Score { get; set; }
        public string Duration { get; set; }
        public string Accuracy { get; set; }
        public DateTime Date { get; set; }
    }
}
