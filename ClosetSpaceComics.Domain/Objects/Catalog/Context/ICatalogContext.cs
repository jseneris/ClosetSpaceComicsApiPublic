
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface ICatalogContext
	{
		IPublisherFactory PublisherFactory { get; }

		ITitleFactory TitleFactory { get; }

		IIssueFactory IssueFactory { get; }

	}
}
