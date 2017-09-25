(function () {
    "use strict";
    angular.module("app-products", ["ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "productsController",
                controllerAs: "vm",
                templateUrl: "/views/productsView.html"
            });

            $routeProvider.when("/detail/:product", {
                controller: "productsDetailController",
                controllerAs: "vm",
                templateUrl: "/views/productsDetailView.html"
            })

            $routeProvider.otherwise({ redirectTo: "/" });
        });

})();