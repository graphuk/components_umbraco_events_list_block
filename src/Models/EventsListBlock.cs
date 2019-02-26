using UmbracoGridConfigLoader.Attributes;
using UmbracoGridConfigLoader.Models;

namespace Graph.Components.EventsListBlock
{
	public class EventsListBlock : IGridConfigLoader
	{
		[GridLayoutProperty(Label = "Events List Block", AllowedEditors = new[] { "EventsListBlock" }, MaxItems = 1)]
		public IGridLayout Layout { get; set; }
	}
}
