using VideoData.Models;

namespace VideoVerhuur.Services
{
    public interface IUserService
    {
        public void HuurFilm(Film film);
        public List<Film> GetMandje();
        public decimal GetTotaal();
        public void VerwijderFilm(int id);
        public Klant? GetUser();
        public Klant? TryLogin(string Naam, string Postcode);
        public bool IsIngelogd();
        public void Logout();
    }
}
