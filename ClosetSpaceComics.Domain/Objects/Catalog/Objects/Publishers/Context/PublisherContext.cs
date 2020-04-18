
namespace ClosetSpaceComics.Domain.Catalog
{
	public class PublisherContext : IPublisherContext
	{
		public PublisherContext(
			IPublisherQueryRepository queryRepository)
		{
			QueryRepository = queryRepository;
		}

		public IPublisherQueryRepository QueryRepository { get; private set; }
	}
}
