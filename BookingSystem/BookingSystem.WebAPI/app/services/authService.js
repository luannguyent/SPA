'use strict';
app.factory('authService', ['$http', '$q', '$location', 'localStorageService', function ($http, $q, $location, localStorageService) {
    var authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false,
        isAdmin: false
};
    var authService = {};
    var saveRegistration = function (registration) {
        var servicePath = location.origin;
        return $http.post(servicePath + '/api/account/register', registration).then(function (response) {
            return response;
        });

    };
    var login = function (loginData) {
        var servicePath = location.origin;
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
        var deferred = $q.defer();

        $http.post(servicePath + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
            localStorageService.set('isAdmin', response.isAdmin);
            if (loginData.useRefreshTokens) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
            }
            else {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
            }
            authentication.isAdmin = response.isAdmin == 'True' ? true : false;
            authentication.isAuth = true;
            authentication.userName = loginData.userName;
            authentication.useRefreshTokens = loginData.useRefreshTokens;

            deferred.resolve(response);

        }).error(function (err, status) {
            logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };
    var logOut = function () {

        localStorageService.remove('authorizationData');
        localStorageService.remove('isAdmin');
        authentication.isAdmin = false;
        authentication.isAuth = false;
        authentication.userName = "";
        authentication.useRefreshTokens = false;

    };
    var fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        var isAdmin = localStorageService.get('isAdmin');
        if (authData) {
            authentication.isAdmin = isAdmin == 'True' ? true : false;
            authentication.isAuth = true;
            authentication.userName = authData.userName;
            authentication.useRefreshTokens = authData.useRefreshTokens;
        }
    };
    authService.saveRegistration = saveRegistration;
    authService.login = login;
    authService.logOut = logOut;
    authService.fillAuthData = fillAuthData;
    authService.authentication = authentication;
    return authService;
}]);