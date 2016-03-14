angular.module("wunderlistApp")
    .controller("listCtrl", function ($scope, $http, listsUrl) {

        $scope.addNewList = function (newListName) {
            if (newListName == undefined || newListName == "") {
                alert("You do not lead a list name! Please specify the field for the list name!");
            } else {
                var list = {
                    UserModelId: $scope.user.Id,
                    Name: newListName
                }

                $scope.newListName = "";

                $http.post(listsUrl, list).success(function (newList) {
                    $scope.allListsUser.lists.push(newList);
                    $('#createListWindow').modal('hide');
                });
            }
        }

        function editTitle(id) {
            $(".editingblock").addClass('hidden');
            $("#editingblock_" + id).removeClass('hidden');
        }

        function changeTitle(list) {
            var newName = $('#newTitle_' + list.Id).val();
            list.Name = newName;
            $http.put(listsUrl + list.Id, list).success(function (list) {
                $(".editingblock").addClass("hidden");
            });
        }

        function deleteList(list) {
            if (confirm("Do you want to remove list")) {
                $http.delete(listsUrl + list.Id).success(function () {
                    $scope.allListsUser.lists.splice($scope.allListsUser.lists.indexOf(list), 1);
                    $scope.sirenItem.loadItems($scope.allListsUser.lists[0]);
                });
            }
        }

        $scope.$on("editTitleEvent", function (event, args) {
            editTitle(args.taskId);
        });

        $scope.$on("changeTitleEvent", function (event, args) {
            changeTitle(args.newList);
        });

        $scope.$on("deleteListEvent", function (event, args) {
            deleteList(args.listId);
        });
    });