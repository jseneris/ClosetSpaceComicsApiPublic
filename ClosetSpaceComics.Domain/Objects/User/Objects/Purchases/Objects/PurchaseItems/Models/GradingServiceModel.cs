using System;

namespace ClosetSpaceComics.Domain.User
{
	public class GradingServiceModel
	{
		public GradingConditionEnum GradingService { get; set; }

		public GradingConditionEnum Condition { get; set; }

		public GradingPaperQualityEnum PaperQuality { get; set; }

		public String CertificateNumber { get; set; }
	}
}
