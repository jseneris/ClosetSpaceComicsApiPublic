using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosetSpaceComics.Domain.User;
using ClosetSpaceComics.Service;
using ClosetSpaceComics.Service.User;

namespace ClosetSpaceComics.Service.Repositories
{
	public class UserQueryRepository : IUserQueryRepository
	{
		public async Task<int> GetUserId(string fireBaseId)
		{
			int retval = 0;

			if (fireBaseId != null)
			{
				using (var dataContext = new AppDbContext())
				{
					var user = dataContext.Users.Where(x => x.FirebaseId == fireBaseId).FirstOrDefault();

					if (user != null)
					{
						retval = user.Id;
					}
					else
					{
						var newUser = new UserEntity
						{
							FirebaseId = fireBaseId
						};

						dataContext.Users.Add(newUser);
						dataContext.SaveChanges();

						var newLocation = new LocationEntity
						{
							UserId = newUser.Id,
							Name = "Home",
							Boxes = new List<BoxEntity> { new BoxEntity
							{
								Name = "Home"
							} }
						};

						dataContext.Locations.Add(newLocation);
						dataContext.SaveChanges();

						retval = newUser.Id;
					}
				}
			}

			return retval;
		}
	}
}
