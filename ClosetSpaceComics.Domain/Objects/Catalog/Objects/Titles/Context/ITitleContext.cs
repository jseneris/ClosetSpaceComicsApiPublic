
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface ITitleContext
	{
		ITitleQueryRepository QueryRepository { get; }

		ITitleCommandRepository CommandRepository { get; }
	}
}
