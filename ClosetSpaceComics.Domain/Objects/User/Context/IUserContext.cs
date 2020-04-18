
namespace ClosetSpaceComics.Domain.User
{
	public interface IUserContext
	{
		ILocationFactory LocationFactory { get; }

		IPurchaseFactory PurchaseFactory { get; }

		IUserQueryRepository UserQueryRepository { get; }
	}
}
