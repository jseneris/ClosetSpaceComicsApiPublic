
namespace ClosetSpaceComics.Domain.Catalog
{
	public class IssueObject
	{
		public IssueObject(CatalogObject owner, IIssueContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected CatalogObject Owner { get; private set; }

		public IIssueContext Context { get; private set; }
	}
}
