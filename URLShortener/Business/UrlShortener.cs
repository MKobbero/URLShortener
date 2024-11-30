using URLShortener.Encoding;
using URLShortener.Repository;

namespace URLShortener.Business
{
    public class UrlShortener : IUrlShortener
    {
        private readonly IShortUrlEncoder encoder;
        private readonly IUrlRepository urlRepository;

        public UrlShortener(IShortUrlEncoder encoder, IUrlRepository urlRepository)
        {
            this.encoder = encoder;
            this.urlRepository = urlRepository;
        }

        public (bool, string) GetUrl(string? shortUrl)
        {
            //Expected string format is: "/xx.."
            if (shortUrl == null || !shortUrl.StartsWith('/') || shortUrl.Length < 2)
                return (false, string.Empty);

            var longUrl = urlRepository.GetLongUrl(shortUrl.Remove(0, 1));
            if (longUrl == null)
            {
                return (false, string.Empty);
            }

            return (true, longUrl);
        }

        public (bool, string) ShortenUrl(string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
                return (false, string.Empty);

            string squid;
            do
            {
                squid = encoder.GetNextSquid();
            }
            while (!urlRepository.Add(squid, longUrl));

            return (true, squid);
        }
    }
}
