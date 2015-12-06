var app = angular.module('BookingSysApp', ['ngRoute', 'LocalStorageModule', 'ui.calendar', 'ui.bootstrap', 'ngDialog']);
app.isDefined = angular.isDefined;
app.config(function ($routeProvider) {
    $routeProvider.when("/new", {
        controller: "newReservationController",
        templateUrl: "/app/views/newreservation.html"
    });
    $routeProvider.when("/reservations", {
        controller: "reservationController",
        templateUrl: "/app/views/reservation.html"
    });
    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });
    $routeProvider.otherwise({ redirectTo: "/reservations" });
},function(localStorageServiceProvider) {
    localStorageServiceProvider
     .setPrefix('booking')
     .setStorageType('localStorage')
     .setNotify(false, false);
});
app.constant('ngAuthSettings', {
    apiServiceBaseUri: location.origin,
});
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);