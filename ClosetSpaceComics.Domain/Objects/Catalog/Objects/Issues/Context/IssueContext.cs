
namespace ClosetSpaceComics.Domain.Catalog
{
	public class IssueContext : IIssueContext
	{
		public IssueContext(
			IIssueQueryRepository queryRepository,
			IIssueCommandRepository commandRepository)
		{
			QueryRepository = queryRepository;
			CommandRepository = commandRepository;
		}

		public IIssueQueryRepository QueryRepository { get; private set; }

		public IIssueCommandRepository CommandRepository { get; private set; }
	}
}
