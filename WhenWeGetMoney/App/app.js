var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {


    $scope.deleteUsers = function () {
        $http.delete("/api/Test")
        .success(function (data){
        alert("Deleting Users Yay!");
        })
        .error(function(error) {
            alert(error.error);
        })
    }


    $scope.createWish = function () {
        console.log("Found Create Wish Btn");
        $form = $("#myform").first();

        $wish = {
            "Content": $scope.content,
            "WishUrl": $scope.wishUrl,
            "Picture": $scope.picture,
            "WishId": 99
        }
        $wishString = JSON.stringify($wish);

        console.log("New Wish", $wish);
        console.log("wish.content", $wish.Content);

        $config_obj = {
            'headers': {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        }

        console.log("$config_obj", $config_obj);

        
    
        $http.post("/api/Wish", $wishString, $config_obj)
            .success(function (data) {
                console.log("Saving Data!", data);
                console.log("wish after post", $wish);

              
            })
            .error(function (error) { console.log(error.error) });
    }

    $scope.deleteWishes = function () {
        console.log("Found Delete Btn");
       
    }




        
}]);