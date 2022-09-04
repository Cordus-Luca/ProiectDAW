using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProiectRestanta.Entities;

namespace ProiectRestanta.Data
{
    public class ProiectContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<ShirtDesign> ShirtDesigns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to One
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Boss)
                .WithOne(b => b.Shop);

            // One to Many
            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Shirts)
                .WithOne(sh => sh.Shop);

            // Many to Many
            modelBuilder.Entity<ShirtDesign>().HasKey(sd => new { sd.ShirtId, sd.DesignId });

            modelBuilder.Entity<ShirtDesign>()
                .HasOne(sd => sd.Shirt)
                .WithMany(sh => sh.ShirtDesigns)
                .HasForeignKey(sd => sd.DesignId);

            modelBuilder.Entity<ShirtDesign>()
                .HasOne(sd => sd.Design)
                .WithMany(d => d.ShirtDesigns)
                .HasForeignKey(sd => sd.ShirtId);

          
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });
        }
    }
}
