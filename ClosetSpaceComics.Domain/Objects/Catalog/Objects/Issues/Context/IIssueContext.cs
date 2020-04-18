
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IIssueContext
	{
		IIssueQueryRepository QueryRepository { get; }

		IIssueCommandRepository CommandRepository { get; }
	}
}
