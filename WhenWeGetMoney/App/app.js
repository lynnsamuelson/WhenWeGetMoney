var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", "$window", function ($scope, $http, $window) {

    $scope.boughtWishes = function () {
        console.log("bought Wishes")
    }


    $scope.addMoneyToFamily = function () {
        $CurrentBalance = $("#currentBalance").text();
        $oldBalance = parseFloat($CurrentBalance);
        $AmountToAdd = $scope.DollarAmount;
        $toAdd = parseFloat($AmountToAdd);
        $totalMoneyPot = $oldBalance + $toAdd;
        console.log("total Money Pot", $totalMoneyPot);

        $MoneyUpdate = {
            "DollarAmount": $totalMoneyPot
        }

        $MoneyUpdateString = JSON.stringify($MoneyUpdate)



        $http.put("/api/Family/", $MoneyUpdateString).then(
            function (response) {
                //$window.location.reload();
                console.log("Updated $Pot Balance to",  $totalMoneyPot);
            },
            function (response) {
                console.log("error updating family $Pot");
            }
            );
    }

    $scope.subtractMoneyFromFamily = function () {
        console.log("Subratct Function found");
        $CurrentBalance = $("#currentBalance").text();
        $oldBalance = parseFloat($CurrentBalance);
        $AmountToSubtract = $scope.DollarAmount;
        $toSubtract = parseFloat($AmountToSubtract);
        $totalMoneyPot = $oldBalance - $toSubtract;
        console.log("total Money Pot", $totalMoneyPot);

        $MoneyUpdate = {
            "DollarAmount": $totalMoneyPot
        }

        $MoneyUpdateString = JSON.stringify($MoneyUpdate)



        $http.put("/api/Family/", $MoneyUpdateString).then(
            function (response) {
                //$window.location.reload();
                console.log("Updated $Pot Balance to", $totalMoneyPot);
            },
            function (response) {
                console.log("error updating family $Pot");
            }
            );
    }

   

    $scope.createOrUpdateFamily = function() {
        console.log("found create or update family");
        $familyName = $("#familyName").contents();
        console.log("$familyName", $familyName);
        console.log("family name[0]", $familyName[0]);

        $family = {
            "FamilyName": $scope.FamilyName,
            "DollarAmount": $scope.DollarAmount,
        }
        console.log("Family Obj", $family);

        $familyString = JSON.stringify($family)

        


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
            $http.put("/api/Family/", $familyString).then(
                    function (response) {
                        //$window.location.reload();
                        console.log("Updated Family");
                    },
                    function (response) {
                        console.log("error updating family");
                    }
                    );
        }
    };

    
    $scope.createWish = function () {
        console.log("Found Create Wish Btn");
        $wish = {
            "Content": $scope.content,
            "Cost": $scope.cost,
           
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

     $scope.boughtWish = function (id) {
         console.log("found bought it", id);
         $http.put(" /api/Wish/ " + id).then(
            function (response) {
                //$window.location.reload();
                console.log("Wish Updated to Bought");
            },
                function (response) {
                    console.log(error);
                }
            );
    }

}]);