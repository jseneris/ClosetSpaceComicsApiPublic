using System;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IIssueQueryRepository
	{
		Task<IssuesByDateModel> GetByDateAsync(DateTime startTime, DateTime EndTime);

		Task<IssuesByTitleModel> SearchByTitle(String search);
	}
}
