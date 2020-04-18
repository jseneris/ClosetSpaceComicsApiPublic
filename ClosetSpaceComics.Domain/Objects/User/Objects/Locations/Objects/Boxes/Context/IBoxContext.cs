
namespace ClosetSpaceComics.Domain.User
{
	public interface IBoxContext
	{
		IBoxQueryRepository QueryRepository { get; }
	}
}
