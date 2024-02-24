namespace BCI_Project.ViewModels
{
    public class CommentVM
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }

    }
}
