'use strict';
app.factory('reservationService', ['$http', '$q', '$location', 'localStorageService', 'ngAuthSettings',
    function ($http, $q, $location, localStorageService, ngAuthSettings) {
    var reservationsServiceFactory = {};
    var getReservations = function () {
        return $http.get(ngAuthSettings.apiServiceBaseUri + '/api/Reservation/GetReservations').then(function (results) {
            return results;
        });
    };
    var saveReservation = function(data) {
        return $http.post(ngAuthSettings.apiServiceBaseUri + '/api/Reservation/SaveReservation', data).then(function (results) {
            return results;
        });
    }
    var updateReservation = function (data) {
        return $http.post(ngAuthSettings.apiServiceBaseUri + '/api/Reservation/UpdateStatus', data).then(function (results) {
            return results;
        });
    }
    reservationsServiceFactory.getReservations = getReservations;
    reservationsServiceFactory.saveReservation = saveReservation;
    reservationsServiceFactory.updateReservation = updateReservation;
    return reservationsServiceFactory;
}]);