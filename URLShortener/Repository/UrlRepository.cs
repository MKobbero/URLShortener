namespace URLShortener.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private Dictionary<string, string> _urls;

        public UrlRepository()
        {
            _urls = new Dictionary<string, string>();
        }

        public bool Add(string shortUrl, string longUrl)
        {
            return _urls.TryAdd(shortUrl, longUrl);
        }

        public string? GetLongUrl(string shortUrl)
        {
            _urls.TryGetValue(shortUrl, out string url);
            return url;
        }
    }
}
