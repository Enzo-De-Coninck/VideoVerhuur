using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoData.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreNaam { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
