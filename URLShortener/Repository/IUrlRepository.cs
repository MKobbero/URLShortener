namespace URLShortener.Repository
{
    public interface IUrlRepository
    {
        bool Add(string longUrl, string shortUrl);

        string GetLongUrl(string shortUrl);
    }
}