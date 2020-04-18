using ClosetSpaceComics.Service.ComicDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClosetSpaceComics.Service.User
{
	[Table("PurchaseItems")]
	public class PurchaseItemEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }

		public int? LocalTitleId { get; set; }

		public int? LocalIssueId { get; set; }

		[ForeignKey("Title")]
		public int? TitleId { get; set; }
		public virtual TitleEntity Title { get; set; }

		public int? IssueId { get; set; }
		public virtual IssueEntity Issue { get; set; }

		public string IssueNumber { get; set; }

		public int? IssueNumberOrdinal { get; set; }

		//public ComicCondition Condition { get; set; }
		public int Condition { get; set; }

		public int Order { get; set; }

		public String Notes { get; set; }

		public GradingConditionEnum? GradingService { get; set; }

		public GradingConditionEnum? GradedCondition { get; set; }

		public GradingPaperQualityEnum? PaperQuality { get; set; }

		public String CertificateNumber { get; set; }

		public virtual ICollection<PhotoEntity> Photos { get; set; }

		[NotMapped]
		public IEnumerable<String> PicutureUrls { get; set; }

		[ForeignKey("Purchase")]
		public int PurchaseId { get; set; }
		public virtual PurchaseEntity Purchase { get; set; }

		[ForeignKey("Box")]
		public int BoxId { get; set; }
		public virtual BoxEntity Box { get; set; }
	}
}
