
namespace ClosetSpaceComics.Domain.User
{
	public class LocationObject
	{
		public LocationObject(UserObject owner, ILocationContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected UserObject Owner { get; private set; }

		public ILocationContext Context { get; private set; }
	}
}
