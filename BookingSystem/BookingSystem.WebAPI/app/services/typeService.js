'use strict';
app.factory('typeService', ['$http', '$q', '$location', 'localStorageService', 'ngAuthSettings',
    function ($http, $q, $location, localStorageService, ngAuthSettings) {
        var typeServiceFactory = {};
        var getTypes = function () {
            return $http.get(ngAuthSettings.apiServiceBaseUri + '/api/Type/GetTypes').then(function (results) {
                return results;
            });
        };
        typeServiceFactory.getTypes = getTypes;

        return typeServiceFactory;
    }]);