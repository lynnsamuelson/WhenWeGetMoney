var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {

    $http.get("/api/Wish/")
        .success(function (data) {
            $scope.wishes = data;
            $scope.wish = $scope.wishes[5]["<Content>k__BackingField"];
            $scope.test = "test";

            $scope.allWishes = [];
           // console.log("all wishes before loop", $scope.allWishes);

            for (var i = 0; i < data.length; i++) {
                $scope.theWish = $scope.wishes[i]["<Content>k__BackingField"];
                console.log("the current wish", $scope.wishes[i]["<Content>k__BackingField"]);
                $scope.allWishes.push($scope.wishes[i]["<Content>k__BackingField"]);

            }
            console.log("all wishes after loop", $scope.allWishes);
            

           
            
           // console.log("data", $scope.wishes);
           // console.log("data of content", $scope.wishes["<Content>k__BackingField"]);

        })
        .error(function (error) { alert(error.error) });


    //$scope.test = "test variable";

    $scope.deleteUsers = function () {
        $http.delete("/api/Test")
        .success(function (data){
        alert("Deleting Users Yay!");
        })
        .error(function(error) {
            alert(error.error);
        })
    }


    $scope.postwish = function () {
        $http.post("/api/Wish")
            .success(function (data) {
                console.log("Saving Data!", data);
            })
            .error(function (error) { alert(error.error) });
    }
        
}]);