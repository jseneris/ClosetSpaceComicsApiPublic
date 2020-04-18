
namespace ClosetSpaceComics.Domain.User
{
	public class LocationFactory : ILocationFactory
	{
		public LocationFactory(ILocationContext context)
		{
			Context = context;
		}

		private ILocationContext Context { get; set; }

		public LocationObject Create(UserObject user)
		{
			return new LocationObject(user, Context);
		}
	}
}
