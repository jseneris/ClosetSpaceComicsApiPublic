using System;
using System.Collections;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.Catalog
{
	public class TitleModel
	{
		public int Id { get; set; }

		public String Name { get; set; }

		public int YearStart { get; set; }

		public int YearEnd { get; set; }

		public String IssueStart { get; set; }

		public String IssueEnd { get; set; }

		public DateTime UpdateDate { get; set; }

		public PublisherModel Publisher { get; set; }

		public IEnumerable<IssueModel> Issues { get; set; }
	}
}
