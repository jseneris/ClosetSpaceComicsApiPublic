using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.User
{
	public class LocationModel
	{
		public int Id { get; set; }

		public String Name { get; set; }

		public IEnumerable<BoxModel> Boxes { get; set; }
	}
}
