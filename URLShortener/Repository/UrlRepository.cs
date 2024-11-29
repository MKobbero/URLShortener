namespace URLShortener.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private Dictionary<string, string> _urls;

        public void Add(string longUrl, string shortUrl)
        {
            _urls.TryAdd(shortUrl, longUrl);
        }

        public string GetLongUrl(string shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}
