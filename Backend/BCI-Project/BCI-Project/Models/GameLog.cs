namespace BCI_Project.Models
{
    public class GameLog : BaseModel
    {
        public string PatientId { get; set; }
        public Guid LevelId { get; set; }
        public string Score { get; set; }
        public string Duration { get; set; }
        public string Accuracy { get; set; }
        public DateTime Date { get; set; }



        public User Patient { get; set; }
        public Levels Level { get; set; }

        public ICollection<GameMovements> GameMovementsGameLogs { get; set; }

    }
}
