
using System;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IPublisherCommandRepository
	{
		Task<int> FindOrUpsertPublisher(String name);

		Task UpdatePubSeo();
	}
}
