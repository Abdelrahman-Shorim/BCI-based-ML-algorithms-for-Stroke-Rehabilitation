namespace BCI_Project.Models
{
    public class GameType : BaseModel
    {
        public string GameTypeName { get; set; }
        public string Description { get; set; }

        //public ICollection<GameLog> GameLogPatients { get; set; }
        public ICollection<Game> GameTypes { get; set; }


    }
}
