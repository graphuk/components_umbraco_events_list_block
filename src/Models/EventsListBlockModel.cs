using System.Collections.Generic;

namespace Graph.Components.EventsListBlock
{
	public class EventsListBlockModel
	{
		public IEnumerable<EventsListItem> Events { get; set; }
		public PageNavigationModel PageNavigationModel { get; set; }
	}
}
