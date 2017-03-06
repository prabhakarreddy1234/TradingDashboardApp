
angularFormsApp.factory('DataService',
    ["$http",
    function ($http) {

        var getTrades = function () {

            return $http.get("http://localhost:64365/Trades");
        };

        var getTradeById = function (id) {

            return $http.get("http://localhost:64365/Trade/" + id);
        };

        var updateTrade = function (trade, id) {
            return $http.put('http://localhost:64365/Trade/' + id, trade);
        };

        var patchTrade = function (trade, id) {
            var url = 'http://localhost:64365/Trade/' + id;
            return $http({
                url: url,
                dataType: 'json',
                method: 'PATCH',
                data: trade,
                headers: {
                    "Content-Type": "application/json"
                }
            });
            // return $http.patch(url, trade);
        };

        return {
            updateTrade: updateTrade,
            getTrades: getTrades,
            patchTrade: patchTrade,
            getTradeById: getTradeById
        };
    }]);