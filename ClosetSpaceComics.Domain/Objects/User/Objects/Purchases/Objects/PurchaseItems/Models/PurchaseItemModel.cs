using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.User
{
	public class PurchaseItemModel
	{
		public int Id { get; set; }

		public int PurchaseId { get; set; }

		public int LocalTitleId { get; set; }

		public int LocalIssueId { get; set; }

		public ComicCondition Condition { get; set; }

		public int LocationId { get; set; }

		public int Order { get; set; }

		public String Notes { get; set; }

		public GradingServiceModel GradedCondition { get; set; }

		public IEnumerable<String> PictureUrls { get; set; }

		public PurchaseModel Purchase { get; set; }
	}
}
