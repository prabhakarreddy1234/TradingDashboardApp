
var angularFormsApp = angular.module('TradingDashboardApp', ["ngRoute", "ui.bootstrap", "ui.grid","ui.grid.edit"]);

angularFormsApp.config(["$routeProvider", "$locationProvider","$httpProvider",
    function ($routeProvider, $locationProvider, $httpProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "app/views/Home.html",
            controller: "HomeController"
        })
        .otherwise({
            redirectTo: "/home"
        });

        $httpProvider.defaults.headers.patch = {
            'Content-Type': 'application/json;charset=utf-8'
        };
    }]);


