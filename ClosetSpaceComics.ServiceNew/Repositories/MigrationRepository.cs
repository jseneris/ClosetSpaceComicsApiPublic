using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.Service.Models;
using ClosetSpaceComics.Service.User;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public class MigrationRepository : IMigrationRepository
	{
		private String _connectionString = ConfigurationManager.AppSettings["AzureConnectionString"];
		private CloudStorageAccount StorageAccount => CloudStorageAccount.Parse(_connectionString);
		private CloudBlobClient BlobClient => StorageAccount.CreateCloudBlobClient();
		private CloudBlobContainer BlobContainer(String containerName) { return BlobClient.GetContainerReference(containerName); }


		public async Task MigrateBoxes()
		{
			IEnumerable<BoxEntity> retval = new List<BoxEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Boxes.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Boxes.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Boxes] ON");
							dataContext.Boxes.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Boxes] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigrateLocations()
		{
			IEnumerable<LocationEntity> retval = new List<LocationEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Locations.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Locations.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Locations] ON");
							dataContext.Locations.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Locations] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigratePublishers()
		{
			IEnumerable<PublisherEntity> retval = new List<PublisherEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Publishers.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Publishers.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Publishers] ON");
							dataContext.Publishers.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Publishers] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigrateTitles()
		{
			IEnumerable<TitleEntity> retval = new List<TitleEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Titles.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Titles.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Titles] ON");
							dataContext.Titles.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Titles] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigrateIssues()
		{
			IEnumerable<IssueEntity> retval = new List<IssueEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Issues.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Issues.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Issues] ON");
							dataContext.Issues.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Issues] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigrateLocalTitles()
		{
			IEnumerable<LocalTitleEntity> retval = new List<LocalTitleEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.LocalTitles.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.LocalTitles.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[LocalTitles] ON");
							dataContext.LocalTitles.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[LocalTitles] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigratePurchases()
		{
			IEnumerable<PurchaseEntity> retval = new List<PurchaseEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.Purchases.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.Purchases.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Purchases] ON");
							dataContext.Purchases.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Purchases] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigratePurchaseItems()
		{
			IEnumerable<PurchaseItemEntity> retval = new List<PurchaseItemEntity>();
			using (var dataContext = new AppDbContext())
			{
				retval = dataContext.PurchaseItems.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.PurchaseItems.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PurchaseItems] ON");
							dataContext.PurchaseItems.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PurchaseItems] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task MigratePhotos()
		{
			IEnumerable<PhotoEntity> retval = new List<PhotoEntity>();
			using (var dataContext = new AppDbContext())
			{
				//dataContext.Configuration.ProxyCreationEnabled = false;
				retval = dataContext.Photos.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				//dataContext.Configuration.ProxyCreationEnabled = false;
				var newList = dataContext.Photos.FirstOrDefault();
				if (newList == null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Photos] ON");
							dataContext.Photos.AddRange(retval);
							dataContext.SaveChanges();
							dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Photos] OFF");

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task UpdatePurchaseItems()
		{
			IEnumerable<PurchaseItemEntity> oldPIs = new List<PurchaseItemEntity>();
			using (var dataContext = new AppDbContext())
			{
				oldPIs = dataContext.PurchaseItems.ToList();
			}

			using (var dataContext = new NewAppDbContext())
			{
				var newList = dataContext.PurchaseItems.ToList();
				if (newList != null)
				{
					using (var transaction = dataContext.Database.BeginTransaction())
					{
						try
						{
							foreach(var oldPi in oldPIs)
							{
								var newEntity = newList.Where(x => x.Id == oldPi.Id).FirstOrDefault();
								if (newEntity != null)
								{
									newEntity.IssueNumber = oldPi.IssueNumber;
									newEntity.IssueNumberOrdinal = oldPi.IssueNumberOrdinal;
									newEntity.IssueId = oldPi.IssueId;
									newEntity.TitleId = oldPi.TitleId;
								}
								dataContext.SaveChanges();
							}

							transaction.Commit();
						}
						catch (Exception e)
						{
							var test = e.Message;
						}
					}
				}
			}
		}

		public async Task UploadLocalPhotos(){
			using (var dataContext = new AppDbContext())
			{
				var photos = dataContext.Photos
					.Include("PurchaseItem.Title")
					.ToList();
				int missingCount = 1;
				foreach(var photo in photos)
				{
					//var path = @"C:\Users\John\Documents\ClosetSpaceComics\NopCommerce-3.5\Presentation\Nop.Web\Content\Images\Thumbs\" + photo.Name + ".jpeg";
					var path = @"C:\Users\John\Downloads\closetspace-site-archive-20180121\Content\Images\Thumbs\" + photo.Name + ".jpeg";
					if (File.Exists(path))
					{
						try
						{
							using (var stream = File.OpenRead(path))
							{
								var name = $"{photo.Name}.jpg";
								String containerName = "closetspacecomics";
								String key = string.Empty;
								if (photo.PurchaseItem.Title != null)
								{
									//var test3 = photo.PurchaseItem.Title.Publisher.SeoFriendlyName;
									//var test4 = photo.PurchaseItem.Title.SeoFriendlyName;
									//containerName = String.Format(@"{0}/{1]/", test3, test4);
									key = String.Format(@"{0}/{1}/{2}", photo.PurchaseItem.Title.Publisher.SeoFriendlyName, photo.PurchaseItem.Title.SeoFriendlyName, name);
									//var blobKeyBase = String.Format(@"UserImages/{0}/Profile/{1}", userPhotoId, id);

								}
								else
								{
									key = String.Format("localtitles/{0}", name);
								}
								//var blobRef = GetBlob(key, containerName);
								var blobRef = BlobContainer(containerName).GetBlockBlobReference(key);

								if (blobRef.Exists() == false)
								{
									//await blobRef.UploadFromStreamAsync(stream);
									blobRef.Properties.ContentType = "image/jpeg";
									blobRef.UploadFromStream(stream);
								}

							}
						}
						catch(Exception e)
						{
							var test = e.Message;
						}
					}
					else
					{
						Debug.WriteLine(String.Format("#{0} id: {1}, name: {2}", missingCount, photo.Id, photo.Name));
						missingCount++;
					}
				}
			}

		}



	}
}
