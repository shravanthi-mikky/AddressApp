var app=angular.module("AddressApp",['ngRoute','ngStorage','ngTouch','ngAnimate','ui.bootstrap']);

 app.config(["$routeProvider",function($routeProvider){

$routeProvider.
 
when("/Dashboard",{
    templateUrl:"/Dashboard/Dashboard.html",
    controller:"DashboardCtrl"
}).
otherwise({
    redirectTo:"/Dashboard"
    });
    }]); 