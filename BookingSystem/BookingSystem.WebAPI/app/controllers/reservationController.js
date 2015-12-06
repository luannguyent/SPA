app.controller('reservationController', ['$scope', '$compile', '$timeout', 'uiCalendarConfig', 'reservationService',
    'ngDialog', '$templateCache', 'localStorageService',
    function ($scope, $compile, $timeout, uiCalendarConfig, reservationService, ngDialog, $templateCache, localStorageService) {
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();
        $scope.getReservations = function() {
            reservationService.getReservations().then(function (response) {
                console.log(response);
                $scope.events.length = 0;
                var data = response.data;
                var len = data.length;
                if (len == 0) {
                    angular.element('#calendarr').fullCalendar('refetchEvents');
                    return;
                }
                for (var i = 0; i < len; i++) {
                    var item = data[i];
                    var arrStart = item.StartDate.split('T');
                    var arrEnd = item.EndDate.split('T');
                    var start = new Date(arrStart[0]);
                    var end = new Date(arrEnd[0]);
                    var color = '';
                    switch (item.Status) {
                        case 'Approved':
                            color = '#6F90FF';
                            break;
                        case 'Rejected':
                            color = '#E40B00';
                            break;
                        case 'Canceled':
                            color = '#4A4A4A';
                            break;
                        default:
                            color = '#EAF65E';
                            break;
                    }
                    var obj = {
                        id: item.Id, title: arrStart[1] + '-' + arrEnd[1],
                        start: start, end: end,
                        userName: item.UserName,
                        tooltip: item.Description,
                        status : item.Status,
                        typeName: item.TypeName,
                        color: color,
                        allDay: true
                    };
                    $scope.events.push(obj);
                }
            }, function (response) {

            });
        }
        $scope.getReservations();
        $scope.reservationDetail = {
            createBy: '',
            time: '',
        };
        $scope.eventSource = {
        };
        $scope.events = [];
        $scope.eventsF = function (start, end, timezone, callback) {
            var s = new Date(start).getTime() / 1000;
            var e = new Date(end).getTime() / 1000;
            var m = new Date(start).getMonth();
            var events = $scope.events;
            callback(events);
        };

        $scope.calEventsExt = {

        };
        /* alert on eventClick */
        $scope.alertOnEventClick = function (date, jsEvent, view) {
            $templateCache.removeAll();
            $scope.reservationDetail.id = date.id;
            $scope.reservationDetail.createBy = date.userName;
            $scope.reservationDetail.time = date.title;
            $scope.reservationDetail.typeName = date.typeName;
            $scope.reservationDetail.comments = '';
            var isAdmin = localStorageService.get('isAdmin');
            var authData = localStorageService.get('authorizationData');
            $scope.reservationDetail.canReject = false;
            $scope.reservationDetail.canApprove = false;
            $scope.reservationDetail.canCancel = false;
            var canShow = false;
            if (isAdmin != 'False' && date.status == "Pending") {
                $scope.reservationDetail.canReject = true;
                $scope.reservationDetail.canApprove = true;
                $scope.reservationDetail.canCancel = false;
                canShow = true;
            }
            if (authData.userName == date.userName && date.status == "Pending") {
                $scope.reservationDetail.canCancel = true;
                canShow = true;
            }
            if (canShow) {
                ngDialog.open(
                {
                    template: 'app/views/popup.html',
                    scope: $scope,
                    cache: false
                });
            }
        };
        $scope.updateStatus = function (id, comments, actionType) {
            var data = {
                id: id,
                comment: comments,
                actionType: actionType
            }
            reservationService.updateReservation(data).then(function (response) {
                $scope.getReservations();
            }, function (response) {

            });
        }
        /* alert on Drop */
        $scope.alertOnDrop = function (event, delta, revertFunc, jsEvent, ui, view) {
        };
        /* alert on Resize */
        $scope.alertOnResize = function (event, delta, revertFunc, jsEvent, ui, view) {
        };
        /* add and removes an event source of choice */
        $scope.addRemoveEventSource = function (sources, source) {
            var canAdd = 0;
            angular.forEach(sources, function (value, key) {
                if (sources[key] === source) {
                    sources.splice(key, 1);
                    canAdd = 1;
                }
            });
            if (canAdd === 0) {
                sources.push(source);
            }
        };
        /* add custom event*/
        $scope.addEvent = function () {
            $scope.events.push({
                title: 'Open Sesame',
                start: new Date(y, m, 28),
                end: new Date(y, m, 29),
                className: ['openSesame']
            });
        };
        /* remove event */
        $scope.remove = function (index) {
            $scope.events.splice(index, 1);
        };
        /* Change View */
        $scope.changeView = function (view, calendar) {
            uiCalendarConfig.calendars[calendar].fullCalendar('changeView', view);
        };
        /* Change View */
        $scope.renderCalender = function (calendar) {
            $timeout(function () {
                if (uiCalendarConfig.calendars[calendar]) {
                    uiCalendarConfig.calendars[calendar].fullCalendar('render');
                }
            });
        };
        /* Render Tooltip */
        $scope.eventRender = function (event, element, view) {
            element.attr({
                'tooltip': event.title,
                'tooltip-append-to-body': true
            });
            $compile(element)($scope);
        };
        /* config object */
        $scope.uiConfig = {
            calendar: {
                height: 450,
                editable: true,
                header: {
                    left: 'title',
                    center: '',
                    right: 'today prev,next'
                },
                eventClick: $scope.alertOnEventClick,
                eventDrop: $scope.alertOnDrop,
                eventResize: $scope.alertOnResize,
                eventRender: $scope.eventRender
            }
        };
        /* event sources array*/
        $scope.eventSources = [$scope.events, $scope.eventSource, $scope.eventsF];
    }]);