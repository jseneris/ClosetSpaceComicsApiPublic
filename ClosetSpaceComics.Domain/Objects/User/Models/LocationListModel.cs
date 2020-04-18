using System;
using System.Collections.Generic;

namespace ClosetSpaceComics.Domain.User
{
	public class UserLocationListModel
	{
		public IEnumerable<Location> Locations { get; set; }

		public class Location
		{
			public int Id { get; set; }

			public String Name { get; set; }

			public String ImageUrl { get; set; }

			public IEnumerable<Box> Boxes { get; set; }
		}

		public class Box
		{
			public int Id { get; set; }

			public String Name { get; set; }

			public String ImageUrl { get; set; }
		}
	}
}
