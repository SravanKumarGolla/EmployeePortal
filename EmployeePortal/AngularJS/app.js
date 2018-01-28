var empApp = angular.module('EmployeeApp', ['ui.router']);

empApp.config(function ($stateProvider, $locationProvider, $urlRouterProvider) {


    $stateProvider.state('Create',
        {
            url: '/Create',
            templateUrl: '/AngularJS/Views/Create.html'
        })
    .state('Update',
        {
            url: '/Update?id',
            templateUrl: '/AngularJS/Views/Update.html',
            controller: function ($scope, $stateParams) {
                $scope.Id = $stateParams.id;
                console.log('params')
                console.log($scope.Id)
                console.log($scope.EmployeeDetails);
            }
        })
      .state('Delete',
        {
            url: '/Delete',
            templateUrl: '/AngularJS/Views/Delete.html'
        })
      .state('Read',
        {
            url: '/Details',
            templateUrl: '/AngularJS/Views/Details.html'
        });

    $urlRouterProvider.otherwise('/Create');

    $locationProvider.html5Mode({enabled : true,requireBase : false});
});
