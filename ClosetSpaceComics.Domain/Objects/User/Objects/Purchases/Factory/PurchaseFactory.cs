
namespace ClosetSpaceComics.Domain.User
{
	public class PurchaseFactory : IPurchaseFactory
	{
		public PurchaseFactory(IPurchaseContext context)
		{
			Context = context;
		}

		private IPurchaseContext Context { get; set; }

		public PurchaseObject Create(UserObject user)
		{
			return new PurchaseObject(user, Context);
		}
	}
}
