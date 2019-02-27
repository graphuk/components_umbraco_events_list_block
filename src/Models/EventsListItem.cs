using System;

namespace Graph.Components.EventsListBlock
{
	public class EventsListItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Image { get; set; }
		public string Location { get; set; }
		public string Url { get; set; }
	}
}
