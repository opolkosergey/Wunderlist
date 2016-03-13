angular.module("wunderlistApp")
    .controller("itemCtrl", function ($scope, $http, itemsUrl) {

        var currentItemName = "";

        $scope.date = null;
        $scope.newDescription = null;
       

        function getDate() {
            if ($scope.currenItem.item.Date != null)
                $scope.date = new Date($scope.currenItem.item.Date);
            else
                $scope.date = null;
        }

        function getPage(list, page) {
            page = page || 1;
            $http.get('/api/Item?id=' + list.Id + '&page=' + page + '&isneedPageCount=' + 'true')
                .success(function (itemsData) {
                $(".editing").addClass('hidden');
                $(".deleting").addClass('hidden');
                $(".ui.secondary.vertical.pointing.menu a").removeClass("active");
                $("#list_" + list.Id).addClass("active");
                $("#editIcon_" + list.Id).removeClass("hidden");
                $("#deleteIcon_" + list.Id).removeClass("hidden");
                $(".editingblock").addClass('hidden');
                $scope.buttonsforactive.buttons = null;
                $scope.allItemsList.items = null;
                var c = itemsData[0];
                var arr = new Array();
                if (c > 1) {
                    for (var i = 0; i < c; i++) {
                        arr[i] = { no: i + 1 };
                    }
                    $scope.buttonsforactive.buttons = arr;
                }
                itemsData.splice(0, 1);
                $scope.allItemsList.items = itemsData;
                $scope.currentList.list = list;
            });
        };

        function addNewTask(taskName) {

            if (taskName == undefined || taskName == "")
                alert("You do not lead a task! Please specify the field for the task!");

            else {
                var item = {
                    TodoListId: $scope.currentList.list.Id,
                    TodoTask: taskName,
                    Status: 1
                }

                $http.post(itemsUrl, item).success(function (newItem) {
                    //$scope.allItemsList.items.push(newItem);
                    $scope.currentList.list.CountItem++;
                    getPage($scope.currentList.list, "maxpage");
                });
            }
        };

        function complete(completeTast) {
            if (completeTast != null) {
                completeTast.Status = "2";
                $http.put(itemsUrl + completeTast.Id, completeTast).success(function (completedTast) {
                    //alert(completedTast.TodoTask + " завершенная задача!");
                    getPage($scope.currentList.list, 1);
                });
            };
        }

        function incomplete(completeTast) {
            if (completeTast != null) {
                completeTast.Status = "1";

                $http.put(itemsUrl + completeTast.Id, completeTast).success(function (completedTast) {
                    //document.getElementById("completed").style.display = "none";
                    //alert(completedTast.TodoTask + " актуальная задача!");
                    getPage($scope.currentList.list, "maxpage");
                });
            };
        }

        function deleteTask(task) {
            if (task != null) {

                if (confirm("Do you want to remove" + task.TodoTask)) {
                    $http.delete(itemsUrl + task.Id).success(function() {
                        //$scope.allItemsList.items.splice($scope.allItemsList.items.indexOf(task), 1);
                        $scope.currentList.list.CountItem--;
                        getPage($scope.currentList.list, "maxpage");
                    });
                }
            }
        };

        function showDetails(task) {
            if ($scope.currenItem.item != task) {
                $scope.currenItem.item = task;
                $scope.newDescription = $scope.currenItem.item.Description;
                getDate(task);
            }
            $('.ui.sidebar').sidebar('toggle');
        }

        $scope.changeDate = function () {

            var newDate = $scope.date.toISOString().split(".")[0]; //toJSON()
            $scope.currenItem.item.Date = newDate;

            $http.put(itemsUrl + $scope.currenItem.item.Id, $scope.currenItem.item).success(function () {
                getDate();
            });
        }

        $scope.changeDescription = function () {
            if ($scope.newDescription != $scope.currenItem.item.Description) {
                $scope.currenItem.item.Description = $scope.newDescription;

                $http.put(itemsUrl + $scope.currenItem.item.Id, $scope.currenItem.item).success(function (changeItem) {
                    alert(changeItem.TodoTask + " установлена новое описание!");
                });
            }
        }

       

        $scope.changeName = function () {

            if ($scope.currenItem.item.Name != null || $scope.currenItem.item.Name != "undefined") {

                $http.put(itemsUrl + $scope.currenItem.item.Id, $scope.currenItem.item).success(function(changeItem) {

                });
            }
        }
        $scope.$on("loadItemsEvent", function (event, args) {
            getPage(args.actualList);   
        });

        $scope.$on("createNewTaskEvent", function (event, args) {
            addNewTask(args.taskName);
        });

        $scope.$on("completeTaskEvent", function (event, args) {
            complete(args.item);
        });

        $scope.$on("incompleteTaskEvent", function (event, args) {
            incomplete(args.item);
        });

        $scope.$on("deleteTaskEvent", function (event, args) {
            deleteTask(args.task);
        });

        $scope.$on("showDetailsEvent", function (event, args) {
            showDetails(args.task);
        });
    });