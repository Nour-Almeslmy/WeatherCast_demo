using Serilog;
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


            #region SeriLog

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            builder.Host.UseSerilog();

            #endregion


            #region .NetLogger

            //builder.Host.ConfigureAppConfiguration((ctx, builder) =>
            //{
            //    builder.AddJsonFile("appsettings.json");
            //    builder.AddJsonFile("conf/appsettings.json", optional: true, reloadOnChange: true);
            //    builder.AddJsonFile("secret/secret.json", optional: true, reloadOnChange: true);
            //});

            #endregion

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

            try
            {
                Log.Information("Application Starting");
                app.Run();
            }
            catch (Exception exp)
            {
                Log.Fatal(exp, "The App Failed To Start!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}