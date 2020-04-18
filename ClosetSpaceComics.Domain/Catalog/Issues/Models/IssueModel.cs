
using System;

namespace ClosetSpaceComics.Domain.Catalog
{
	public class IssueModel
	{
		public int Id { get; set; }

		public String IssueNumber { get; set; }

		public DateTime ReleaseDate { get; set; }

		public Decimal CoverPrice { get; set; }

		public String Description { get; set; }

		public String StockPhotoUrl { get; set; }

		public int Order { get; set; }

		public TitleModel Title { get; set; }

		public PublisherModel Publisher { get; set; }
	}
}
