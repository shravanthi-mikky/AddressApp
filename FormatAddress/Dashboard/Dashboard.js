app.controller("DashboardCtrl", function ($scope, $http) {

    //Add Employee
    $scope.add = function (singleLineAddress, pincode, city, district, state, country) {

        if(singleLineAddress== null || pincode == null || city == null || district == null || state == null || country == null ){
            document.getElementById("errMessage").innerHTML="All Fields are required."
        }

        var data = {
            singleLineAddress: singleLineAddress,
            pincode: pincode,
            city: city,
            district: district,
            state: state,
            country: country
        }
        $http.post("https://localhost:44364/api/Address", JSON.stringify(data))
            .then((response1) => {
                console.log(response1);
                if (response1) {
                 $scope.address = response1.data.data;
                }
            }, (error) => {
                console.log(error)
            })
    }
});