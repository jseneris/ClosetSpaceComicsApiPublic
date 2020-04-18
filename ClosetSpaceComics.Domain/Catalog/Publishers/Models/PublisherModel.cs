using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.Catalog
{
	public class PublisherModel
	{
		public int Id { get; set; }

		public String Name { get; set; }

		public IEnumerable<TitleModel> Titles { get; set; }
	}
}
