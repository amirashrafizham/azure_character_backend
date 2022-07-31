using System;
using character_api.Models;
using Microsoft.EntityFrameworkCore;

namespace character_api.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("CharacterConnection"));
        }

        public DbSet<Character> Characters { get; set; }

    }
}
