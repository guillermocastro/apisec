angular.module("mainApp").component("bucketComponent",{
    templateUrl:'bucket.html',
    controller:function bucketsController($scope, $rootScope,$scope,$http){
        $scope.Buckets=[];
        $scope.vBuckets=[];
        $scope.GetBuckets=function(){
            console.log("$scope.GetBuckets");
            var s=baseURL+api+"Bucket";
            console.log(s);
            $http.get(s).then(function(response){
                $scope.Buckets=response.data;
            },function(response){
                console.log("Error");
            })
        };
        $scope.GetvBuckets=function(){
            console.log("$scope.GetvBuckets");
            var s=baseURL+api+"vBucket";
            console.log(s);
            $http.get(s).then(function(response){
                $scope.vBuckets=response.data;
            },function(response){
                console.log("Error");
            })
        };
        $scope.GetvBuckets();
        $scope.GetBuckets();    
        console.log("bucketsController");
    }
});