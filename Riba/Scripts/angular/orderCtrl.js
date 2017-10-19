(function () {
    var _self, _orderSvc;
    var orderCtrl = function (orderSvc) {
        _orderSvc = orderSvc;
        _self = this;

        _self.getOrders = getOrders;
        _self.addOrder = addOrder;
        _self.init = init;
    }

    orderCtrl.$inject = ['orderSvc'];

    angular.module('order')
        .controller('orderCtrl', orderCtrl);

    function init() {
        resetOrder();
        _self.getOrders();
    }

    function resetOrder() {
        _self.newOrder = {
            orderDate: "",
            customerName: "",
            quantity: "",
            unitPrice: ""
        };
    }

    function addOrder(form) {
        var model = {
            OrderDate: _self.newOrder.orderDate,
            CustomerName: _self.newOrder.customerName,
            Quantity: _self.newOrder.quantity,
            UnitPrice: _self.newOrder.unitPrice
        };

        _orderSvc.addOrder(model)
            .then(function (response) {
                if (response.data.IsSuccess) {
                    _self.message = "The order has been inserted successfully.";
                    _self.errors = [];
                    _self.orders.push(response.data.Data);
                    resetOrder();
                }
                else {
                    _self.message = "";
                    _self.errors = [];
                    _self.errors = response.data.Errors;
                }
            })
            .catch(function (response) {
                _self.message = "";
                _self.errors = [];
                _self.errors.push("An error occurred. Please try again");
            });
    }

    function getOrders() {
        _orderSvc.getOrders()
            .then(function (response) {
                _self.orders = response.data.Data;
            })
            .catch(function (response) {
                _self.orders = [];
            });
    }
}());