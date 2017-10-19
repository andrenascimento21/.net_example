(function () {
    angular.module('order', [])
        .filter("ribaDate", function () {
            return function (x) {
                return new Date(parseInt(x.substr(6)));
            };
        });
}());