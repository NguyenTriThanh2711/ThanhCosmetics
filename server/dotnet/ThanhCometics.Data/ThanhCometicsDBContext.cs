using Microsoft.EntityFrameworkCore;
using ThanhCometics.Repository.Entities;

namespace ThanhCometics.Repository
{
    public class ThanhCometicsDBContext : DbContext
    {
        public ThanhCometicsDBContext(DbContextOptions<ThanhCometicsDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogDetail> BlogDetails { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Function> Functions { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductFunction> ProductFunctions { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductIngredient> ProductIngredients { get; set; } = null!;
        public virtual DbSet<ProductSkinType> ProductSkinTypes { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Routine> Routines { get; set; } = null!;
        public virtual DbSet<RoutineDetail> RoutineDetails { get; set; } = null!;
        public virtual DbSet<RoutineStep> RoutineSteps { get; set; } = null!;
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; } = null!;
        public virtual DbSet<ShippingPriceTable> ShippingPriceTables { get; set; } = null!;
        public virtual DbSet<SkinTest> SkinTests { get; set; } = null!;
        public virtual DbSet<SkinType> SkinTypes { get; set; } = null!;
        public virtual DbSet<SkinTypeAnswer> SkinTypeAnswers { get; set; } = null!;
        public virtual DbSet<SkinTypeQuestion> SkinTypeQuestions { get; set; } = null!;
        public virtual DbSet<TestTableThanh> TestTableThanhs { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tắt tính năng Cascade Delete (Xoá cha tự động xoá con) trên toàn bộ database.
            // Vì hệ thống của bạn có rất nhiều quan hệ phức tạp, nếu để mặc định SQL Server/MySQL sẽ báo lỗi "Multiple cascade paths".
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // (Tuỳ chọn) Cấu hình độ dài hoặc kiểu dữ liệu cụ thể nếu cần, 
            // ví dụ với OrderCode, PhoneNumber, v.v.
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Discount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Voucher>()
                .Property(v => v.DiscountAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>().Property(o => o.ShippingPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ProductIngredient>().Property(p => p.Concentration).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ShippingPriceTable>().Property(s => s.InRegion).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ShippingPriceTable>().Property(s => s.OutRegion).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ShippingPriceTable>().Property(s => s.Pir).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ShippingPriceTable>().Property(s => s.Por).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Voucher>().Property(v => v.MinimumPurchase).HasColumnType("decimal(18,2)");
        }
    }
}