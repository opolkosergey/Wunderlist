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
'$scope', 'lists','$http','buttons','todoitems',
function ($scope, lists, $http, buttons,todoitems) {
    $scope.lists = lists.lists;
    $scope.buttons = buttons.buttons;
    $scope.todoitems = todoitems.todoitems;
    $scope.getPage = function (idList, page, flag) {
        $http.get('/api/List?id=' + idList + '&page=' + page + '&isNeededPagesCount=' + flag)
            .then(function (response) {
                $scope.todoitems = [];
                if (flag === true) {
                    $scope.buttons = [];
                    var c = response.data[0];
                    if (c > 1) {
                        for (var i = 0; i < c; i++) {
                            $scope.buttons.push({ no: i + 1 });
                        }
                    } 
                    response.data.splice(0, 1);
                }
                $scope.todoitems = response.data;
                $('.ui.pagination.menu a').removeClass('active');
                $("#button_" + page).addClass("active");
            });
    }
    $scope.getPage(0, 1, true);

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
        $(".ui.secondary.vertical.pointing.menu a").removeClass("active");
        $("#list_" + id).addClass("active");
    };
    $scope.getPage = function(idList, page,flag) {
        $http.get('/api/List?id=' + idList + '&page=' + page + '&isNeededPagesCount=' + flag)
            .then(function(response) {
                $scope.todoitems = [];
                if (flag === true) {
                    $scope.buttons = [];
                    var c = response.data[0];
                    for (var i = 0; i < c; i++) {
                      $scope.buttons.push({ no: i + 1 });
                    }           
                    response.data.splice(0, 1);  
                }
                //
                $scope.todoitems = response.data;
                $('.ui.pagination.menu a').removeClass('active');
                $("#button_" + page).addClass("active");
                //var d = document.getElementById("button_" + page);
                //d.className += "active";
            });  
    }
}]);

app.factory('todoitems', [function () {
    var o = {
        todoitems: [
          { ID: '1',TodoTask: 'adaw' },
          { ID: '2',TodoTask: 'dcdc' },
          { ID: '3',TodoTask: 'vvv' },
          { ID: '4',TodoTask: 'bbb' }
        ]
    };
    return o;
}]);

app.factory('buttons', [function () {
    var o = {
        buttons: [
          { no: '1'},
  { no: '2'},
  { no: '3'},
  { no: '4'},
  { no: '5'}]
    };
    return o;
}]);

app.factory('lists', [function () {
    var o = {
        lists: [
          { title: 'aaaaa',id: '1' },
  { title: 'bbbbbb',id: '2' },
  { title: 'cccccc',id: '3' },
  { title: 'dddddd',id: '4' },
  { title: 'eeeeee',id: '5' }]
    };
    return o;
}]);