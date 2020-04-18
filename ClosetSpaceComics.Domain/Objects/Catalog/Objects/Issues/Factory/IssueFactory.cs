
namespace ClosetSpaceComics.Domain.Catalog
{
	public class IssueFactory : IIssueFactory
	{
		public IssueFactory(IIssueContext context)
		{
			Context = context;
		}

		private IIssueContext Context { get; set; }

		public IssueObject Create(CatalogObject catalog)
		{
			return new IssueObject(catalog, Context);
		}
	}
}
