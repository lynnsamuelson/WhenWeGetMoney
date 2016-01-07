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

        console.log("New Wish", $wishString);
        console.log("wish.content", $wish.Content);

        //$config_obj = {
        //    'headers': {
        //        'Content-Type': 'application/json',
        //        'Accept': 'application/json'
        //    }
        //}

        //console.log("$config_obj", $config_obj);

        $http.post("/api/Wish/", $wishString).then(
                function (response) { 
                    console.log("SUCCESS - comments using FROMURI"); 
                  
                },
                function (response) { 
                    console.log("ERRORRRRRR - comments using FROM URI"); 
                }
                );
            }




    //    $http.post("/api/Wish", $wishString)
    //        .success(function (data) {
    //            console.log("Saving Data!", data);
    //            console.log("wish after post", $wishString);
    //        })
    //        .error(function (error) { console.log(error.error) });
    //}

    //$scope.deleteWishes = function () {
    //    console.log("Found Delete Btn");

    //}





}]);