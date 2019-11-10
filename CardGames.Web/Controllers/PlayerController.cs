using System.Linq;
using CardGames.Persistent.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardGames.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private CardGameDbContext _cardGameDbContext;

        public PlayerController(CardGameDbContext cardGameDbContext)
        {
            _cardGameDbContext = cardGameDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _cardGameDbContext.Users.Select(u => u.UserName).ToList();
            return Ok(result);
        }
    }
}
