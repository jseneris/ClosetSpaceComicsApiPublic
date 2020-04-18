using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("Locations")]
	public class LocationEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Name { get; set; }

		public int Order { get; set; }

		public virtual ICollection<BoxEntity> Boxes { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public virtual UserEntity User { get; set; }
	}
}