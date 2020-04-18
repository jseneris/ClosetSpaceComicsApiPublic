
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IPublisherFactory
	{
		PublisherObject Create(CatalogObject catalog);
	}
}
