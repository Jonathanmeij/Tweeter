using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tweeter.Server.Migrations;
using Tweeter.Server.Models;
using Tweeter.Shared.Models;

namespace Tweeter.Server;

public class DataContext: IdentityUserContext<User>
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options): base(options)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserName = "johndoe",
                Email = "johndoe@mail.com",
                Id = "1",
                ProfilePicture = new Uri("https://fastly.picsum.photos/id/204/400/400.jpg?hmac=KqqANeQnoq20mhaCP7hblGf_FWK85L30flhC_Zu5-tE")
            },
            new User
            {
                UserName = "Kees",
                Email = "kees@mail.com",
                Id = "2",
                ProfilePicture = new Uri("https://fastly.picsum.photos/id/130/400/400.jpg?hmac=t7pjDM3Xuw1JrVA6Zohl7DYlGQWzMGSx6Mo9n-rgQQY")
            });
        
        modelBuilder.Entity<Post>().HasData(new Post
        {
            Id = "1",
            Content = "Hello World!",
            UserId = "1",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new Post
            {
                Id = "2",
                Content = "Kees aan de kade",
                UserId = "2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        );
    }

    public DbSet<Post> Posts { get; set; }

}