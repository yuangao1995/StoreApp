﻿(function () {
    'use strict';

    angular
        .module('app-cart')
        .controller('cartItemsController', cartItemsController);

    function cartItemsController($http) {
        /* jshint validthis:true */
        var vm = this;

        vm.cartItems = [];

        $http.get("/api/cartitems")
            .then(function (response) {
                angular.copy(response.data, vm.cartItems)
            }, function () {

            });
        vm.delete = function (Id) {
            $http.delete("/api/cartitems/"+ Id)
                .then(function (response) {
                    if (response.data)
                        alert("Item removed");
                        location.reload();
                }
                , function () {
                });

        }
    }
})();
