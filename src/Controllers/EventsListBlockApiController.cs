using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace Graph.Components.EventsListBlock
{
	[PluginController("EventsListBlock")]
	public class EventsListBlockApiController : UmbracoAuthorizedJsonController
	{
		public EditorConfig GetEditorConfig()
		{
			return new EditorConfig
			{
				EventsListAlias = EventsListBlockConfig.EventsListPageAlias
			};
		}
	}

	public class EditorConfig
	{
		public string EventsListAlias { get; set; }
	}
}
