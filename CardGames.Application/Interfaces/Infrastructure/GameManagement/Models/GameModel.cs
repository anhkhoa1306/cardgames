using System;
using System.Collections.Generic;
using CardGames.Domain.Entities;

namespace CardGames.Application.Interfaces.Infrastructure.GameManagement.Models
{
    public class GameModel
    {
        public string GameId { get; set; }
        public string GameTitle { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public List<Card> Cards { get; set; }
        public List<Player> Players { get; set; }

        public GameModel()
        {
            Cards = new List<Card>();
            Players = new List<Player>();
        }
    }
}
