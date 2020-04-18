using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.User
{
	public interface IUserQueryRepository
	{
		Task<int> GetUserId(string fireBaseId);
	}
}
