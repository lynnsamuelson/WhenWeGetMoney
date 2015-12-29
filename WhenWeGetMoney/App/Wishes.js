var app = angular.module('whenwegetmoney', []);

app.controller('Wishes', ["$scope", "$http", function ($scope, $http) {

    $http.get("/api/Wish/")
        .success(function (data) {
            $scope.wishes = data;
            $scope.wish = $scope.wishes[5]["<Content>k__BackingField"];
            $scope.test = "test";