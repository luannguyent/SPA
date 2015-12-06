'use strict';
app.factory('propertyService', ['$http', '$q', '$location', 'localStorageService', 'ngAuthSettings',
    function ($http, $q, $location, localStorageService, ngAuthSettings) {
        var propertyServiceFactory = {};
        var getPropertiesByType = function (typeId) {
            return $http.get(ngAuthSettings.apiServiceBaseUri + '/api/Property/GetPropertiesByType',
                { params: { typeId: typeId } }).then(function (results) {
                return results;
            });
        };
        propertyServiceFactory.getPropertiesByType = getPropertiesByType;

        return propertyServiceFactory;
    }]);