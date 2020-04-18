using System;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.User
{
	public interface IPurchaseCommandRepository
	{
		Task<UserPurchaseModel> CreateNewPurchase(UserObject parent, String description, DateTime purchaseDate, decimal price);

		Task<UserPurchaseModel.PurchaseIssueModel> AddIssueToPurchase(UserObject parent, int purchaseId, int issueId);
	}
}
 