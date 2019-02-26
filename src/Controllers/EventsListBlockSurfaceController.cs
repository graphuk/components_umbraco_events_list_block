using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Graph.Components.EventsListBlock
{
	public class EventsListBlockSurfaceController : SurfaceController
	{
		public ActionResult EventsList(GridControlEventsListDataSourceItem[] dataSources, int page = 1)
		{
			var allEvents = new List<EventsListItem>();
			var totalEventsCount = 0;
			if (dataSources != null && dataSources.Any())
			{
				foreach (var dataSourceItem in dataSources)
				{
					var dataSourceContent = new UmbracoHelper(UmbracoContext.Current).TypedContent(dataSourceItem.Id);

					allEvents.AddRange(dataSourceContent.Descendants(EventsListBlockConfig.EventPageAlias)
						.Where(x => x.IsVisible())
						.Select(x => new EventsListItem
						{
							Title = x.GetPropertyValue<string>(EventsListBlockConfig.Title),
							Description = x.GetPropertyValue<string>(EventsListBlockConfig.Summary),
							Url = x.Url,
							StartDate = x.GetPropertyValue<DateTime>(EventsListBlockConfig.StartDate),
							EndDate = x.GetPropertyValue<DateTime>(EventsListBlockConfig.EndDate),
							Image = x.GetPropertyValue<IPublishedContent>(EventsListBlockConfig.Image)?.Url,
							Location = x.GetPropertyValue<string>(EventsListBlockConfig.Location)
						}));
				}

				totalEventsCount = allEvents.Count;
			}

			var events = allEvents.OrderByDescending(x => x.StartDate)
				.Skip((page - 1) * EventsListBlockConfig.PageSize)
				.Take(EventsListBlockConfig.PageSize);

			return View("/App_Plugins/EventsListBlock/Views/EventsList.cshtml", new EventsListBlockModel
			{
				Events = events,
				PageNavigationModel = new PageNavigationModel(page, totalEventsCount, EventsListBlockConfig.PageSize)
			});
		}
	}
}
