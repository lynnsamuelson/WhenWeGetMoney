var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", "$window", function ($scope, $http, $window) {


    $scope.deleteUsers = function () {
        $http.delete("/api/Test")
        .success(function (data) {
            alert("Deleting Users Yay!");
        })
        .error(function (error) {
            alert(error.error);
        })
    }

    
    $scope.createWish = function () {
        console.log("Found Create Wish Btn");
        $wish = {
            "Content": $scope.content,
            "WishUrl": $scope.wishUrl,
            "Picture": $scope.picture
        }

        $wishString = JSON.stringify($wish);

        $http.post("/api/Wish/", $wishString).then(
                function (response) {
                    $window.location.reload();
                    console.log("SUCCESS - comments using FROMURI");     
                },
                function (response) { 
                    console.log("ERRORRRRRR - comments using FROM URI"); 
                }
                );
     }

    $scope.deleteWish = function (id) {
        console.log("found delete", id);
        $http.delete(" /api/Wish/ " + id).then(
            function (response) {
                $window.location.reload();
                console.log("Wish Deleted");
            },
                function (response) { 
                    console.log(error);
                }
            );
    }
}]);