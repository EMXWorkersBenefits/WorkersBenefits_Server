(function () {
	// create module
	// will use ["ng-router"] when we implement router
	var app = angular.module('MyApp', ['ngRoute']);

	//create controller
	// here, $scope is used to share data between view and controller
	app.controller('HomeController', function ($scope) {
		$scope.Message = "Welcome angular js application";
	});

})();