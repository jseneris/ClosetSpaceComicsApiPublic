using System;

namespace ClosetSpaceComics.Domain.User
{
	public class BoxModel
	{
		public int Id { get; set; }

		public String Name { get; set; }

		public int Order { get; set; }

		public LocationModel Location { get; set; }
	}
}
