var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {
    $scope.test = "test variable";

    $scope.hello = function () {
        //$scope.test = "Hello World";
        console.log("clicked");
        console.log("Scope.test", $scope.test);
        $http.get("/api/Wish/")
            .success(function (data) {
                $scope.test = data[2]
                //$scope.test = data[1];
                console.log("data", data)
            })
            .error(function (error) { alert(error.error) });
    }
}]);