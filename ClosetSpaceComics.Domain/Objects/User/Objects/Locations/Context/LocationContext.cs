
namespace ClosetSpaceComics.Domain.User
{
	public class LocationContext : ILocationContext
	{
		public LocationContext(
			ILocationQueryRepository queryRepository)
		{
			QueryRepository = queryRepository;
		}

		public ILocationQueryRepository QueryRepository { get; private set; }

	}
}
