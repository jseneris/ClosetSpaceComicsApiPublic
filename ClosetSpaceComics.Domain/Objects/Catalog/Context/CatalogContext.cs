
namespace ClosetSpaceComics.Domain.Catalog
{
	public class CatalogContext : ICatalogContext
	{
		public CatalogContext(IPublisherFactory publisherFactory,
			ITitleFactory titleFactory,
			IIssueFactory issueFactory)
		{
			PublisherFactory = publisherFactory;
			TitleFactory = titleFactory;
			IssueFactory = issueFactory;
		}

		public IPublisherFactory PublisherFactory { get; private set;}

		public ITitleFactory TitleFactory { get; private set;}

		public IIssueFactory IssueFactory { get; private set;}

		//#region Publishers
		//private PublisherObject _publishers;

		//public PublisherObject Publishers
		//{
		//	get
		//	{
		//		if (_publishers != null)
		//			return _publishers;

		//		return (_publishers = PublisherFactory.Create(this));
		//	}
		//}
		//#endregion


		//public PublisherObject Publisher { get; }

		//public TitleObject Title { get; }

		//public IssueObject Issue { get; }

	}
}
