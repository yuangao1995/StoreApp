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

        vm.addToCart = function () {
            var cartitem = {};
            cartitem.productid = vm.product.prodId;
            cartitem.CPrice = vm.product.price;
            cartitem.name = vm.product.name;
            $http.post("api/cartitems", cartitem)
                .then(function (response) {
                    vm.inCart.push(response.data);
                }
                , function () {

                });
        };
        //$http({
        //    url: '/api/products',
        //    method: 'GET',
        //    params: vm.Id
        //}).success(function (data) {
        //    vm.product = data;
        //})
    }
})();
