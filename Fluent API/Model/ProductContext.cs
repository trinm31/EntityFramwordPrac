using Microsoft.EntityFrameworkCore;

namespace Fluent_API.Model
{
    public class ProductContext: DbContext

    {
        public DbSet<Product> Products { set; get; }
        public DbSet<User> Users {set; get;}
        

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {

                entity
                    .ToTable("User")
                    .HasComment(" this is user table")
                    .HasKey(e => e.UserId); // Tùy chọn tên của bảng là User (mặc định user)

                entity.Property(e => e.UserId)
                    .UseIdentityColumn(1, 1);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_name")
                    .HasDefaultValue("No name")
                    .HasMaxLength(50);
                entity.HasIndex(e => e.UserName)
                    .IsUnique(true);
            });

            modelBuilder.Entity<Product>(entity =>
                {
                    entity.HasOne(e => e.UserPost)                       // Chỉ ra Entity là phía một (bảng User)
                        .WithMany(user => user.ProductsPost)         // Chỉ ra Collection tập Product lưu ở phía một
                        .HasForeignKey("UserPostId")                 // Chỉ ra tên FK nếu muốn
                        .OnDelete(DeleteBehavior.SetNull)            // Ứng xử khi User bị xóa (Hoặc chọn DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Products_user_1234");
                    
                    
                }
            );
        }
    }
}