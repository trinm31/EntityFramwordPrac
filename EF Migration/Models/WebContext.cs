using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EF_Migration.Models
{
    public class WebContext: DbContext
    {
        public DbSet<Article> articles {set; get;}        // bảng article
        public DbSet<Tag> tags {set; get;}
        public DbSet<ArticleTag> articleTags {set; get;}// bảng tag

        // chuỗi kết nối với tên db sẽ làm  việc đặt là webdb
        public const string ConnectStrring  =  @"Data Source=localhost,1433;Initial Catalog=webdb;User ID=SA;Password=Password789";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        }
        
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name,
                        LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTag>(entity => {
                // Tạo Index Unique trên 2 cột
                entity.HasIndex(p => new {p.ArticleId,  p.TagId})
                    .IsUnique();
            });
        }

    }
}