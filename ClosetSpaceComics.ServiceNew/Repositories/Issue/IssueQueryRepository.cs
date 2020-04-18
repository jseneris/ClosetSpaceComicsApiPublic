using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.Service.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public class IssueQueryRepository : IIssueQueryRepository
	{
		private String _cdnUrlBase = ConfigurationManager.AppSettings["AzureUrlBase"];


		public async Task<IssuesByDateModel> GetByDateAsync(DateTime startTime, DateTime EndTime)
		{
			IssuesByDateModel retval = new IssuesByDateModel();
			using (var dataContext = new AppDbContext())
			{
				var query = dataContext.Issues.Include("Title.Publisher")
					.Where(x => x.ReleaseDate >= startTime && x.ReleaseDate < EndTime && x.Title.Publisher.DisplayOrder != null)
					.OrderBy(x => x.Title.Name)
					.ThenBy(x => x.SeoFriendlyName)
					.Select(x => new {
						Id = x.Id,
						ImageUrl = x.ImageUrl,
						IssueNum = x.SeoFriendlyName,
						Description = x.Description,
						CoverPrice = x.CoverPrice,
						TitleName = x.Title.Name,
						Publisher = new {
							PublisherName = x.Title.Publisher.Name,
							PublisherDisplayOrder = x.Title.Publisher.DisplayOrder,
							PublisherSeoFriendlyName = x.Title.Publisher.SeoFriendlyName,
							PublisherImageUrl = x.Title.Publisher.ImageName
						}
					});

				var result = query.ToList();

				retval.Issues = result.Select(x => new IssuesByDateModel.Issue { Id = x.Id, ImageUrl = x.ImageUrl, IssueNum = x.IssueNum, Title = x.TitleName, Publisher = x.Publisher.PublisherName, Description = x.Description, CoverPrice = x.CoverPrice }).ToList();
				retval.Filters = result.GroupBy(x => x.Publisher).OrderBy(y => y.Key.PublisherDisplayOrder).Select(y => new IssuesByDateModel.Filter { Name = y.Key.PublisherName, SeoFriendlyName = y.Key.PublisherSeoFriendlyName, ImageUrl = String.IsNullOrWhiteSpace(y.Key.PublisherImageUrl) ? string.Empty : _cdnUrlBase + "publishers/" + y.Key.PublisherImageUrl}).ToList();
			}

			return retval;
		}

		public async Task<IssuesByTitleModel> SearchByTitle(String search)
		{
			IssuesByTitleModel retval = new IssuesByTitleModel();
			using (var dataContext = new AppDbContext())
			{
				var query = dataContext.Titles
					.Include("Issues")
					.Include("Publisher")
					.Where(x => x.Name.Contains(search))
					.Take(50)
					.OrderBy(x => x.YearStart)
					.ThenBy(x => x.SeoFriendlyName)
					.Select(x => new
					{
						Id = x.Id,
						Name = x.Name,
						SeoFriendlyName = x.SeoFriendlyName,
						PublisherName = x.Publisher.Name,
						YearStart = x.YearStart,
						Issues = x.Issues.Select(y => new
						{
							Id = y.Id,
							ImageUrl = y.ImageUrl,
							IssueNum = y.SeoFriendlyName,
							Description = y.Description,
							CoverPrice = y.CoverPrice,
							TitleName = x.Name
						})
					});
					

				var result = await (query).ToListAsync();

				retval.Titles = result.OrderBy(x => x.YearStart).Where(x => x.Issues.Count() > 0).Select(x => new IssuesByTitleModel.Title { Id = x.Id, Name = x.Name, SeoFriendlyName = x.SeoFriendlyName, ImageUrl = x.Issues.First().ImageUrl, Issues = x.Issues.Select(y => new IssuesByTitleModel.Issue { Id = y.Id, ImageUrl = y.ImageUrl, IssueNum = y.IssueNum, Title = y.TitleName, Publisher = x.PublisherName, Description = y.Description, CoverPrice = y.CoverPrice }).ToList() }).ToList();
			}

			return retval;
		}

		public async Task UpdloadOldPhotos()
		{
			//using (var dataContext = new AppDbContext())
			//{
			//	PhotoEntity test;
			//	var photos = dataContext.Photos.Include("PurchaseItem.").ToList();
			//	foreach (var photo in photos)
			//	{
					
			//	}
			//	dataContext.SaveChanges();
			//}
		}
	}
}
