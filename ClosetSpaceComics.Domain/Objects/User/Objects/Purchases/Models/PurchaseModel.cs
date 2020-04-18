using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.User
{
	public class PurchaseModel
	{
		public int Id { get; set; }

		public String Description { get; set; }

		public DateTime PurchaseDate { get; set; }

		public Decimal Price { get; set; }

		public IEnumerable<PurchaseItemModel> Items { get; set; }
	}
}
