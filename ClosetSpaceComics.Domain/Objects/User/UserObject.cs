using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.User
{
	public class UserObject
	{
		public UserObject(string fireBaseId, IUserContext userContext)
		{
			FireBaseId = fireBaseId;

			Context = userContext;

//			UserQueryRepository = userQueryRepository;

			Queries = new UserObjectQueriesObject(this);

			Commands = new UserObjectCommandObject(this);
		}

		private IUserContext Context { get; set; }

		//private IUserQueryRepository UserQueryRepository { get; set; }

		public UserObjectQueriesObject Queries { get; set; }

		public UserObjectCommandObject Commands { get; set; }

		public String FireBaseId { get; set; }

		public int Id { get; set; }

		public String UserName { get; set; }

		//public IEnumerable<PurchaseModel> Purchases { get; set; }

		//public IEnumerable<LocationModel> Locations { get; set; }

		//#region Purchases
		//private Purchases _purchases;

		//public Purchases Purchases
		//{
		//	get
		//	{
		//		if (_purchases != null)
		//			return _purchases;

		//		return (_purchases = Context.PurchasesFactory.Create(this));
		//	}
		//}
		//#endregion

		#region Locations
		private LocationObject _locations;

		public LocationObject Locations
		{
			get
			{
				if (_locations != null)
					return _locations;

				return (_locations = Context.LocationFactory.Create(this));
			}
		}
		#endregion

		#region Purchases
		private PurchaseObject _purchases;

		public PurchaseObject Purchases
		{
			get
			{
				if (_purchases != null)
					return _purchases;

				return (_purchases = Context.PurchaseFactory.Create(this));
			}
		}
		#endregion

		public class UserObjectQueriesObject
		{
			public UserObjectQueriesObject(UserObject parent)
			{
				Parent = parent;
			}

			protected UserObject Parent;

			public async Task<UserLocationListModel> GetLocations()
			{
				var id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Locations.Context.QueryRepository.GetUserLocations(id);

				return retval;
			}

			public async Task<IEnumerable<BoxIssueModel>> GetBoxItems(int locationId, int boxId)
			{
				var id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Locations.Context.QueryRepository.GetBoxItems(id, locationId, boxId);

				return retval;
			}

			public async Task<IEnumerable<UserPurchaseModel>> GetPurchases(int? page)
			{
				var id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Purchases.Context.QueryRepository.GetPurchases(id, page, 20);

				return retval;
			}

			public async Task<IEnumerable<String>> GetCollectionTitles()
			{
				var id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Locations.Context.QueryRepository.GetCollectionTitles(id);

				return retval;
			}

			public async Task<IEnumerable<String>> GetCollectionByTitle(String seoFriendlyTitleName)
			{
				var id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Locations.Context.QueryRepository.GetCollectionByTitle(id, seoFriendlyTitleName);

				return retval;
			}
		}

		public class UserObjectCommandObject
		{
			public UserObjectCommandObject(UserObject parent)
			{
				Parent = parent;
			}

			protected UserObject Parent;

			public async Task<UserPurchaseModel> CreateNewPurchase(string description, DateTime purchaseDate, decimal price)
			{
				Parent.Id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var retval = await Parent.Purchases.Context.CommandRepository.CreateNewPurchase(Parent, description, purchaseDate, price);

				return retval;
			}

			public async Task<UserPurchaseModel.PurchaseIssueModel> AddIssueToPurchase(int purchaseId, int issueId)
			{
				Parent.Id = await Parent.Context.UserQueryRepository.GetUserId(Parent.FireBaseId);
				var locations = await Parent.Locations.Context.QueryRepository.GetUserLocations(Parent.Id);
				var retval = await Parent.Purchases.Context.CommandRepository.AddIssueToPurchase(Parent, purchaseId, issueId);

				return retval;
			}
		}
	}
}
