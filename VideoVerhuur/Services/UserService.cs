using VideoData.Models;

namespace VideoVerhuur.Services
{
    public class UserService : IUserService
    {
        private readonly VideoVerhuurDbContext _context;
        private readonly List<Film> Winkelmandje;
        private Klant? _user;

        public UserService(VideoVerhuurDbContext context)
        {
            _context= context;
            Winkelmandje = new();
        }


        public List<Film> GetMandje()
        {
            return Winkelmandje;
        }

        public decimal GetTotaal()
        {
            decimal totaal = 0m;
            Winkelmandje.ForEach(f => totaal += f.Prijs);
            return totaal;
        }

        public Klant? GetUser()
        {
            return _user;
        }

        public void HuurFilm(Film film)
        {
            if (!Winkelmandje.Contains(film))
                Winkelmandje.Add(film);
        }

        public bool IsAangemeld()
        {
            if (_user == null)
                return false;
            return true;
        }

        public Klant? TryLogin(string Naam, string postcode)
        {
            return _user = _context.Klanten.FirstOrDefault(klant => klant.Naam == Naam && klant.PostCode == postcode);
        }

        public void Uitloggen()
        {
            _user = null;
        }

        public void VerwijderFilm(int id)
        {
            Winkelmandje.Remove(Winkelmandje.First(film => film.FilmId == id));
        }
    }
}
