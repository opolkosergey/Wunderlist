var app = angular.module('app', ['ui.router', 'angular-loading-bar']);
    
app.config([
'$stateProvider',
'$urlRouterProvider',
function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('home', {
          url: '/home',
          templateUrl: '/angular/views/home.html',
          controller: 'MainCtrl'
      });

    $urlRouterProvider.otherwise('home');
}]);

app.controller('MainCtrl', [
'$scope', 'lists','$http',
function ($scope, lists, $http) {
    $scope.lists = lists.lists;
    $scope.addlist = function () {
        if (!$scope.title || $scope.title === '') { return; }
        alert(11);
        $http.post('/api/List/', {
            Name: $scope.title
        })
            .then(function successCallback(response) {
            $scope.lists.push({
                title: $scope.title,
                id: response.id
            });
            $scope.title = '';
            $("#close").click();
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });

        
    };
    $scope.displayItems = function(id) {
        alert(id);
    };

}]);

app.factory('lists', [function () {
    var o = {
        lists: [
          { title: 'list 1', upvotes: 5 },
  { title: 'list 2', upvotes: 2 },
  { title: 'list 3', upvotes: 15 },
  { title: 'list 4', upvotes: 9 },
  { title: 'list 5', upvotes: 4 }]
    };
    return o;
}]);