namespace URLShortener.Contracts
{
    internal class ShortenUrlResponse
    {
        public ShortenUrlResponse(string url, string short_url)
        {
            this.url = url;
            this.short_url = short_url;
        }
        
        public string url { get; }
        public string short_url { get; }
    }
}
