using System;
using System.Linq;
using CardGames.Domain.Entities;
using CardGames.Persistent.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CardGames.Persistent.Seeding
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<CardGameDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Player>>();

            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                var player = new Player
                {
                    UserName = "AnhKhoa",
                    Email = "khoa.do@cardgames.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = userManager.CreateAsync(player, "Password@123").Result;
            }
        }
    }
}
