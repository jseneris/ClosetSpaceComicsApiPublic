using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.Catalog
{
	public interface ITitleCommandRepository
	{
		Task UpdateTitleSeo();
	}
}
