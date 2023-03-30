﻿using Footballers.Data.Models;

namespace Footballers.Data
{
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamFootballer>()
                .HasKey(k => new { k.TeamId, k.FootballerId });
        }

        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<Footballer> Footballers { get; set; } = null!;

        public DbSet<Coach> Coaches { get; set; } = null!;

        public DbSet<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
