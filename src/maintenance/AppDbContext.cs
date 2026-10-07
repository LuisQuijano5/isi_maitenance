using Microsoft.EntityFrameworkCore;

namespace MaintenanceBackend;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // You will add your Tables
    // public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
}