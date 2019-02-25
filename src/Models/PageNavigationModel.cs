using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Components.EventsListBlock
{
	public class PageNavigationModel
	{
		public int CurrentPage { get; }
		public int ItemsAmount { get; }
		public int PageSize { get; }
		public bool HasNextPage { get; }
		public bool HasPrevPage { get; }
		public IEnumerable<PageItem> Pages { get; }

		public PageNavigationModel(int currentPage, int itemsAmount, int pageSize)
		{
			var pageCount = (int)Math.Ceiling((decimal)itemsAmount / EventsListBlockConfig.PageSize);

			CurrentPage = currentPage;
			ItemsAmount = itemsAmount;
			PageSize = pageSize;
			Pages = GetPageRange(currentPage, pageCount);
			HasNextPage = false;
			HasPrevPage = false;
			if (currentPage < Pages.Count())
			{
				HasNextPage = true;
			}
			if (currentPage > 1)
			{
				HasPrevPage = true;
			}
		}

		private IEnumerable<PageItem> GetPageRange(int currentPage, int pageCount)
		{
			var pageRange = new List<PageItem>();
			if (pageCount <= 8)
			{
				for (var i = 1; i <= pageCount; i++)
				{
					pageRange.Add(new PageItem { Page = i.ToString(), PageId = i });
				}
				return pageRange;
			}

			if (currentPage <= 5)
			{

				for (var i = 1; i <= (currentPage < 5 ? 5 : currentPage + 1); i++)
				{
					pageRange.Add(new PageItem { Page = i.ToString(), PageId = i });
				}

				pageRange.Add(new PageItem { Page = "…" });
				pageRange.Add(new PageItem
				{
					Page = pageCount.ToString(),
					PageId = pageCount
				});

			}
			else if (pageCount - currentPage < 6)
			{
				pageRange.Add(new PageItem { Page = "1", PageId = 1 });
				pageRange.Add(new PageItem { Page = "…" });
				for (var i = currentPage == pageCount - 5 ? currentPage - 1 : pageCount - 5; i <= pageCount; i++)
				{
					pageRange.Add(new PageItem
					{
						Page = i.ToString(),
						PageId = i
					});
				}
			}
			else
			{
				pageRange.Add(new PageItem { Page = "1", PageId = 1 });
				pageRange.Add(new PageItem { Page = "…" });
				for (var i = currentPage - 2; i <= currentPage + 2; i++)
				{
					pageRange.Add(new PageItem
					{
						Page = i.ToString(),
						PageId = i
					});
				}
				pageRange.Add(new PageItem { Page = "…" });
				pageRange.Add(new PageItem
				{
					Page = pageCount.ToString(),
					PageId = pageCount
				});
			}

			return pageRange;
		}
	}
}
