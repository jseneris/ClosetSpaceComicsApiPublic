using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.ServiceNew.Code.Scraper;

namespace ClosetSpaceComics.Service.Repositories
{
	public class IssueCommandRepository : IIssueCommandRepository
	{
		private  String _baseUrl = ConfigurationManager.AppSettings["comicsUrl"];

		public async Task GetLatest(int page = 0)
		{
			if (page == 0)
			{
				await Scraper.ScrapeIssuePages(_baseUrl + "newreleases");
			}
			else
			{
				page = page < 8 ? page : 7;
				await Scraper.ScrapeIssuePages(String.Format(_baseUrl + "newreleases?dw={0}", page.ToString()));
			}
		}

		public async Task FillIssues(int titleId)
		{
			await Scraper.ScrapeTitlePages(titleId, false, true);
		}

		public async Task FindAndUpsertIssue(IssueEntity issue)
		{
			using (var dataContext = new AppDbContext())
			{
				var found = dataContext.Issues.FirstOrDefault(x => x.TitleId == issue.TitleId && x.SeoFriendlyName == issue.SeoFriendlyName);

				if (found == null)
				{
					try
					{
						dataContext.Issues.Add(issue);
						var success = dataContext.SaveChanges();
					}
					catch (Exception e)
					{
						var test = e.Message;
					}
				}
				else if (found.ReleaseDate != issue.ReleaseDate)
				{
					found.ReleaseDate = issue.ReleaseDate;
					dataContext.SaveChanges();
				}
			}
		}

	}
}
