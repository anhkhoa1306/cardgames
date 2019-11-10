using System;
using System.Collections.Concurrent;
using CardGames.Application.Interfaces.Infrastructure.GameManagement;
using CardGames.Application.Interfaces.Infrastructure.GameManagement.Models;
using CardGames.Domain.Entities;

namespace CardGames.Infrastructure.GameManagement
{
    public class GameCreationService : IGameCreationService
    {
        private ConcurrentDictionary<string, GameModel> _game;

        public GameCreationService()
        {
            _game = new ConcurrentDictionary<string, GameModel>();
        }
        public string CreateNewGame(string playerId, string title)
        {
            var game = new Game
            {
                CreatedById = playerId,
                CreatedDate = DateTime.Now,
                Title = title,
            };

            return game.Id.ToString();
        }
    }
}
