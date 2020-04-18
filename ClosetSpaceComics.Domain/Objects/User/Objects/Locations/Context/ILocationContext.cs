
namespace ClosetSpaceComics.Domain.User
{
	public interface ILocationContext
	{
		ILocationQueryRepository QueryRepository { get; }
	}
}
