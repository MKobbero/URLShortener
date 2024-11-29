namespace URLShortener.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private Dictionary<string, string> _urls;

        public bool Add(string longUrl, string shortUrl)
        {
            return _urls.TryAdd(shortUrl, longUrl);
        }

        public string GetLongUrl(string shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}
