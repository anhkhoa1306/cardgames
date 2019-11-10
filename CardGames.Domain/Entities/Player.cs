using Microsoft.AspNetCore.Identity;

namespace CardGames.Domain.Entities
{
    public class Player : IdentityUser
    {
        public long Cash { get; set; }
    }
}
