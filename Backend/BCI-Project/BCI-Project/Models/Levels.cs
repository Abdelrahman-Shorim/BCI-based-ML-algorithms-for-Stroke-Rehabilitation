namespace BCI_Project.Models
{
    public class Levels : BaseModel
    {
        public string LevelName { get; set; }
        public string Description { get; set; }

        //public ICollection<GameLog> GameLogPatients { get; set; }
        public ICollection<Game> GameLevels { get; set; }


    }
}
