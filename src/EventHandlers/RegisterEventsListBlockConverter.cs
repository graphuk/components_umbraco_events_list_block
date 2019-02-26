using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Graph.Components.EventsListBlock;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.UI.JavaScript;

namespace Manchester.App_Plugins.EventsListBlock.EventHandlers
{
	public class RegisterEventsListBlockConverter : IApplicationEventHandler
	{
		private const string UmbracoUrls = "umbracoUrls";

		public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
		}

		public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			Skybrud.Umbraco.GridData.GridContext.Current.Converters.Add(new EventsListBlockGridConverter());
			ServerVariablesParser.Parsing += Parsing;
		}

		private static void Parsing(object sender, Dictionary<string, object> dictionary)
		{
			if (HttpContext.Current == null)
				throw new InvalidOperationException("HttpContext is null");

			if (dictionary.ContainsKey(UmbracoUrls))
			{
				var httpContextWrapper = new HttpContextWrapper(HttpContext.Current);
				var requestContext = new RequestContext(httpContextWrapper, new RouteData());
				var urlHelper = new UrlHelper(requestContext);
				var umbracoApiServiceBaseUrl = urlHelper.GetUmbracoApiServiceBaseUrl<EventsListBlockApiController>(controller => controller.GetEditorConfig());

				((Dictionary<string, object>)dictionary[UmbracoUrls])
					.Add("eventsListBlockApi", umbracoApiServiceBaseUrl);
			}
		}
	}
}
