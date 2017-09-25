(function () {
    'use strict';

    angular
        .module("app-products")
        .controller("productsDetailController", productsDetailController);

    function productsDetailController($routeParams, $http, $window, $location) {
        var vm = this;
        vm.cartitem = {};
        vm.Id = $routeParams.product;

        $http.get("api/products/" + vm.Id)
            .then(function (response) {
                vm.product = response.data;
            }, function () {

            });

        vm.addToCart = function () {
            vm.cartitem.productid = vm.product.prodId;
            vm.cartitem.CPrice = vm.product.price;
            vm.cartitem.name = vm.product.name;
            $http.post("api/cartitems", vm.cartitem)
                .then(function (response) {
                    vm.inCart.push(response.data);
                    vm.cartitem = {};
                }
                , function () {

                });
        };

        vm.alert = function () {
            alert("Product has been added to your shopping cart!");
        };
    }
})();
