angular.module("wunderlistApp")
    .controller("userCtrl", function($scope, $http) {

        $scope.updateUser = function () {
            //if ($scope.user.UserName == "") {
            //    $(".ui.error.message").removeClass("hidden");
            //    $(".ui.error.message").html("<ul class='list'>" +
            //        "<li>Please select at least two skills</li></ul>");
            //    return;
            //}
            var formdata = new FormData();
            var fileInput = document.getElementById('hiddenFile');
            formdata.append("image", fileInput.files[0]);
            formdata.append("newUserName", $scope.user.UserName);
            formdata.append("userId", $scope.user.Id);        
            var xhr = new XMLHttpRequest();
            xhr.open('POST', '/Profile/UpdateUser');
            xhr.send(formdata);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var res = $.parseJSON(xhr.responseText);
                    if (res.PhotoUrl != "") {
                        $scope.avatarPath = "/UserContent/Photos/" + res.PhotoUrl;
                        $("#ava").attr("src", $scope.avatarPath);
                    }
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