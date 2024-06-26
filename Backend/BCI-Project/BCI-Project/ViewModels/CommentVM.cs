namespace BCI_Project.ViewModels
{
    public class CommentVM
    {
        public Guid Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }

    }
}
