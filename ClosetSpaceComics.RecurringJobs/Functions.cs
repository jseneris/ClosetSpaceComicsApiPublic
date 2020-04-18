using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service.Repositories;
using Microsoft.Azure.WebJobs;

namespace ClosetSpaceComics.RecurringJobs
{
	public class Functions
	{
		// This function will get triggered/executed when a new message is written 
		// on an Azure Queue called queue.
//		public static async Task ProcessQueueMessage([TimerTrigger("0 */10 * * * *")]TimerInfo timer)
		public static async void ProcessQueueMessage([TimerTrigger("0 0 12 1/3 * *")]TimerInfo timer)
		{
			var issueCommandRepository = new IssueCommandRepository();
			var issueQueryRepository = new IssueQueryRepository();
			var issueContext = new IssueContext(issueQueryRepository, issueCommandRepository);
			var issueFactory = new IssueFactory(issueContext);

			var titleCommandRepository = new TitleCommandRepository();
			var titleQueryRepository = new TitleQueryRepository();
			var titleContext = new TitleContext(titleQueryRepository, titleCommandRepository);
			var titleFactory = new TitleFactory(titleContext);

			var publisherQueryRepository = new PublisherQueryRepository();
			var publisherContext = new PublisherContext(publisherQueryRepository);
			var publisherFactory = new PublisherFactory(publisherContext);

			var catalogContext = new CatalogContext(publisherFactory, titleFactory, issueFactory);

			var Catalog = new CatalogObject(catalogContext);

			await Catalog.Commands.NewReleases(0);

			var end = string.Empty;

		}
	}
}
