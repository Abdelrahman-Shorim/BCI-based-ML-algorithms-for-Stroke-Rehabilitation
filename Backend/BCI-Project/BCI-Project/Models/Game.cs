﻿namespace BCI_Project.Models
{
    public class Game : BaseModel
    {
        public string PatientId { get; set; }
        public Guid GameTypeId { get; set; }
        public string Score { get; set; }
        public string Duration { get; set; }
        public string Accuracy { get; set; }
        public DateTime Date { get; set; }



        public User Patient { get; set; }
        public GameType GameType { get; set; }

        public ICollection<GameMovements> GameMovementsGames { get; set; }

    }
}
