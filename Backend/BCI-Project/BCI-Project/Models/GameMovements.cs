namespace BCI_Project.Models
{
    public class GameMovements : BaseModel
    {
        public Guid GameLogId { get; set; }
        public string RequiredMovement { get; set; }
        public string ActualMovement { get; set; }
        public string BrainSignals { get; set; }

        public GameLog GameLog { get; set; }
    }
}
