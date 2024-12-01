using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sqids;
using URLShortener.Business;
using URLShortener.Contracts;
using URLShortener.Encoding;
using URLShortener.Repository;

namespace URLShortener
{
    public static class Endpoints
    {
        public static void ConfigureEnpoints(this WebApplication app)
        {
            app.MapPost("shorten-url", ShortenUrl)
                .WithName("Shorten URL")
                .WithOpenApi();

            app.MapGet("/{*slug}", GetUrl)
                .WithName("Get")
                .WithOpenApi();
        }

        private static Results<RedirectHttpResult, NotFound> GetUrl(HttpContext context, IUrlShortener urlShortener)
        {
            var shortUrl = context.Request.Path.Value;
            var result = urlShortener.GetUrl(shortUrl);

            if (result.Success == false)
                return TypedResults.NotFound();

            return TypedResults.Redirect(result.LongUrl);
        }

        private static Results<Ok<ShortenUrlResponse>, BadRequest> ShortenUrl(HttpContext context, 
            IShortUrlEncoder shortUrlEncoder,
            IUrlShortener urlShortener, 
            ShortenUrlRequest request)
        {
            var result = urlShortener.ShortenUrl(request.url);

            if (result.Success == false)
                return TypedResults.BadRequest();

            return TypedResults.Ok(new ShortenUrlResponse(request.url, "https://localhost:7008/" + result.ShortUrl));
        }
    }
}
