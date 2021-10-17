using Microsoft.EntityFrameworkCore;

namespace Interlogica.Pastry.BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfectioneryIngredient>()
                .HasKey(ci => new { ci.ConfectioneryId, ci.IngredientId });

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

    }
}
