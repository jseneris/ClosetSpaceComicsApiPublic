using ClosetSpaceComics.Domain.User;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClosetSpaceComicsAPI.Controllers
{
	[RoutePrefix("api/user")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class UserController : ApiController
	{
		public UserController(IUserContext userContext)
		{
			UserContext = userContext;
		}

		IUserContext UserContext;

		[HttpGet]
		[Route("collection")]
		public async Task<IHttpActionResult> GetCollection()
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Queries.GetLocations();

				return Ok(retval);

			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("collection/location/{locationId}/box/{boxId}")]
		public async Task<IHttpActionResult> GetBox(int locationId, int boxId)
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Queries.GetBoxItems(locationId, boxId);

				return Ok(retval);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("purchases")]
		public async Task<IHttpActionResult> GetPurchases(int? page = 1)
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Queries.GetPurchases(page);

				return Ok(retval);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		[Route("purchases")]
		public async Task<IHttpActionResult> CreateNewPurchase(UserPurchaseModel model)
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				DateTime purchaseDate;
				if (!DateTime.TryParse(model.PurchaseDate, out purchaseDate))
				{
					throw new Exception("purchase date required.");
				}

				Decimal price;
				if (!Decimal.TryParse(model.Price.Replace("$",""), out price))
				{
					throw new Exception("price required.");
				}

				var retval = await comicUser.Commands.CreateNewPurchase(model.Description, purchaseDate, price);

				return Ok(retval);
			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}

		}

		[HttpPost]
		[Route("purchase/{id}/{issueId}")]
		public async Task<IHttpActionResult> AddBookToPurchase(int id, int issueId)
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Commands.AddIssueToPurchase(id, issueId);

				return Ok(retval);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("collectiontitles")]
		public async Task<IHttpActionResult> CollectionTitles()
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Queries.GetCollectionTitles();

				return Ok(retval);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet]
		[Route("collectionbytitle")]
		public async Task<IHttpActionResult> CollectionByTitle(String name)
		{
			try
			{
				var userId = Request.Headers.FirstOrDefault(x => x.Key.ToLowerInvariant() == "userid").Value.First();
				var comicUser = new UserObject(userId, UserContext);

				var retval = await comicUser.Queries.GetCollectionByTitle(name);

				return Ok(retval);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

	}
}