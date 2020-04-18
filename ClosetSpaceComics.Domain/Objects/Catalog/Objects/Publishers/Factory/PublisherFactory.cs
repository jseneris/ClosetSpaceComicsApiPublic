
namespace ClosetSpaceComics.Domain.Catalog
{
	public class PublisherFactory : IPublisherFactory
	{
		public PublisherFactory(IPublisherContext context)
		{
			Context = context;
		}

		private IPublisherContext Context { get; set; }

		public PublisherObject Create(CatalogObject catalog)
		{
			return new PublisherObject(catalog, Context);
		}
	}
}
