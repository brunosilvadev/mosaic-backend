using Microsoft.EntityFrameworkCore;
using Mosaic.Model;

namespace Mosaic.Persistence;

public class CanvasDbContext : DbContext
{
	public CanvasDbContext(DbContextOptions<CanvasDbContext> options) : base(options)
	{
		Database.EnsureCreated();
	}
	public DbSet<Pixel> Pixels { get; set; } 
	public DbSet<Canvas> Canvas { get; set; }	
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{		
		//modelBuilder.Entity<Reminder>().HasKey(r => r.ReminderId);
		
		modelBuilder.Entity<Pixel>()
			.HasOne(c => c.Canvas)
			.WithMany()
			.HasForeignKey(c => c.CanvasId);

		base.OnModelCreating(modelBuilder);
	}
}