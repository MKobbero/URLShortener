﻿namespace URLShortener.Repository
{
    public interface IUrlRepository
    {
        void Add(string longUrl, string shortUrl);

        string GetLongUrl(string shortUrl);
    }
}