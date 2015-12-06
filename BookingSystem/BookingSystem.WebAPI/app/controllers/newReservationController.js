app.controller('newReservationController', ['$scope', '$location', 'reservationService','typeService', 'propertyService','$filter', function ($scope, $location, reservationService, typeService, propertyService, $filter) {
    $scope.reservation = {
        selectedType: '',
        selectedProperty: '',
        startDate:'',
        endDate: '',
        startTime: '',
        endTime: '',
        description: '',
        strStartTime: '',
        strEndTime:''
    };
    $scope.getTypes = function () {
        typeService.getTypes().then(function (response) {
            $scope.types = response.data;
        }, function (response) {

        });
    }
    $scope.typeChange = function () {
        propertyService.getPropertiesByType($scope.reservation.selectedType).then(function (response) {
            $scope.properties = response.data;
        }, function (response) { });
    }
    $scope.getTypes();
    $scope.today = function () {
        $scope.reservation.startDate = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.reservation.startDate = null;
        $scope.reservation.endDate = null;
    };
    /****new min date code */
    $scope.dateChange = function (event) {
        var d = $scope.endMinDate.setDate($scope.reservation.startDate.getDate());
        $scope.endMinDate = new Date(d);
    }
    /****new min date code end */

    $scope.toggleMin = function () {
        $scope.minDate = $scope.minDate ? null : new Date();
        $scope.endMinDate =  $scope.endMinDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.openStartDate = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.openedStartDate = true;
        $scope.openedEndDate = false;
    };

    $scope.openEndDate = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.openedStartDate = false;
        $scope.openedEndDate = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];

    $scope.reservation.startTime = new Date();
    $scope.reservation.endTime = new Date();
    $scope.reservation.endTime.setHours($scope.reservation.startTime.getHours() + 1);
    $scope.hstep = 1;
    $scope.mstep = 15;
    
    $scope.options = {
        hstep: [1, 2, 3],
        mstep: [1, 5, 10, 15, 25, 30]
    };
    $scope.setTime = function() {
        $scope.reservation.startDate.setHours($scope.reservation.startTime.getHours());
        $scope.reservation.startDate.setMinutes($scope.reservation.startTime.getMinutes());
        $scope.reservation.endDate.setHours($scope.reservation.endTime.getHours());
        $scope.reservation.endDate.setMinutes($scope.reservation.endTime.getMinutes());
    }
    $scope.reservation.endDate = new Date();
    $scope.setTime();
    $scope.changed = function() {
        $scope.setTime();
    }
    $scope.submitData = function() {
        if ($scope.newReservation.$valid) {
            console.log($scope.reservation);
            if ($scope.reservation.endDate <= $scope.reservation.startDate) {
                alert('Please enter the valid data for all the required field below.');
                return;
            }
            $scope.reservation.strStartTime = $filter('date')($scope.reservation.startDate, 'yyyy/MM/dd') + ' ' + $filter('date')($scope.reservation.startDate, 'HH:mm');
            $scope.reservation.strEndTime = $filter('date')($scope.reservation.endDate, 'yyyy/MM/dd') + ' ' + $filter('date')($scope.reservation.endDate, 'HH:mm');
            reservationService.saveReservation($scope.reservation).then(function (response) {
                alert('The booking has been created');
            }, function (response) {
                
            });
        } else {
            alert('Please enter the valid data for all the required field below.');
        }
    }
}]);