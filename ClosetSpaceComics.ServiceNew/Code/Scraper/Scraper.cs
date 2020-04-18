using ClosetSpaceComics.Service.Code;
using ClosetSpaceComics.Service.ComicDb;
using ClosetSpaceComics.Service.Repositories;
using HtmlAgilityPack;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace ClosetSpaceComics.ServiceNew.Code.Scraper
{
	public class Scraper
	{
		private static String _baseUrl = ConfigurationManager.AppSettings["comicsUrl"];

		public static async Task ScrapeIssuePages(string url, string weekOf = "", bool newRelease = true)
		{
			PublisherCommandRepository publisherRepository = new PublisherCommandRepository();
			TitleCommandRepository titleRepository = new TitleCommandRepository();
			IssueCommandRepository issueRepository = new IssueCommandRepository();

			var webGet = new HtmlWeb();
			System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

			var document = webGet.Load(url);

			if (newRelease && string.IsNullOrEmpty(weekOf))
			{
				var titleNode = document.DocumentNode.SelectSingleNode("//title");
				if (titleNode != null && titleNode.InnerText != null)
				{
					weekOf = titleNode.InnerText.Replace("Comic Book New Releases ", "");
				}
			}

			var nextNode = document.DocumentNode.SelectSingleNode("//li[@class='next']");
			string nextLink;
			if (nextNode != null && nextNode.InnerHtml != null)
			{
				nextLink = _baseUrl + nextNode.FirstChild.Attributes["href"].Value.Replace("amp;", "");
				ScrapeIssuePages(nextLink, weekOf, newRelease);
			}

			string lastTitle = null, lastPublisher = null;
			int lastTitleID = 0, lastPublisherID = 0;

			var issueList = document.DocumentNode.SelectNodes("//li[@class='issue']");
			if (issueList != null)
			{
				foreach (HtmlNode issueNode in issueList)
				{
					string titleName = null;
					string issueNumber = null;
					string imageurl = null;
					string publishDate = null;
					string publisher = null;
					string description = null;
					decimal coverPrice = 0;

					var imageURLNode = issueNode.SelectSingleNode(".//a[@class='fancyboxthis']");
					if (imageURLNode != null && imageURLNode.Attributes["href"] != null)
					{
						imageurl = imageURLNode.Attributes["href"].Value;
					}


					var titleInfoNode = issueNode.SelectSingleNode(".//div[@class='title']");
					if (titleInfoNode != null)
					{
						//title = titleInfoNode.FirstChild.InnerText;
						//issue = titleInfoNode.FirstChild.NextSibling.NextSibling.InnerText.Replace("#", "");
						var titleNode = titleInfoNode.SelectSingleNode(".//a");
						if (titleNode != null)
						{
							titleName = titleNode.InnerText;
						}
						var numberNode = titleInfoNode.SelectSingleNode(".//strong");
						if (numberNode != null)
						{
							issueNumber = numberNode.InnerText.Replace("#", "");
						}
					}

					var publishInfoNode = issueNode.SelectSingleNode(".//div[@class='othercolright']");
					if (publishInfoNode != null)
					{

						foreach (var publishNode in publishInfoNode.SelectNodes(".//a"))
						{
							if (string.IsNullOrEmpty(publishDate))
							{
								publishDate = publishNode.InnerText;
							}
							publisher = publishNode.InnerText;
						}

						//no publish date info
						if (publishDate == publisher || newRelease)
						{
							publishDate = weekOf;
						}
					}

					try
					{
						DateTime publishDatetime = DateTime.Parse(publishDate);
					}
					catch (Exception e)
					{
						publishDate = DateTime.Now.ToString();
					}

					var descriptionInfoNode = issueNode.SelectSingleNode(".//div[@class='issuegrades']");
					if (descriptionInfoNode != null && descriptionInfoNode.NextSibling != null &&
						descriptionInfoNode.NextSibling.NextSibling != null)
					{
						description = descriptionInfoNode.NextSibling.NextSibling.InnerText;
						if (description != null && description.Contains("Cover price"))
						{
							string coverPriceString = "0";
							try
							{
								coverPriceString = description.Substring(description.LastIndexOf("Cover price")).Replace("Cover price", "").
									Replace(
										"$", "").TrimEnd(
											'\n', '\r', '.', '\t', ' ');
							}
							catch (FormatException e)
							{
								coverPriceString = "0";
							}
							if (!String.IsNullOrEmpty(coverPriceString))
							{
								try
								{
									coverPrice = decimal.Parse(coverPriceString);
								}
								catch (FormatException)
								{
									coverPrice = 0m;
								}
							}
						}
					}

					int publisherID = 0;
					if (publisher != lastPublisher)
					{
						publisherID = await publisherRepository.FindOrUpsertPublisher(publisher);
						lastPublisher = publisher;
						lastPublisherID = publisherID;
					}
					else
					{
						publisherID = lastPublisherID;
					}
					if (publisherID > 0)
					{

						TitleEntity title = null;
						if (titleName != lastTitle)
						{
							title = await titleRepository.FindOrUpsertTitle(titleName, publisherID);
							lastTitle = titleName;
							lastTitleID = title.Id;
						}
						else
						{
							title = new TitleEntity
							{
								Name = lastTitle,
								Id = lastTitleID,
								PublisherId = publisherID
							};
						}


						IssueEntity issue = new IssueEntity
						{
							TitleId = title.Id,
							SeoFriendlyName = issueNumber,
							ReleaseDate = DateTime.Parse(publishDate),
							CoverPrice = coverPrice,
							Description = description,
							ImageUrl = imageurl,
							CreatedDated = DateTime.UtcNow
						};

						await issueRepository.FindAndUpsertIssue(issue);
					}
				}
			}

		}

		public static async Task ScrapeTitlePages(int titleId, bool titlesOnly = true, bool fillTitle = false, int maxTitle = 0)
		{
			PublisherCommandRepository publisherRepository = new PublisherCommandRepository();
			TitleCommandRepository titleRepository = new TitleCommandRepository();
			IssueCommandRepository issueRepository = new IssueCommandRepository();

			var title = await titleRepository.FindTitleById(titleId);

			var url = String.Format(_baseUrl + "search?q={0}", title.Name);


			var webGet = new HtmlWeb();
			System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

			var document = webGet.Load(url);

			string lastPublisher = null;
			int lastPublisherID = 0;

			var resultsNode = document.DocumentNode.SelectSingleNode("//table[@class='results']");
			if (resultsNode != null)
			{
				var titleNodes = resultsNode.SelectNodes(".//tr");
				if (maxTitle == 0 || titleNodes.Count < maxTitle)
				{
					//foreach ( HtmlNode titleNode in resultsNode.SelectNodes( ".//tr" ) )
					foreach (HtmlNode titleNode in titleNodes)
					{

						TitleEntity newTitle = new TitleEntity();
						string issueRange = null;
						string publisher = null;
						string yearRange = null;


						var titleNameNode = titleNode.SelectSingleNode(".//td[@class='title']");
						if (titleNameNode != null)
						{
							var titleNameLink = titleNameNode.SelectSingleNode(".//a[@href]");
							if (titleNameLink != null)
							{
								newTitle.Name = titleNameLink.InnerText;
//								newTitle.SeoFriendlyName = CommonCode.GetSeoFriendlyName(titleNameLink.InnerText);
							}
						}

						var issueRangeNode = titleNode.SelectSingleNode(".//td[@class='issue']");
						if (issueRangeNode != null)
						{
							issueRange = issueRangeNode.InnerText;
							issueRange = issueRange.Replace("#", "");
							if (issueRange.Contains("-"))
							{
								newTitle.IssueBegin = issueRange.Substring(0, issueRange.IndexOf("-"));
								newTitle.IssueEnd = issueRange.Substring(issueRange.IndexOf("-") + 1);
							}
							else
							{
								newTitle.IssueBegin = issueRange;
								newTitle.IssueEnd = issueRange;
							}
						}

						var publisherNode = titleNode.SelectSingleNode(".//td[@class='publisher']");
						if (publisherNode != null)
						{
							var publisherLinkNode = publisherNode.SelectSingleNode(".//a");
							if (publisherLinkNode != null)
							{
								publisher = publisherLinkNode.InnerText.Trim();
								int publisherID = 0;
								if (publisher != lastPublisher)
								{
									publisherID = await publisherRepository.FindOrUpsertPublisher(publisher);
									if (publisherID <= 0)
									{
										continue;
									}
									lastPublisher = publisher;
									lastPublisherID = publisherID;
								}
								else
								{
									publisherID = lastPublisherID;
								}

								newTitle.PublisherId = publisherID;
							}
						}

						var yearRangeNode = titleNode.SelectSingleNode(".//td[@class='year']");
						if (yearRangeNode != null)
						{
							yearRange = yearRangeNode.InnerText;
							yearRange = yearRange.TrimStart('\n', '\r', '.', '\t', ' ').TrimEnd('\n', '\r', '.', '\t', ' ');
							if (yearRange.Contains("-"))
							{
								newTitle.YearStart = int.Parse(yearRange.Substring(0, yearRange.IndexOf("-")).TrimStart('\n', '\r', '.', '\t', ' ').TrimEnd('\n', '\r', '.', '\t', ' '));
								newTitle.YearEnd = int.Parse(yearRange.Substring(yearRange.IndexOf("-") + 1).TrimStart('\n', '\r', '.', '\t', ' ').TrimEnd('\n', '\r', '.', '\t', ' '));
							}
							else
							{
								newTitle.YearStart = int.Parse(yearRange);
								newTitle.YearEnd = int.Parse(yearRange);
							}
							//if (newTitle.YearStart.Length > 4)
							//{
							//	newTitle.YearStart = newTitle.YearStart.Substring(0, 4);
							//}
							//if (newTitle.YearEnd.Length > 4)
							//{
							//	newTitle.YearEnd = newTitle.YearEnd.Substring(0, 4);
							//}

							//try
							//{
							//	if (int.Parse(newTitle.YearEnd) < DateTime.Now.Year)
							//	{
							//		newTitle.Continuing = false;
							//	}
							//	else
							//	{
							//		newTitle.Continuing = true;
							//	}
							//}
							//catch (FormatException)
							//{
							//	newTitle.Continuing = false;
							//}

							//newTitle.Filled = false;
						}

						await titleRepository.FindOrUpsertTitle(newTitle.Name, newTitle.PublisherId);

						if (!titlesOnly)
						{
							var linkNode = titleNode.SelectSingleNode(".//a[@href]");
							var titleLink = _baseUrl + linkNode.Attributes["href"].Value;
							ScrapeIssuePages(titleLink, "", false);
						}
					}
				}
			}

			if (titlesOnly)
			{
				var nextNode = document.DocumentNode.SelectSingleNode("//li[@class='next']");
				string nextLink;
				if (nextNode != null && nextNode.InnerHtml != null)
				{
					nextLink = _baseUrl + nextNode.FirstChild.Attributes["href"].Value.Replace("amp;", "");
					//ScrapeTitlePages(nextLink);
				}
			}
		}

	}
}
