using VideoData.Models;

namespace VideoVerhuur.Services
{
    public interface IUserService
    {
        public void HuurFilm(Film film);
        public List<Film> GetMandje();
        public Decimal GetTotaal();
        public void VerwijderFilm(int id);
        public Klant? GetUser();
        public Klant? TryLogin(string Naam, string postcode);
        public bool IsAangemeld();
        public void Uitloggen();
        public void WinkelmandjeLeegmaken();
    }
}
