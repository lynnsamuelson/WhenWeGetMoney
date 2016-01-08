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

    $scope.createOrUpdateFamily = function() {
        console.log("found create or update family");
        $familyName = $("#familyName").contents();
        console.log("$familyName", $familyName);
        console.log("family name[0]", $familyName[0]);

        $familyString  = JSON.stringify($scope.content);
        console.log("$familyString", $familyString);

        $familyMoney = JSON.stringify($scope.money);
        console.log("familyMoney", $familyMoney);

        //$family = {
        //    "Content": $scope.content,
        //    "money": $scope.money,
        //}
        //console.log("Family Obj", $family);

        //$familyString = JSON.stringify($family)

        $http.post("/api/MoneyPot/", $familyMoney).then(
                function (response) {
                    //$window.loctaion.reload();
                    console.log("Created a MoneyPot for the Family");
                    console.log("response", response);
                },
                function (response) {
                    console.log("Error creating MoneyPot");
                });


        if ($familyName[0] == undefined) {
            //create family method
            $http.post("/api/Family/", $familyString).then(
                    function (response) {
                        //$window.location.reload();
                        console.log("Created Family");
                    },
                    function (response) {
                        console.log("Error creating family");
                    }
                    );

            

        } else {
            //update family method
            $http.put("/api/Family/", $familyName[0]).then(
                    function (response) {
                       // $window.location.reload();
                        console.log("Updated Family Name");
                    },
                    function (response) {
                        console.log("error updateding family");
                    }
                    );
        }
    };

    
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
                    console.log("SUCCESS");     
                },
                function (response) { 
                    console.log("ERRORRRRRR"); 
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