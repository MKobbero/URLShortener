namespace URLShortener.Business
{
    public interface IUrlShortener
    {
        (bool Success, string LongUrl) GetUrl(string? shortUrl);

        (bool Success, string ShortUrl) ShortenUrl(string longUrl);
    }
}