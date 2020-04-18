using ClosetSpaceComics.Domain.User;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public class LocationQueryRepository : ILocationQueryRepository
	{
		private String _cdnUrlBase = ConfigurationManager.AppSettings["AzureUrlBase"];

		LocationEntity test;

		public async Task<UserLocationListModel> GetUserLocations(int userId)
		{
			UserLocationListModel retval = new UserLocationListModel();
			using (var dataContext = new AppDbContext())
			{
				var query = dataContext.Locations.Include("Boxes")
					.Where(x => x.UserId == userId)
					.OrderBy(x => x.Order)
					.ThenBy(x => x.Name)
					.Select(x => new 
					{
						Locations = new 
						{
							Id = x.Id,
							Name = x.Name,
							Boxes = x.Boxes.Select(y => new 
							{
								Id = y.Id,
								Name = y.Name,
								Order = y.Order
							})
						}
					});

				var result = query.ToList();

				retval.Locations = result.Select(x => new UserLocationListModel.Location
				{
					Id = x.Locations.Id,
					Name = x.Locations.Name,
					ImageUrl = String.Format("{0}{1}.jpg", _cdnUrlBase, "location"),
					Boxes = x.Locations.Boxes.OrderBy(y => y.Order).Select(y => new UserLocationListModel.Box
					{
						Id = y.Id,
						Name = y.Name,
						ImageUrl = String.Format("{0}{1}.jpg", _cdnUrlBase, "box"),
					}).ToList()
				}).ToList();
			}

			return retval;
		}

		public async Task<IEnumerable<BoxIssueModel>> GetBoxItems(int userId, int locationId, int boxId)
		{
			var retval = new List<BoxIssueModel>();

			using (var dataContext = new AppDbContext())
			{
				var query = dataContext.Locations.Include("Boxes.Issues.Photos")
					.Include("Boxes.Issues.Titles.Publisher")
					.Where(x => x.UserId == userId && x.Id == locationId)
					.Select(x => new
					{
						Locations = new
						{
							Id = x.Id,
							Name = x.Name,
							Boxes = x.Boxes.Where(y => y.Id == boxId).Select(y => new
							{
								Id = y.Id,
								Name = y.Name,
								Items = y.Items.OrderBy(z => z.Order).Select(z => new
								{
									Id = z.Id,
									Title = new {
										TitleName = z.Title.Name,
										SeoFriendlyName = z.Title.SeoFriendlyName,
										Publisher = z.Title.Publisher,
									},
									IssueNumber = z.IssueNumber,
									Photos = z.Photos.ToList(),
									CatalogIssueUrl = z.Issue.ImageUrl,
								})
							}).FirstOrDefault()
						}
					});

				var result = query.First();

				retval = result.Locations.Boxes.Items.Select(x => new BoxIssueModel
				{
					Id = x.Id,
					ImageUrl = x.Photos.FirstOrDefault() != null ? string.Format("{0}{1}/{2}/{3}.jpg", _cdnUrlBase, x.Title.Publisher.SeoFriendlyName, x.Title.SeoFriendlyName, x.Photos.FirstOrDefault().Name) : x.CatalogIssueUrl
				}).ToList();
			}

			return retval;
		}

		public async Task<IEnumerable<String>> GetCollectionTitles(int userId)
		{
			var retval = new List<String>();
			using (var dataContext = new AppDbContext())
			{
				LocationEntity test;
				var query = dataContext.Locations
					.Include("Boxes")
					.Include("Boxes.Items")
					.Include("Boxes.Items.Title")
					.Include("Items.Title.Publisher")
					.Where(x => x.UserId == userId && x.Name != "Sold")
					.Select(x => new
					{
						Id = x.Id,
						Name = x.Name,
						Boxes = x.Boxes.Select(y => new
						{
							Id = y.Id,
							Name = y.Name,
							Items = y.Items.Select(z => new
							{
								Id = z.Id,
								Title = z.Issue.Title.Name,
								SeoFriendlyTitle = z.Issue.Title.SeoFriendlyName
							})
						})
					});

				var result = query.ToList();

				foreach(var location in result)
				{
					foreach(var box in location.Boxes)
					{
						var nameArray = box.Items.Select(x => x.Title);
						retval = retval.Union(nameArray).ToList();
					}
				}
				var test2 = retval.OrderBy(x => x).ToList();
				//retval = result.Select(x => new UserPurchaseModel
				//{
				//	Id = x.Id,
				//	Description = x.Description,
				//	PurchaseDate = x.PurchaseDate.ToString("MM/dd/yyyy"),
				//	Price = String.Format("{0:C2}", x.Price),
				//	Size = x.Issues.Count(),
				//	Issues = x.Issues.Select(y => new UserPurchaseModel.PurchaseIssueModel
				//	{
				//		Id = y.Id,
				//		ImageUrl = y.Photos.FirstOrDefault() != null ? String.Format("{0}/{1}/{2}/{3}.jpg", _cdnUrlBase, y.Title.Publisher.SeoFriendlyName, y.Title.SeoFriendlyName, y.Photos.FirstOrDefault().Name) : y.ImageUrl
				//	}).ToList()
				//}).ToList();
			}

			return retval;
		}

		public async Task<IEnumerable<String>> GetCollectionByTitle(int userId, String seoFriendlyTitleName)
		{
			var retval = new List<String>();
			var retval2 = new List<PurchaseItemEntity>();
			using (var dataContext = new AppDbContext())
			{
				LocationEntity test;
				var query = dataContext.Locations
					.Include("Boxes")
					.Include("Boxes.Items")
					.Include("Boxes.Items.Title")
					.Include("Items.Title.Publisher")
					.Where(x => x.UserId == userId && x.Name != "Sold")
					.Select(x => new
					{
						Id = x.Id,
						Name = x.Name,
						Boxes = x.Boxes.Select(y => new
						{
							Id = y.Id,
							Name = y.Name,
							Items = y.Items.Where(z => z.Issue.Title.SeoFriendlyName == seoFriendlyTitleName)
							//.Select(z => new
							//{
							//	Id = z.Id,
							//	Title = z.Issue.Title.Name,
							//	SeoFriendlyTitle = z.Issue.Title.SeoFriendlyName
							//})
						})
					});

				var result = query.ToList();

				foreach (var location in result)
				{
					foreach (var box in location.Boxes)
					{
						var nameArray = box.Items.Select(x => x.Title);
						var sdf = box.Items;
						retval2 = retval2.Concat(sdf).ToList();
					}
				}
				var test2 = retval.OrderBy(x => x).ToList();
				//retval = result.Select(x => new UserPurchaseModel
				//{
				//	Id = x.Id,
				//	Description = x.Description,
				//	PurchaseDate = x.PurchaseDate.ToString("MM/dd/yyyy"),
				//	Price = String.Format("{0:C2}", x.Price),
				//	Size = x.Issues.Count(),
				//	Issues = x.Issues.Select(y => new UserPurchaseModel.PurchaseIssueModel
				//	{
				//		Id = y.Id,
				//		ImageUrl = y.Photos.FirstOrDefault() != null ? String.Format("{0}/{1}/{2}/{3}.jpg", _cdnUrlBase, y.Title.Publisher.SeoFriendlyName, y.Title.SeoFriendlyName, y.Photos.FirstOrDefault().Name) : y.ImageUrl
				//	}).ToList()
				//}).ToList();
			}

			return retval;
		}
	}
}
