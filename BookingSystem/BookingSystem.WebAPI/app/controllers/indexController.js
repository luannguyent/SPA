app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $scope.authentication = authService.authentication;
    $scope.$watch('authentication', function (newValue, oldValue) {
        console.log(newValue, oldValue);
    });
    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login');
    }
}]);