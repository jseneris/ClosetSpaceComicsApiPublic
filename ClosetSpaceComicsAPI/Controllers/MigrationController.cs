using ClosetSpaceComics.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace ClosetSpaceComicsAPI.Controllers
{
	[RoutePrefix("api/migrations")]
	public class MigrationController : ApiController
	{
		public MigrationController(IMigrationRepository migrationRepository)
		{
			MigrationRepository = migrationRepository;
		}

		IMigrationRepository MigrationRepository;


		[HttpGet]
		[Route("location")]
		public async Task<IHttpActionResult> Locations()
		{
			MigrationRepository.MigrateLocations();

			return Ok();
		}

		[HttpGet]
		[Route("boxes")]
		public async Task<IHttpActionResult> Boxes()
		{
			MigrationRepository.MigrateBoxes();

			return Ok();
		}

		[HttpGet]
		[Route("publishers")]
		public async Task<IHttpActionResult> Publishers()
		{
			MigrationRepository.MigratePublishers();

			return Ok();
		}

		[HttpGet]
		[Route("titles")]
		public async Task<IHttpActionResult> Titles()
		{
			MigrationRepository.MigrateTitles();

			return Ok();
		}

		[HttpGet]
		[Route("issues")]
		public async Task<IHttpActionResult> Issues()
		{
			MigrationRepository.MigrateIssues();

			return Ok();
		}

		[HttpGet]
		[Route("localtitles")]
		public async Task<IHttpActionResult> LocalTitles()
		{
			MigrationRepository.MigrateLocalTitles();

			return Ok();
		}

		[HttpGet]
		[Route("photos")]
		public async Task<IHttpActionResult> Photos()
		{
			MigrationRepository.MigratePhotos();

			return Ok();
		}

		[HttpGet]
		[Route("purchases")]
		public async Task<IHttpActionResult> Purchases()
		{
			MigrationRepository.MigratePurchases();

			return Ok();
		}

		[HttpGet]
		[Route("purchaseitems")]
		public async Task<IHttpActionResult> PurchaseItems()
		{
			MigrationRepository.MigratePurchaseItems();

			return Ok();
		}

		[HttpGet]
		[Route("updatepurchaseitemdetails")]
		public async Task<IHttpActionResult> UpdatePurchaseItems()
		{
			MigrationRepository.UpdatePurchaseItems();

			return Ok();

		}

		[HttpGet]
		[Route("movephotostoazure")]
		public async Task<IHttpActionResult> MovePhotos()
		{
			MigrationRepository.UploadLocalPhotos();

			return Ok();

		}

	}
}