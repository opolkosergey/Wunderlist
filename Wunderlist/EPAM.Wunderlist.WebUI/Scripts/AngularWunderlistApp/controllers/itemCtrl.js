angular.module("wunderlistApp")
    .controller("itemCtrl", function($scope) {

        $scope.$on("loadItemsEvent", function(event, args) {
            $scope.getAllItems(args.listId);
        });

        $scope.addNewItem = function(newTask) {
            var item = {
                TodoListId: $scope.currentListId,
                TodoTask: newTask,
                Status: 1
            }

            $scope.newTask = "";

            new $scope.itemsResource(item).$save().then(function (newItem) {
                $scope.items.push(newItem);
                $scope.currentList.CountItem++;
            });
        }

        $scope.completeIt = function(id) {
            //$scope.itemsResource
        };

        $scope.details = function (item) {
            if ($scope.currenItem != item) {
                alert('change');

                //var date = new Date(item.Date);

                $scope.currenItem.current = item;
            }
            $('.ui.sidebar').sidebar('toggle');
            
            //$('.ui.sidebar').sidebar('toggle');
            //$scope.currenItemId = id;
        }

        $scope.deleteItem = function(id) {
            alert("deleted");
        };
    });