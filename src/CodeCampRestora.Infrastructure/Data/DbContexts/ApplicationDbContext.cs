using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Domain.Entities.Orders;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Staff>().ToTable("Staffs");

        base.OnModelCreating(builder);

        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<ApplicationRole>().HasData
        (
            new ApplicationRole { Id = new Guid("8b6e10d4-1c75-4c0b-9417-a55c2241bcb2"), Name = "User", ConcurrencyStamp = "1", NormalizedName = "USER" },
            new ApplicationRole { Id = new Guid("ac12af63-15b6-48ea-b132-c9f27e15df90"), Name = "Owner", ConcurrencyStamp = "2", NormalizedName = "OWNER" },
            new ApplicationRole { Id = new Guid("e0b4d5f8-7340-4c6e-9d66-58e120a9298f"), Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "MANAGER" },
            new ApplicationRole { Id = new Guid("a5e34882-8d8b-49f9-bc47-5ca81c3759c9"), Name = "Waiter", ConcurrencyStamp = "4", NormalizedName = "WAITER" },
            new ApplicationRole { Id = new Guid("74c34278-22b3-452e-9e04-7d596f4fcbef"), Name = "KitchenStuff", ConcurrencyStamp = "5", NormalizedName = "KITCHENSTUFF" }
        );
    }

    public DbSet<T> DbSet<T>() where T: class => Set<T>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Staff> Staffs => Set<Staff>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
    public DbSet<Order> Orders {  get; set; }
    public DbSet<OrderItem> OrderItems {  get; set; }
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ReviewComment> ReviewComments => Set<ReviewComment>();
}
