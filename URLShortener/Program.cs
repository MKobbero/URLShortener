
using URLShortener.Business;
using URLShortener.Encoding;
using URLShortener.Repository;

namespace URLShortener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Dependency registrations
            builder.Services.AddSingleton<IUrlShortener, UrlShortener>();
            builder.Services.AddSingleton<IUrlRepository, UrlRepository>();
            builder.Services.AddSingleton<IShortUrlEncoder, ShortUrlEncoder>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.ConfigureEnpoints();

            app.Run();
        }
    }
}
