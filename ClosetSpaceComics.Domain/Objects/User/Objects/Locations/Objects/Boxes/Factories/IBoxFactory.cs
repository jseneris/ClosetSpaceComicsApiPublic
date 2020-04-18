
namespace ClosetSpaceComics.Domain.User
{
	public interface IBoxFactory
	{
		BoxObject Create(UserObject user);
	}
}
