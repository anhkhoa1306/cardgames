﻿using CardGames.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardGames.Persistent.Contexts
{
    public class CardGameDbContext : IdentityDbContext<Player>
    {
        public CardGameDbContext(DbContextOptions<CardGameDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
