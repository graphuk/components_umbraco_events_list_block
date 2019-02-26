(function () {
	function eventsListBlockConfig($q, $http, umbRequestHelper) {
		return {
			getEditorConfig() {
				return $http.get(umbRequestHelper.getApiUrl('eventsListBlockApi', 'GetEditorConfig'));
			}
		};
	}

	angular.module('umbraco.resources').factory('eventsListBlockConfig', eventsListBlockConfig);
}());
