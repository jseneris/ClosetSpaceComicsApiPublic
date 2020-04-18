using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClosetSpaceComics.Domain.Catalog
{
	public class CatalogObject
	{
		public CatalogObject(ICatalogContext context)
		{
			Context = context;

			Queries = new CatalogObjectQueriesObject(this);

			Commands = new CatalogObjectCommandObject(this);
		}

		private ICatalogContext Context { get; set; }

		public CatalogObjectQueriesObject Queries {get; set;}

		public CatalogObjectCommandObject Commands { get; set; }

		#region Publishers
		private PublisherObject _publishers;

		private PublisherObject Publishers
		{
			get
			{
				if (_publishers != null)
					return _publishers;

				return (_publishers = Context.PublisherFactory.Create(this));
			}
		}
		#endregion

		#region Titles
		private TitleObject _titles;

		private TitleObject Titles
		{
			get
			{
				if (_titles != null)
					return _titles;

				return (_titles = Context.TitleFactory.Create(this));
			}
		}
		#endregion

		#region Titles
		private IssueObject _issues;

		private IssueObject Issues
		{
			get
			{
				if (_issues != null)
					return _issues;

				return (_issues = Context.IssueFactory.Create(this));
			}
		}
		#endregion


		public class CatalogObjectQueriesObject
		{
			public CatalogObjectQueriesObject(CatalogObject parent)
			{
				Parent = parent;
			}

			protected CatalogObject Parent;

			public async Task<IssuesByDateModel> GetByDateAsync(DateTime startTime, DateTime endTime)
			{
				var retval = await Parent.Issues.Context.QueryRepository.GetByDateAsync(startTime, endTime);

				return retval;
			}

			public async Task<IssuesByTitleModel> SearchByTitle(String search)
			{
				var retval = await Parent.Issues.Context.QueryRepository.SearchByTitle(search);

				return retval;
			}
		}

		public class CatalogObjectCommandObject
		{
			public CatalogObjectCommandObject(CatalogObject parent)
			{
				Parent = parent;
			}

			protected CatalogObject Parent;

			public async Task NewReleases(int page = 0)
			{
				await Parent.Issues.Context.CommandRepository.GetLatest(page);
			}

			public async Task FillIssues(int titleId)
			{
				await Parent.Issues.Context.CommandRepository.FillIssues(titleId);
			}

			public async Task UpdateTitleSeo()
			{
				await Parent.Titles.Context.CommandRepository.UpdateTitleSeo();
			}
		}
	}

}
