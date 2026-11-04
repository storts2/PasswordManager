using Microsoft.EntityFrameworkCore;
using PasswordManager.PasswordDbContext;
using PasswordManager.Services;

namespace PasswordManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<PWordDbContext>(options
            => options.UseSqlite(builder.Configuration
            .GetConnectionString("PasswordDbString")));

        builder.Services.AddScoped<IPasswordEntryServices, PasswordEntryService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapRazorPages()
            .WithStaticAssets();

        app.Run();
    }
}
