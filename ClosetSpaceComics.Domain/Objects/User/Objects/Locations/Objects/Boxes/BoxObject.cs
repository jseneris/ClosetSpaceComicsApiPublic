
namespace ClosetSpaceComics.Domain.User
{
	public class BoxObject
	{
		public BoxObject(UserObject owner, IBoxContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected UserObject Owner { get; private set; }

		public IBoxContext Context { get; private set; }
	}
}
