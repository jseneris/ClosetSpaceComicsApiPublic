using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClosetSpaceComicsAPI;
using ClosetSpaceComicsAPI.Controllers;
using ClosetSpaceComics.Domain.Catalog;

namespace ClosetSpaceComicsAPI.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange

			CatalogController controller = new CatalogController(new CatalogContext(null, null, null));

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}
