using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.Code;
using ClosetSpaceComics.Service.ComicDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public class PublisherCommandRepository : IPublisherCommandRepository
	{
		public async Task<int> FindOrUpsertPublisher(String name)
		{
			int retval = 0;

			using (var dataContext = new AppDbContext())
			{
				var publisher = dataContext.Publishers.FirstOrDefault(x => x.Name == name);
				if (publisher != null)
				{
					retval = publisher.Id;
				}
				else
				{
					var newPublisher = new PublisherEntity
					{
						Name = name
					};
					try
					{
						dataContext.Publishers.Add(newPublisher);
						var success = dataContext.SaveChanges();
						retval = newPublisher.Id;
					}
					catch (Exception e)
					{
						var test = e.Message;
					}

				}
			}
			return retval;
		}

		public async Task UpdatePubSeo()
		{
			using (var dataContext = new AppDbContext())
			{
				var publishers = dataContext.Publishers.Where(x => x.SeoFriendlyName != null).ToList();
				foreach (var publisher in publishers)
				{
					publisher.SeoFriendlyName = CommonCode.GetSeoFriendlyName(publisher.Name);
				}
				dataContext.SaveChanges();
			}
		}

	}
}
