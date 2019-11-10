using CardGames.Application.Persistent;
using CardGames.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CardGames.Persistent.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private IdentityDbContext IdentityDbContext => Context as IdentityDbContext;
        public GameRepository(IdentityDbContext context) : base(context)
        {
        }
    }
}
