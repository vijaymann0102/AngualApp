MyApp.controller('TestCtrl', ['$scope','$log','dataFactory',
    function ($scope,$log, dataFactory) {

        debugger;
        $scope.Result = "";
        $log.info('Logging Controller TestCtrl!');
       
        $scope.getFilteredJson =function(response) {
            dataFactory.GetFilteredJson($scope.JsonInputted).success(function (data) {
                $log.info('Executed getCompanyDetailsbyId method successfully!');
                $scope.Result = data;
            }).error(function (error) {
                $log.error('Error executing getCompanyDetailsbyId method ' + error);
                $scope.Result = error;
                alert(error);
            });
        }

          
       
    }
]);


