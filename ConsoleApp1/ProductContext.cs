using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class ProductContext: DbContext

    {
    public DbSet<Product> Products { set; get; }

    // Chuỗi kết nối tới CSDL (MS SQL Server)
    private const string ConnectionString = @"
                Data Source=localhost,1433;
                Initial Catalog=Test;
                User ID=SA;Password=Password789";

    // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
    // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseSqlServer(ConnectionString);
        //.UseLoggerFactory (loggerFactory);

    }
    }
}