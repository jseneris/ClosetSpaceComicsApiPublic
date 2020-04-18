using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ClosetSpaceComics.Domain.Catalog;

namespace ClosetSpaceComicsAPI.Controllers
{
	[RoutePrefix("api/catalog")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class CatalogController : ApiController
	{
		public CatalogController(ICatalogContext catalogContext)
		{
			Catalog = new CatalogObject(catalogContext);
		}

		CatalogObject Catalog;

		[HttpGet]
		[Route("issues")]
		public async Task<IHttpActionResult> SearchByDate(string date)
		{
			DateTime origDate;
			DateTime endDate;
			if (DateTime.TryParse(date, out origDate))
			{
				try
				{
					endDate = origDate.AddDays(7);
					var retval = await Catalog.Queries.GetByDateAsync(origDate, endDate);
					return Ok(retval);
				}
				catch(Exception e)
				{
					return BadRequest(e.Message);
				}
			}

			return BadRequest("bad date string");
		}

		[HttpGet]
		[Route("issues")]
		public async Task<IHttpActionResult> SearchByTitle(string title)
		{
			if (!String.IsNullOrEmpty(title))
			{
				try
				{
					var retval = await Catalog.Queries.SearchByTitle(title);
					return Ok(retval);
				}
				catch (Exception e)
				{
					return BadRequest(e.Message);
				}
			}

			return BadRequest("empty search string");
		}

		[HttpGet]
		[Route("newrelease")]
		public async Task<IHttpActionResult> NewReleases(int page = 0)
		{
			await Catalog.Commands.NewReleases(page);

			return Ok();
		}

		[HttpGet]
		[Route("newissues/{titleId}")]
		public async Task<IHttpActionResult> FillIssues(int titleId)
		{
			await Catalog.Commands.FillIssues(titleId);

			return Ok();
		}
	}
}
