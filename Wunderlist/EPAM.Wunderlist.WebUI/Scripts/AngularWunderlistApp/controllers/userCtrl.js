angular.module("wunderlistApp")
    .controller("userCtrl", function($scope, $http) {

        $scope.updateUser = function() {
            var formdata = new FormData(); //FormData object
            var fileInput = document.getElementById('hiddenFile');
            //Iterating through each files selected in fileInput
            formdata.append("image", fileInput.files[0]);
            formdata.append("newUserName", $scope.newUserName);
            formdata.append("userId", $scope.user.Id);        
            //Creating an XMLHttpRequest and sending
            var xhr = new XMLHttpRequest();
            xhr.open('POST', '/Profile/UpdateUser');
            xhr.send(formdata);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var res = $.parseJSON(xhr.responseText);
                    $scope.avatarPath = "/UserContent/Photos/" + res.PhotoUrl;
                    $("#ava").attr("src", $scope.avatarPath);
                    $scope.user.UserName = res.name;
                    $('#hiddenFile').val("");
                    $('#photoCover').val("");
                    $("#preview").attr("src", '#');
                    $('#uploadPreview').addClass('hidden');
                }
            }
        }

        function createUserToUpdate() {
            return {
                UserName: $scope.user.UserName,
                Email: $scope.user.Email,
                Password: $scope.user.Password
            };
        }

        $scope.updateUserEmail = function(newEmail) {
            var user = createUserToUpdate();
            user.Email = newEmail;
            updateUser(user);
        };

    });