using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuContent> MenuContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>()
            .ToTable("MenuAndSEO")
            .HasKey(m => m.ID);

        modelBuilder.Entity<MenuContent>()
            .ToTable("Contents")
            .HasKey(c => c.ID);

        modelBuilder.Entity<Menu>()
            .HasMany(m => m.Contents)
            .WithOne(c => c.Menu)
            .HasForeignKey(c => c.MenuID);
    }

}