using System;
using System.Collections.Generic;
using PrimeraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimeraAPI.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
        }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Member> Members { get; set; }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MusicDbConnection");
    }

}