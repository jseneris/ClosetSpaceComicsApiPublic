
namespace ClosetSpaceComics.Domain.User
{
	public class UserContext : IUserContext
	{
		public UserContext(
			ILocationFactory locationFactory,
			IPurchaseFactory purchaseFactory,
			IUserQueryRepository userQueryRepository)
		{
			PurchaseFactory = purchaseFactory;
			LocationFactory = locationFactory;
			UserQueryRepository = userQueryRepository;
		}

		public ILocationFactory LocationFactory { get; private set; }

		public IPurchaseFactory PurchaseFactory { get; private set; }

		public IUserQueryRepository UserQueryRepository { get; private set; }
	}
}
