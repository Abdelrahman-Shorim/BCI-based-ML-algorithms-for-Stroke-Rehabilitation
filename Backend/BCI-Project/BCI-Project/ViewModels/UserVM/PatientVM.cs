namespace BCI_Project.ViewModels.UserVM
{
    public class PatientVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string AssignedDrName { get; set; }
        public string AssignedDrId { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> PatientAttributes { get; set; }
    }
}
