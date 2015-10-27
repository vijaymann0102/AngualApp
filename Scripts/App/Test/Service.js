angular.module('MyApp')
    .factory('dataFactory', ['$http', function ($http) {

        //ideally urlbase should be configured for full application and injected in factory rather than initiallising
        //again and again like below
    var urlBase = '/AngularApp';
        var dataFactory = {};

        dataFactory.GetFilteredJson = function (data) {

            var object = new Object();
            object.data = data;
            return $http(
                {
                    url: urlBase + '/api/Test/GetFilteredJson',
                    method: 'POST',
                    data: object
                }

            )
        };

    return dataFactory;

    }]);