
namespace ClosetSpaceComics.Domain.User
{
	public class BoxContext : IBoxContext
	{
		public BoxContext(
			IBoxQueryRepository queryRepository)
		{
			QueryRepository = queryRepository;
		}

		public IBoxQueryRepository QueryRepository { get; private set; }
	}
}
