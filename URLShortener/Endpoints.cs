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

        private static void GetUrl(HttpContext context)
        {
            context.Response.Redirect("https://www.google.dk/");
            return;

            //if (result == null)
            //    return TypedResults.NotFound();
            //else
            //    return TypedResults.Ok(result);
        }

        private static void ShortenUrl(HttpContext context, ShortenUrlRequest request)
        {

        }
    }
}
