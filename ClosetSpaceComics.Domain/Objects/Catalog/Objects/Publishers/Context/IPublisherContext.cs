
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IPublisherContext
	{
		IPublisherQueryRepository QueryRepository { get; }
	}
}
