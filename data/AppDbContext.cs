using Microsoft.EntityFrameworkCore;
using SmartEvent.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}