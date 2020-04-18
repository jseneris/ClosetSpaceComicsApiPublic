using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Service.Repositories
{
	public interface IMigrationRepository
	{
		Task MigrateLocations();

		Task MigrateBoxes();

		Task MigratePublishers();

		Task MigrateTitles();

		Task MigrateIssues();

		Task MigrateLocalTitles();

		Task MigratePurchases();

		Task MigratePurchaseItems();

		Task MigratePhotos();

		Task UpdatePurchaseItems();

		Task UploadLocalPhotos();

	}
}
