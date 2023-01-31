using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoData.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Titel { get; set; }
        public int GenreId { get; set; }
        public int InVoorraad { get; set; }
        public int UitVoorraad { get; set; }
        public decimal Prijs { get; set; }
        public int TotaalVerhuurd { get; set; }
        public Genre Genre { get; set; } = null!;
        public IEnumerable<Verhuring> Verhuringen { get; set; } = null!;
    }
}
