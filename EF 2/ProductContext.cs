using Microsoft.EntityFrameworkCore;


namespace EF_2
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> products { set; get; }

        // Chuỗi kết nối tới CSDL (MS SQL Server)
        private const string connectionString = @"
                Data Source=localhost,1433;
                Initial Catalog=Test;
                User ID=SA;Password=Password789";

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring (optionsBuilder);
            optionsBuilder
                .UseSqlServer (connectionString);
            //.UseLoggerFactory (loggerFactory);

        }
    }
}