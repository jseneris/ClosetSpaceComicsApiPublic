using ClosetSpaceComics.Domain.Catalog;
using ClosetSpaceComics.Service.Repositories;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClosetSpaceComicsAPI.Controllers
{
	[RoutePrefix("api/utilities")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class UtilitiesController : ApiController
	{
		public UtilitiesController(ICatalogContext catalogContext)
		{
			Catalog = new CatalogObject(catalogContext);
		}

		CatalogObject Catalog;

		[HttpGet]
		[Route("pubseo")]
		public async Task<IHttpActionResult> PubSeo(int page = 0)
		{
			//await PublisherRepository.UpdatePubSeo();

			return Ok();
		}

		[HttpGet]
		[Route("titleseo")]
		public async Task<IHttpActionResult> TitleSeo()
		{
			await Catalog.Commands.UpdateTitleSeo();

			return Ok();
		}
	}
}