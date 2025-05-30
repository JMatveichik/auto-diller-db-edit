using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Data
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Automobile> Automobiles { get; set; }
		public DbSet<BodyType> BodyTypes { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Dealer> Dealers { get; set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Warranty> Warranties { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Настройка составного ключа для Equipment
			modelBuilder.Entity<Equipment>()
				.HasKey(e => new { e.AutoId, e.Id });

			modelBuilder.Entity<Equipment>()
				.HasOne(e => e.Automobile)
				.WithMany(a => a.Equipments)
				.HasForeignKey(e => e.AutoId);

			modelBuilder.Entity<Automobile>()
				.HasOne(a => a.BodyType)
				.WithMany(bt => bt.Automobiles)
				.HasForeignKey(a => a.BodyTypeId);

			modelBuilder.Entity<Contract>()
				.HasOne(c => c.User)
				.WithMany(u => u.Contracts)
				.HasForeignKey(c => c.UserId);

			modelBuilder.Entity<Contract>()
				.HasOne(c => c.Dealer)
				.WithMany(d => d.Contracts)
				.HasForeignKey(c => c.DealerId);

			modelBuilder.Entity<Contract>()
				.HasOne(c => c.Automobile)
				.WithMany()
				.HasForeignKey(c => c.AutoId);

			modelBuilder.Entity<Contract>()
				.HasOne(c => c.Equipment)
				.WithMany()
				.HasForeignKey(c => new { c.AutoId, c.EquipmentId });

			modelBuilder.Entity<Contract>()
				.HasOne(c => c.Warranty)
				.WithMany(w => w.Contracts)
				.HasForeignKey(c => c.WarrantyId);
		}
	}
}
