using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.Service.User;
using System;
using System.Data.Entity;


namespace ClosetSpaceComics.Service.Models
{
	public class NewAppDbContext : DbContext
	{
		public NewAppDbContext() : base("NewConnection")
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
	}
}