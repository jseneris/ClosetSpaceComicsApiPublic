
namespace ClosetSpaceComics.Domain.User
{
	public class BoxFactory : IBoxFactory
	{
		public BoxFactory(IBoxContext context)
		{
			Context = context;
		}

		private IBoxContext Context { get; set; }

		public BoxObject Create(UserObject user)
		{
			return new BoxObject(user, Context);
		}
	}
}
