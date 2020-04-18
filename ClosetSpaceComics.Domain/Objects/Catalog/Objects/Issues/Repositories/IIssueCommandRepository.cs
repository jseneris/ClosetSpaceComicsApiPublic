using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IIssueCommandRepository
	{
		Task GetLatest(int page = 0);

		Task FillIssues(int titleId);
	}
}
