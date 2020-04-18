using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.User
{
	public class UserPurchaseModel
	{
		public int Id { get; set; }

		public String Description { get; set; }

		public String PurchaseDate { get; set; }

		public String Price { get; set; }

		public int Size { get; set; }

		public String ImageUrl { get; set; }

		public IEnumerable<PurchaseIssueModel> Issues { get; set; }

		public class PurchaseIssueModel
		{
			public int Id { get; set; }

			public String ImageUrl { get; set; }
		}
	}
}
