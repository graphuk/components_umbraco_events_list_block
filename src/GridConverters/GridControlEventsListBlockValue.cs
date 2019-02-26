using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Values;

namespace Graph.Components.EventsListBlock
{
	public class GridControlEventsListBlockValue : GridControlValueBase
	{
		public GridControlEventsListDataSourceItem[] EventsListDataSources { get; }

		public GridControlEventsListBlockValue(GridControl control, JToken obj) : base(control, obj as JObject)
		{
			EventsListDataSources = new GridControlEventsListDataSourceItem[] { };
			if (obj != null)
			{
				var EventsListDataSource = JsonConvert.DeserializeObject<GridControlEventsListDataSource>(obj.ToString());
				if (EventsListDataSource != null)
				{
					EventsListDataSources = EventsListDataSource.DataSources;
				}
			}
		}

		public static GridControlEventsListBlockValue Parse(GridControl control, JToken obj)
		{
			return obj != null ? new GridControlEventsListBlockValue(control, obj) : null;
		}
	}
}
