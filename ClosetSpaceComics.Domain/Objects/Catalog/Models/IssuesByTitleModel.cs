using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.Catalog
{
	public class IssuesByTitleModel
	{
		public IEnumerable<Title> Titles { get; set; }


		public class Title
		{
			public int Id { get; set; }

			public String Name { get; set; }

			public String SeoFriendlyName { get; set; }

			public String ImageUrl { get; set; }

			public IEnumerable<Issue> Issues { get; set; }
		}

		public class Issue {
			public int Id { get; set; }

			public String ImageUrl { get; set; }

			public String IssueNum { get; set; }

			public String Title { get; set; }

			public String Publisher { get; set; }

			public String Description { get; set; }

			public Decimal CoverPrice { get; set; }
		}
	}
}
