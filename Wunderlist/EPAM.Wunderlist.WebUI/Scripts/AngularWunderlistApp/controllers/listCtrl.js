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

        $scope.editTitle = function(id) {
            $(".editingblock").addClass('hidden');
            $("#editingblock_" + id).removeClass('hidden');
        }

        $scope.submitEdit = function (id) {
            var a = $('#newTitle_' + id).val();
            alert(a);
            $.ajax('/api/List/'+id, {
                type: "PUT",
                data: a
            });
            //$.put('/api/List/UpdateList/'+id, {
            //    newTitle: a
            //}).then(function successCallback(response) {
            //    $('.editingblock').addClass('hidden');
            //    $("#listTitle_" + response.data.Id).val(response.data.Name);
            //});
        }
    });