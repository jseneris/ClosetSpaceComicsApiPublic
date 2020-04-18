
namespace ClosetSpaceComics.Domain.User
{
	public interface IPurchaseContext
	{
		IPurchaseQueryRepository QueryRepository { get; }

		IPurchaseCommandRepository CommandRepository { get; }
	}
}
