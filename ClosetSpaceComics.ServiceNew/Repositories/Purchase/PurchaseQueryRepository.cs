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
	public class PurchaseQueryRepository : IPurchaseQueryRepository
	{
		private String _cdnUrlBase = ConfigurationManager.AppSettings["AzureUrlBase"];

		public async Task<IEnumerable<UserPurchaseModel>> GetPurchases(int userId, int? page = 1, int? pageSize = 20)
		{
			var retval = new List<UserPurchaseModel>();
			PurchaseEntity test;
			using (var dataContext = new AppDbContext())
			{
				var query = dataContext.Purchases
					.Include("Items")
					.Include("Items.Issue")
					.Include("Items.Title.Publisher")
					.Where(x => x.UserId == userId)
					.OrderByDescending(x => x.PurchaseDate)
					.Skip((page.Value - 1) * pageSize.Value)
					.Take(pageSize.Value)
					.Select(x => new 
					{
						Id = x.Id,
						Description = x.Description,
						PurchaseDate = x.PurchaseDate,
						Price = x.Price,
						Issues = x.Items.Select(y => new
						{
							Id = y.Id,
							Photos = y.Photos,
							Title = y.Title,
							ImageUrl = y.Issue.ImageUrl
						})
					});

				var result = query.ToList();

				retval = result.Select(x => new UserPurchaseModel
				{
					Id = x.Id,
					Description = x.Description,
					PurchaseDate = x.PurchaseDate.ToString("MM/dd/yyyy"),
					Price = String.Format("{0:C2}", x.Price),
					Size = x.Issues.Count(),
					ImageUrl = x.Issues.FirstOrDefault() != null && !String.IsNullOrWhiteSpace(x.Issues.First().ImageUrl) ?
						x.Issues.First().ImageUrl :
						String.Format("{0}{1}.jpg", _cdnUrlBase, "book"),
					Issues = x.Issues.Select(y => new UserPurchaseModel.PurchaseIssueModel
					{
						Id = y.Id,
						ImageUrl = y.Photos.FirstOrDefault() != null ? 
							String.Format("{0}/{1}/{2}/{3}.jpg", _cdnUrlBase, y.Title.Publisher.SeoFriendlyName, y.Title.SeoFriendlyName, y.Photos.FirstOrDefault().Name) : 
							String.IsNullOrWhiteSpace(y.ImageUrl) ?
								String.Format("{0}{1}.jpg", _cdnUrlBase, "book") :
								y.ImageUrl
					}).ToList()
				}).ToList();
			}

			return retval;
		}

	}
}
