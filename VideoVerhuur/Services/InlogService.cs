using VideoData.Models;

public class InlogService
{
    private readonly VideoVerhuurDbContext _context;

    public InlogService(VideoVerhuurDbContext context)
    {
        _context = context;
    }
    public Klant? TryLogin(string Naam, string postcode)
    {
        return _context.Klanten.FirstOrDefault(klant => klant.Naam == Naam && klant.PostCode == postcode);
    }
}