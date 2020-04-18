
namespace ClosetSpaceComics.Domain.Catalog
{
	public class TitleFactory : ITitleFactory
	{
		public TitleFactory(ITitleContext context)
		{
			Context = context;
		}

		private ITitleContext Context { get; set; }

		public TitleObject Create(CatalogObject catalog)
		{
			return new TitleObject(catalog, Context);
		}
	}
}
