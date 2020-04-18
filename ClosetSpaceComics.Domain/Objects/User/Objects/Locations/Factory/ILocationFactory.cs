
namespace ClosetSpaceComics.Domain.User
{
	public interface ILocationFactory
	{
		LocationObject Create(UserObject user);
	}
}
