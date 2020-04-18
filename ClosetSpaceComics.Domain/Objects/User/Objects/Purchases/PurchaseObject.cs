
namespace ClosetSpaceComics.Domain.User
{
	public class PurchaseObject
	{
		public PurchaseObject(UserObject owner, IPurchaseContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected UserObject Owner { get; private set; }

		public IPurchaseContext Context { get; private set; }
	}

}
