angular.module("wunderlistApp")
    .controller("listCtrl", function($scope) {

        $scope.listChange = function (id) {
            document.getElementById("completed").style.display = "none";
            
            $scope.sirenLoadItems(id);
        }

        $scope.addNewList = function(newListName) {
            var list = {
                UserModelId: $scope.user.Id,
                Name: newListName
            }

            $scope.newListName = "";

            new $scope.listsResource(list).$save().then(function (newList) {
                $scope.lists.push(newList);
                $('#createListWindow').modal('hide');
            });
        }
    });