namespace URLShortener.Repository
{
    public interface IUrlRepository
    {
        bool Add(string shortUrl, string longUrl);

        string? GetLongUrl(string shortUrl);
    }
}