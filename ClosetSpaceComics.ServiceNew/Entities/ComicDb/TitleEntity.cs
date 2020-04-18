using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClosetSpaceComics.Service.ComicDb
{
	[Table("Titles")]
	public class TitleEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public String Name { get; set; }

		public String SeoFriendlyName { get; set; }

		public int YearStart { get; set; }

		public int? YearEnd { get; set; }

		public String IssueBegin { get; set; }

		public String IssueEnd { get; set; }

		public DateTime? LastUpdate { get; set; }

		public String LoneStarId { get; set; }

		public int? LocalTitleId { get; set; }

		public virtual ICollection<IssueEntity> Issues { get; set; }

//		[ForeignKey("Publisher")]
		public int PublisherId { get; set; }
		public virtual PublisherEntity Publisher { get; set; }
	}
}