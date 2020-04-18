
namespace ClosetSpaceComics.Domain.User
{
	public class PurchaseContext : IPurchaseContext
	{
		public PurchaseContext(
			IPurchaseQueryRepository queryRepository,
			IPurchaseCommandRepository commandRepository)
		{
			QueryRepository = queryRepository;

			CommandRepository = commandRepository;
		}

		public IPurchaseQueryRepository QueryRepository { get; private set; }

		public IPurchaseCommandRepository CommandRepository { get; private set; }
	}
}
