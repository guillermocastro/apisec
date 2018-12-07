// Define the `mainApp` module
var baseURL = "";
var api = "/api/";
var config = {
    headers: {
        //"Authorisation": token,
        "Accept": 'application/json',
        "Content-Type": 'application/json',
        "cache-control": 'no-cache',
        "Application": 'Time and Resources Management'
    }
}
angular.module('mainApp', []);
angular.module("mainApp").controller("menuController",function($scope, $rootScope,$http){
    $scope.activecomponent="V&E";
});
angular.module("mainApp").controller("sqlserverController",function($scope, $rootScope,$http){
    $scope.data="sqlserver";
});
angular.module("mainApp").controller("deviceController",function($scope, $rootScope,$http){
    $scope.data="devices";
});
angular.module("mainApp").controller("diskController",function($scope, $rootScope,$http){
    $scope.data="disks";
});
angular.module("mainApp").controller("remotejobsController",function($scope, $rootScope,$http){
    $scope.data="remotejobs";
});
angular.module("mainApp").controller("monitorController",function($scope, $rootScope,$http){
    $scope.data="monitor";
});