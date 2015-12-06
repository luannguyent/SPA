app.controller('loginController', ['$scope','$location', 'authService', function ($scope,$location,authService) {
    $scope.message = "";
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };
    $scope.login = function () {
        authService.login($scope.loginData).then(function (response) {
            $location.path('/reservations');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}]);