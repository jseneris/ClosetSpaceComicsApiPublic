
namespace ClosetSpaceComics.Domain.User
{
	public interface IPurchaseFactory
	{
		PurchaseObject Create(UserObject user);
	}
}
