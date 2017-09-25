(function () {
    'use strict';

    angular
        .module("app-products")
        .controller("productsDetailController", productsDetailController);

    function productsDetailController($routeParams, $http) {
        var vm = this;

        vm.Id = $routeParams.product;

        //vm.product = null;

        //$http({url: "api/products", method:"GET", params: vm.Id})
        //    .then(function (response) {
        //        angular.copy(response.data, vm.product)
        //    }, function () {

        //    });
        $http.get("api/products/" + vm.Id)
            .then(function (response) {
                //angular.copy(response.data, vm.product)
                vm.product = response.data;
            }, function () {

            });

        //$http({
        //    url: '/api/products',
        //    method: 'GET',
        //    params: vm.Id
        //}).success(function (data) {
        //    vm.product = data;
        //})
    }
})();
