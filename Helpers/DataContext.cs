using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BusinessServiceModel> BusinessServices { get; set; }
        public DbSet<ProviderModel> ProviderServices { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<WidgetModel> Widget { get; set; }
        public DbSet<BusinessManagerModel> BusinessManager { get; set; }
        public DbSet<BookingsModel> Booking { get; set; }
        public DbSet<FileModel> FileUpload { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            //options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));

        }
    }
}