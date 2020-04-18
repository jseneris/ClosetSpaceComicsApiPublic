
namespace ClosetSpaceComics.Domain.Catalog
{
	public class TitleObject
	{
		public TitleObject(CatalogObject owner, ITitleContext context)
		{
			Owner = owner;
			Context = context;
		}

		protected CatalogObject Owner { get; private set; }

		public ITitleContext Context { get; private set; }
	}
}
