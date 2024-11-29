using Sqids;
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

        private static void GetUrl(HttpContext context, IUrlRepository urlRepository)
        {
            string shortUrl = context.Request.Path.Value.Remove(0,1);

            string longUrl = urlRepository.GetLongUrl(shortUrl);
            if (longUrl == null)
            {
                context.Response.StatusCode = 404;
                return;
            }

            context.Response.Redirect(longUrl);
            return;

            //if (result == null)
            //    return TypedResults.NotFound();
            //else
            //    return TypedResults.Ok(result);
        }

        private static ShortenUrlResponse ShortenUrl(HttpContext context, 
            IShortUrlEncoder shortUrlEncoder,
            IUrlRepository urlRepository, 
            ShortenUrlRequest request)
        {
            string squid;
            do
            {
                squid = shortUrlEncoder.GetNextSquid();
            }
            while (!urlRepository.Add(squid, request.url));

            return new ShortenUrlResponse(request.url, "http://localhost:5278/" + squid);
        }
    }
}
