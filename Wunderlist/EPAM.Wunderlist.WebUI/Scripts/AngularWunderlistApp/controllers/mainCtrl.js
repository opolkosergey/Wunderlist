angular.module("wunderlistApp")
    .controller("mainCtrl", function ($scope, $http, userUrl, userProfileUrl, listsUrl) {
        $scope.avatarPath = "#";
        $scope.user = [];

        $scope.buttonsforactive = {
            buttons: null
        }

        $scope.currenItem = {
            item: null
        };

        $scope.currentList = {
            list: null
        };

        $scope.allItemsList = {
            items: null
        };

        $scope.allListsUser = {
            lists: null
        };

        $scope.getNewPage = function(page) {
            $http.get('/api/Item?id=' + $scope.currentList.list.Id + '&page=' + page).success(function(itemsData) {
                $('.ui.pagination.menu a').removeClass('active');
                $scope.allItemsList.items = itemsData;
                $('#button_' + page).addClass('active');
            });
        };

        $scope.getUncompletedTasks = function() {
            //alert($scope.currentList.list.Id);
            var completed = document.getElementById("completed");
            if (completed.style.display === "none") {
                completed.style.display = "inherit";
            } else {
                completed.style.display = "none";
            }
            //$http.get('/api/Item/GetCompleted/id=' + id).success(function(itemsData) {});
        }
        

        $scope.sirenItem = {

            loadItems: function (list) {
                document.getElementById("completed").style.display = "none";
                $scope.$broadcast("loadItemsEvent", { actualList: list });
            },

            addNewTask: function (taskName) {
                $scope.newTaskName = "";
                $scope.$broadcast("createNewTaskEvent", { taskName: taskName });
            },

            completeTast: function (completeTast) {
                $scope.$broadcast("completeTaskEvent", { item: completeTast });
            },

            incomplete: function (incompleteTask) {
                $scope.$broadcast("incompleteTaskEvent", { item: incompleteTask });
            },

            showDetails: function (task) {
                $scope.$broadcast("showDetailsEvent", { task: task });
            },

            deleteTask: function (deleteTask) {
                $scope.$broadcast("deleteTaskEvent", { task: deleteTask });
            }
        };

        $scope.sirenList = {
           

            editTitle: function(id) {
                $scope.$broadcast("editTitleEvent", { taskId: id });
            },

            changeTitle: function (list) {
                $scope.$broadcast("changeTitleEvent", { newList: list });
            }
        };

        (function() {
            $http.get(userUrl).success(function(user) {
                $scope.user = user;

                $http.get(listsUrl + user.Id).success(function(listsData) {
                    $scope.allListsUser.lists = listsData;
                    $scope.sirenItem.loadItems(listsData[0]);

                    $http.get(userProfileUrl + user.Id).success(function (response) {
                        $scope.avatarPath = "/UserContent/Photos/" + response.Photo;
                        $("#ava").attr("src", $scope.avatarPath);
                    });
                });
            });
        })();
    });
