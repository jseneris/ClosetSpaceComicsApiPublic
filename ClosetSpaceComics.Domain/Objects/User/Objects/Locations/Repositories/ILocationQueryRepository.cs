using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.User
{
	public interface ILocationQueryRepository
	{
		Task<UserLocationListModel> GetUserLocations(int userId);

		Task<IEnumerable<BoxIssueModel>> GetBoxItems(int userId, int locationId, int boxId);

		Task<IEnumerable<String>> GetCollectionTitles(int userId);

		Task<IEnumerable<String>> GetCollectionByTitle(int userId, string seoFriendlyTitleName);
	}
}
