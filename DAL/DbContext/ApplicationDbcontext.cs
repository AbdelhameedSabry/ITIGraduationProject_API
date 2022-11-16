using ECommerceGP.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceGP.DAL
{
    public class ApplicationDbcontext:IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
        }
        public DbSet<Color> colors { get; set; } = null!;
        public DbSet<Gender> genders { get; set; } = null!;
        public DbSet<Size> sizes { get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;
        public DbSet<Cateogory> cateogories { get; set; } = null!;
        public DbSet<ShoppingCardHeader> shoppingCardHeaders { get; set; } = null!;
        public DbSet<CardProduct> cardProducts { get; set; } = null!;

    }
}
