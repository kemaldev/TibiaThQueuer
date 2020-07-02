using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class TibiaThContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<TibiaCharacter> TibiaCharacter { get; set; }
        public DbSet<CharacterList> CharacterList { get; set; }
        public DbSet<CharacterListRelation> CharacterListRelation { get; set; }

        public TibiaThContext(DbContextOptions<TibiaThContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TibiaThContext).Assembly);
        }
    }
}
