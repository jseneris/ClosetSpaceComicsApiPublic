using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("Users")]
	public class UserEntity
	{
		[Key]
		public int Id { get; private set; }

		public String UserName { get; set; }

		public String Password { get; set; }

		public String FirebaseId { get; set; }

		[NotMapped]
		public String ConfirmPassword { get; set; }

		public virtual ICollection<PurchaseEntity> Purchases { get; set; }

		public virtual ICollection<LocationEntity> Locations { get; set; }

	}
}
