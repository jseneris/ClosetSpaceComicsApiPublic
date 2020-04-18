using System;
using System.Linq;
using System.Threading.Tasks;
using ClosetSpaceComics.Domain.User;
using ClosetSpaceComics.Service.User;

namespace ClosetSpaceComics.Service.Repositories
{
	public class PurchaseCommandRepository : IPurchaseCommandRepository
	{
		public async Task<UserPurchaseModel> CreateNewPurchase(UserObject parent, string description, DateTime purchaseDate, decimal price)
		{
			using (var dataContext = new AppDbContext())
			{
				var p = new PurchaseEntity
				{
					Description = description,
					PurchaseDate = purchaseDate,
					Price = price,
					UserId = parent.Id
				};

				var publishers = dataContext.Purchases.Add(p);

				var retval = dataContext.SaveChanges();

				return new UserPurchaseModel
				{
					Id = p.Id,
					Description = p.Description,
					PurchaseDate = p.PurchaseDate.ToString("MM/dd/yyyy"),
					Price = String.Format("{0:C2}", p.Price)
				};
			}
		}

			public async Task<UserPurchaseModel.PurchaseIssueModel> AddIssueToPurchase(UserObject parent, int purchaseId, int issueId)
		{
			using (var dataContext = new AppDbContext())
			{
				var issue = dataContext.Issues.Where(x => x.Id == issueId).First();
				var box = dataContext.Boxes.Where(x => x.Location.UserId == parent.Id && x.Location.Name == "Home" && x.Name == "Home").First();

				var pi = new PurchaseItemEntity
				{
					IssueId =  issueId,
					TitleId = issue.TitleId,
					IssueNumber = issue.SeoFriendlyName,
					IssueNumberOrdinal = issue.IssueNumberOrdinal,
					PurchaseId = purchaseId,
					BoxId = box.Id
				};

				var publishers = dataContext.PurchaseItems.Add(pi);

				var retval = dataContext.SaveChanges();

				return new UserPurchaseModel.PurchaseIssueModel
				{
					Id = pi.Id,
					ImageUrl = issue.ImageUrl
				};
			}
		}
	}
}
