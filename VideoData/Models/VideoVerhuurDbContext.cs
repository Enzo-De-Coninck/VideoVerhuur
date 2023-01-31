using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoData.Models
{
    public class VideoVerhuurDbContext : DbContext
    {
        public VideoVerhuurDbContext() { }
        public VideoVerhuurDbContext(DbContextOptions options) : base(options) { }



        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Verhuring> Verhuringen { get; set; }
        public DbSet<Klant> Klanten { get; set; }

    }
}
