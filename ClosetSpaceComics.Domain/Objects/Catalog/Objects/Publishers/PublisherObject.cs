
namespace ClosetSpaceComics.Domain.Catalog
{
	public class PublisherObject
	{
		public PublisherObject(CatalogObject owner, IPublisherContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected CatalogObject Owner { get; private set; }

		protected IPublisherContext Context { get; private set; }
	}
}
