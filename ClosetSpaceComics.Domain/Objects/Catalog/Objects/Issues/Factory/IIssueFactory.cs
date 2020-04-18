
namespace ClosetSpaceComics.Domain.Catalog
{
	public interface IIssueFactory
	{
		IssueObject Create(CatalogObject catalog);
	}
}
