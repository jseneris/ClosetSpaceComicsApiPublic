using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.Code;
using ClosetSpaceComics.Service.ComicDb;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public class TitleCommandRepository : ITitleCommandRepository
	{
		public async Task<TitleEntity> FindOrUpsertTitle(String title, int publishId)
		{
			TitleEntity retval = null;
			using (var dataContext = new AppDbContext())
			{
				try
				{
					retval = dataContext.Titles.FirstOrDefault(x => x.Name == title && x.PublisherId == publishId);

					if (retval == null)
					{
						retval = dataContext.Titles.Add(new TitleEntity
						{
							Name = title,
							PublisherId = publishId,
							LastUpdate = DateTime.UtcNow
						});
						//var success = await dataContext.SaveChangesAsync();
						var success = dataContext.SaveChanges();
					}
				}
				catch (Exception e)
				{
					var test = e.Message;
				}
			}

			return retval;
		}

		public async Task<TitleEntity> FindTitleById(int titleId)
		{
			TitleEntity retval = null;
			using (var dataContext = new AppDbContext())
			{
				try
				{
					retval = dataContext.Titles.FirstOrDefault(x => x.Id == titleId);
				}
				catch (Exception e)
				{
					var test = e.Message;
				}
			}

			return retval;
		}

		public async Task UpdateTitleSeo()
		{
			using (var dataContext = new AppDbContext())
			{
				var titles = dataContext.Titles.Where(x => x.SeoFriendlyName == null).ToList();
				foreach (var title in titles)
				{
					title.SeoFriendlyName = CommonCode.GetSeoFriendlyName(title.Name);
				}
				dataContext.SaveChanges();
			}

		}


	}
}
