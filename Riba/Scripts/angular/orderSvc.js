(function () {
    var orderSvc = function ($http) {
        var getOrders = function () {
            return $http.get('/order/getOrders');
        }
        var addOrder = function (model) {
            return $http.post('/order/addOrder', model);
        }

        return {
            addOrder: addOrder,
            getOrders: getOrders
        };
    }

    orderSvc.$inject = ['$http'];
    angular.module('order')
        .factory('orderSvc', orderSvc);
}());