var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {


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
                    console.log("SUCCESS - comments using FROMURI"); 
                  
                },
                function (response) { 
                    console.log("ERRORRRRRR - comments using FROM URI"); 
                }
                );
     }

    $scope.deleteWish = function (id) {

        //$wishToDelete = {
        //    "Content": $scope.content,
        //    "WishUrl": $scope.wishUrl,
        //    "Picture": $scope.picture
        //}
        console.log("found delete", id);

        $http.delete(" /api/Wish/ " + id).then(
            function (response) { 
                console.log("Wish Deleted");
            },
                function (response) { 
                    console.log(error)
                }
            );


           // function (data) { console.log("Wish Deleted"); $window.location.reload(); })
           //.error(function () { console.log(error); });
    }







}]);