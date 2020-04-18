using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClosetSpaceComics.Service.ComicDb
{
	[Table("Issues")]
	public class IssueEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String SeoFriendlyName { get; set; }

		public int IssueNumberOrdinal { get; set; }

		public String Description { get; set; }

		public decimal CoverPrice { get; set; }

		public DateTime? ReleaseDate { get; set; }

		public String ImageUrl { get; set; }

		//public int? ParentId { get; set; }

//		[ForeignKey("Title")]
		public int TitleId { get; set; }
		public virtual TitleEntity Title { get; set; }

		public DateTime CreatedDated { get; set; }

	}
}