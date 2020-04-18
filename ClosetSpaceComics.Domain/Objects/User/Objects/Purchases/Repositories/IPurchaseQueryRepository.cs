using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.User
{
	public interface IPurchaseQueryRepository
	{
		Task<IEnumerable<UserPurchaseModel>> GetPurchases(int userId, int? page, int? pageSize);
	}
}
