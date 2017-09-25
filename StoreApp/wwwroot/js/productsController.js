(function () {
    'use strict';

    angular
        .module("app-products")
        .controller("productsController", productsController);

    function productsController($http) {
        /* jshint validthis:true */
        var vm = this;
         vm.products = [];

        $http.get("api/products")
            .then(function (response) {
                angular.copy(response.data, vm.products)
            }, function () {

            });

       

    }
})();
