using CardGames.Domain.Entities;

namespace CardGames.Application.Interfaces.Infrastructure.GameManagement
{
    public interface IGameCreationService
    {
        string CreateNewGame(string playerId, string title);
    }
}