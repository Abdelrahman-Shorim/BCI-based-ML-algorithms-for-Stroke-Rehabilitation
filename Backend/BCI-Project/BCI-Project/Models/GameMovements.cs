namespace BCI_Project.Models
{
    public class GameMovements : BaseModel
    {
        public Guid GameId { get; set; }
        public string RequiredMovement { get; set; }
        public string ActualMovement { get; set; }
        public string BrainSignals { get; set; }

        public Game Game { get; set; }
    }
}
