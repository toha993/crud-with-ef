using Microsoft.EntityFrameworkCore;
using Url_Shortener.UrlShortener.Core.Models;

namespace Url_Shortener.UrlShortener.Web.Helpers;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"), builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
        base.OnConfiguring(options);
    }

    public DbSet<User> Users { get; set; }
    
}