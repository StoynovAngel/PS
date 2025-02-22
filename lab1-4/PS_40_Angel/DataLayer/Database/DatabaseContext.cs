using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Others;

namespace DataLayer.Database;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string databaseFile = "Welcome.db";
        string databasePath = Path.Combine(solutionFolder, databaseFile);
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
        var user = new DatabaseUser()
        {
            Id = 1,
            Name = "Angel",
            Password = "1234",
            UserRole = UserRolesEnum.ADMIN,
            Expires = DateTime.Now.AddMonths(1),
            Email = "a@gmail.com"
        };
        
        modelBuilder.Entity<DatabaseUser>().HasData(user);
    }
    
    public DbSet<DatabaseUser> Users { get; set; }
}