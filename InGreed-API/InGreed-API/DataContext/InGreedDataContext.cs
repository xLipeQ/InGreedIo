using InGreed_API.Configurations;
using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;

namespace InGreed_API.DataContext
{
    public class InGreedDataContext : DbContext
    {
        public InGreedDataContext(DbContextOptions<InGreedDataContext> options) : base(options) { }
        public InGreedDataContext() { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<ProductIngredient> ProductIngredients { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<Opinion> Opinions { get; set; }

        public virtual DbSet<Preference> Preferences { get; set; }

        public virtual DbSet<FavouriteProduct> FavouriteProducts { get; set; }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<Report> Reports { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new ProductIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new OpinionConfiguration());
            modelBuilder.ApplyConfiguration(new PreferenceConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteProductConfiguration());
            modelBuilder.ApplyConfiguration(new BanConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        }
    }
}
