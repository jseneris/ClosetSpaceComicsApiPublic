using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.Service.User;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClosetSpaceComics.Service
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base("DefaultConnection")
		{
		}

		public DbSet<UserEntity> Users { get; set; }
		public DbSet<PurchaseEntity> Purchases { get; set; }
		public DbSet<PurchaseItemEntity> PurchaseItems { get; set; }
		public DbSet<PhotoEntity> Photos { get; set; }
		public DbSet<LocationEntity> Locations { get; set; }
		public DbSet<BoxEntity> Boxes { get; set; }

		public DbSet<PublisherEntity> Publishers { get; set; }
		public DbSet<TitleEntity> Titles { get; set; }
		public DbSet<IssueEntity> Issues { get; set; }
		public DbSet<LocalTitleEntity> LocalTitles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}