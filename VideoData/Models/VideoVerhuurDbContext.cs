using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoData.Models
{
    public class VideoVerhuurDbContext : DbContext
    {
        const string Server = @".\SQLEXPRESS";
        const string DatabaseNaam = "VideoVerhuur";
        public static IConfigurationRoot configuration = null!;
        public DbSet<Film> Films { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Klant> Klanten { get; set; } = null!;
        public DbSet<Verhuring> Verhuringen { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server={Server};Database={DatabaseNaam};Trusted_Connection=true;encrypt=false",
                options => options.MaxBatchSize(150)); // Max aantal SQL commands die kunnen doorgestuurd worden naar de database }
        }


    }
}
