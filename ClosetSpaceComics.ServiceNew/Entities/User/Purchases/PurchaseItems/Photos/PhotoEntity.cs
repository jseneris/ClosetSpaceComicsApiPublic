using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("Photos")]
	public class PhotoEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Name { get; set; }

		[ForeignKey("PurchaseItem")]
		public int PurchaseItemId { get; set; }
		public virtual PurchaseItemEntity PurchaseItem { get; set; }
	}
}
