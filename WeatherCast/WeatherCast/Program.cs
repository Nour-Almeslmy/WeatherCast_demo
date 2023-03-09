using WeatherCast.Controllers;

namespace WeatherCast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.Development.json");
                builder.AddJsonFile("conf/appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile("secret/secret.json", optional: true, reloadOnChange: true);
            });

            var logger = builder.Services.BuildServiceProvider().GetService<ILogger<ConfController>>();

            builder.Services.AddSingleton(typeof(ILogger), logger);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}