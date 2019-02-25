angular.module("umbraco").controller("EventsListBlock.Controller", function ($scope, dialogService, eventsListBlockConfig) {

	function Item() {
		this.dataSources = [];
	}

	$scope.control.value = $scope.control.value || new Item();
	$scope.config = {};

	eventsListBlockConfig.getEditorConfig()
		.then(function (json) {
			$scope.config = json.data;
		});

	$scope.control.openOverlay = function () {
		dialogService.treePicker({
			filterCssClass: 'not-allowed not-published',
			filter: $scope.config.EventsListAlias,
			treeAlias: 'content',
			section: 'content',
			multiPicker: true,
			callback: function (data) {
				if (data) {
					$scope.control.value.dataSources = data;
				}
			}
		});
	}

	$scope.remove = function (index) {
		$scope.control.value.dataSources.splice(index, 1);
	};
});
