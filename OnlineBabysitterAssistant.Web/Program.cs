using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Infrastructure;
using OnlineBabysitterAssistant.Web.Application.Configurations;
using OnlineBabysitterAssistant.Web.Application.Configurations.Extensions;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;

namespace OnlineBabysitterAssistant.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
        builder.Services.AddCors();
        builder.Services.AddControllers().AddJsonOptions(x =>
        {
            // serialize enums as strings in api responses (e.g. Role)
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.RegisterServices();
        builder.Services.RegisterMappers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BabysitterContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BabysitterDBContext")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

        app.UseHttpsRedirection();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<JwtMiddleware>();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

