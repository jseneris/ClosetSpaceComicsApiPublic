using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.ComicDb
{
	[Table("Publishers")]
	public class PublisherEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Name { get; set; }

		public String SeoFriendlyName { get; set; }

		public int? LocalId { get; set; }

		public String ImageName { get; set; }

		public String DisplayOrder { get; set; }

		public virtual ICollection<TitleEntity> Titles { get; set; }
	}
}