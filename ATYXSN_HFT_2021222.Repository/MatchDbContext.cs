using System;
using ATYXSN_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;

namespace ATYXSN_HFT_2021222.Repository
{
    public class MatchDbContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bookmaker> Bookmakers { get; set; }
        public DbSet<Bettor> Bettors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\match.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }


    }
}
