using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("Boxes")]
	public class BoxEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Name { get; set; }

		public int Order { get; set; }

		[ForeignKey("Location")]
		public int LocationId { get; set; }
		public virtual LocationEntity Location { get; set; }

		public virtual List<PurchaseItemEntity> Items { get; set; }
	}
}
