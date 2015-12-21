var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {

    $http.get("/api/Wish/")
        .success(function (data) {
            $scope.wishes = data;
            
            console.log("data", $scope.wishes[3]);
            console.log("data of content", $scope.wishes[3]["<Content>k__BackingField"]);

        })
        .error(function (error) { alert(error.error) });


    //$scope.test = "test variable";

    $scope.hello = function () {
        //$scope.test = "Hello World";
        console.log("clicked");
        
    }
}]);