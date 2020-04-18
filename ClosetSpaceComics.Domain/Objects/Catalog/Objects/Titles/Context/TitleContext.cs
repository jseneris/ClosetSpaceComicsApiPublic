
namespace ClosetSpaceComics.Domain.Catalog
{
	public class TitleContext : ITitleContext
	{
		public TitleContext(
			ITitleQueryRepository queryRepository,
			ITitleCommandRepository commandRepository)
		{
			QueryRepository = queryRepository;
			CommandRepository = commandRepository;
		}

		public ITitleQueryRepository QueryRepository { get; private set; }

		public ITitleCommandRepository CommandRepository { get; private set; }
	}
}
