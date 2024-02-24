namespace BCI_Project.ViewModels
{
    public class GameMovementVM
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string RequiredMovement { get; set; }
        public string ActualMovement { get; set; }
        public string BrainSignals { get; set; }
    }
}
