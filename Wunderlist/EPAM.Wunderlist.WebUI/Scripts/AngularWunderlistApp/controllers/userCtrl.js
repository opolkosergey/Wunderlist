angular.module("wunderlistApp")
    .controller("userCtrl", function($scope, $http) {

        function updateUser(data) {
            $http.post($scope.userUrl + $scope.user.Id, data).success(function(user) {
                $scope.user = user;
            });
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