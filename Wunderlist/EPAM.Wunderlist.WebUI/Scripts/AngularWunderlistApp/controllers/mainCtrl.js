angular.module("wunderlistApp")
    .controller("mainCtrl", function($scope, $http, $resource) {

        $scope.listsResource = $resource("/api/list/");
        $scope.itemsResource = $resource("/api/item/");
        $scope.userUrl = "/api/user/";
        $scope.avatarPath = "/Content/images/homer-simpson.jpg";

        $scope.currenItem = {
            current: null
        };

        (function() {

            function bootstrapLoadLists(userId) {
                $scope.listsResource.query({ userId }, function(listsData) {
                    $scope.lists = listsData;
                    $scope.getAllItems(listsData[0].Id);
                });
            }

            $scope.sirenLoadItems = function (id) {
                $scope.$broadcast("loadItemsEvent", { listId: id });
            };

            $scope.getCurrentList = function(id) {
                var count = $scope.lists.length;
                for (var i = 0; i < count; i++) {
                    if ($scope.lists[i].Id === id)
                        $scope.currentList = $scope.lists[i];
                };
            };

            $scope.getCurrentItem = function (id) {
                var count = $scope.lists.length;
                for (var i = 0; i < count; i++) {
                    if ($scope.items[i].Id === id)
                        $scope.currentItem = $scope.items[i];
                };
            };

            $scope.getAllItems = function(id) {
                $scope.itemsResource.query({ id }, function (itemsData) {
                    $(".ui.secondary.vertical.pointing.menu a").removeClass("active");
                    $("#list_" + id).addClass("active");
                    $scope.items = itemsData;
                    $scope.getCurrentList(id);
                    $scope.currentListId = id;
                });
            }

            $http.get($scope.userUrl).success(function(user) {
                $scope.user = user;
                bootstrapLoadLists(user.Id);
            });
        })();
    });