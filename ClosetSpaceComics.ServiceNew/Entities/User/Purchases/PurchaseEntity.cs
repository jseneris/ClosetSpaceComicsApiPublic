using ClosetSpaceComics.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("Purchases")]
	public class PurchaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Description { get; set; }

		public DateTime PurchaseDate { get; set; }

		public Decimal Price { get; set; }

		public virtual ICollection<PurchaseItemEntity> Items { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public virtual UserEntity User { get; set; }
	}
}
