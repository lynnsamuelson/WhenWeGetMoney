var app = angular.module('whenwegetmoney', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {

    //$http.get("/api/Wish/")
    //    .success(function (data) {
    //        $scope.wishes = data;
    //        console.log("data test", data);
    //        //$scope.wish = $scope.wishes[5]["<Content>k__BackingField"];
    //        //console.log("Scope.wish[5]", $scope.wish);
            
    //        $scope.allWishes = [];
    //        //console.log("all wishes before loop", $scope.allWishes);

    //        for (var i = 0; i < data.length; i++) {
    //            $scope.familyId = $scope.wishes[i]["<Author>k_backingField"];
    //            console.log("familyID", $scope.familyId);
    //            $scope.theWish = $scope.wishes[i]["<Content>k__BackingField"];
    //            //console.log("the current wish", $scope.wishes[i]["<Content>k__BackingField"]);
    //            $scope.allWishes.push($scope.wishes[i]["<Content>k__BackingField"]);

    //        }
    //        console.log("all wishes after loop", $scope.allWishes);
            

          

    //    })
    //    .error(function (error) { alert(error.error) });


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



    $scope.createWish = function () {
        console.log("I Work!");
        $form = $("#myform").first();

      

        $wish = {
            "Content": $scope.content,
            "WishUrl": $scope.wishUrl,
            "Picture": $scope.picture
        }

        console.log("New Wish", $wish);
        console.log("wish.content", $wish.Content)

        $config_obj = {
            'headers': {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        }

        console.log("$config_obj", $config_obj);

        var data = $wish;
    
        $http.post("/api/Wish", $wish, $config_obj)
            .success(function (data) {
                console.log("Saving Data!", data);
                console.log("wish after post", $wish);

              
            })
            .error(function (error) { console.log(error.error) });
  
    }


        
}]);