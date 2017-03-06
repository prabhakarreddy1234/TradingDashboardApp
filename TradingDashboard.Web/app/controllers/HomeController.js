
angularFormsApp.controller("HomeController",
    ["$scope", "$location", "DataService",
    function ($scope, $location, DataService) {
        $scope.gridOptions = {};
        DataService.getTrades().then(
            function (results) {
                // on success
                $scope.gridOptions.data = results.data;
            },
            function (results) {
                // on error
                console.log(results.data);
            }
        );

        $scope.gridOptions = {
            columnDefs: [
                { name: 'contract', enableCellEdit: false, displayName: 'Contract', width: '20%' },
                { name: 'symbol', enableCellEdit: false, displayName: 'Symbol', width: '15%' },
                { name: 'exchange', enableCellEdit: false, displayName: 'Exchange', width: '15%' },
                { name: 'type', enableCellEdit: false, displayName: 'Type', width: '10%' },
                { name: 'price', enableCellEdit: true, displayName: 'Price', width: '10%' },
                { name: 'volume', enableCellEdit: true, displayName: 'Volume', width: '10%' },
                { name: 'investedAmount', enableCellEdit: false, displayName: 'Amount', width: '20%' }
            ],
            enableSorting: false
        }

        $scope.gridOptions.onRegisterApi = function (gridApi) {
            //set gridApi on scope
            $scope.gridApi = gridApi;
            gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                if (newValue === oldValue) return;
                rowEntity.investedAmount = rowEntity.price * rowEntity.volume;
                DataService.updateTrade(JSON.stringify(rowEntity), rowEntity.id)
                    .then(
                        function (data) {
                            console.log('success');
                        },
                        function (data) {
                            console.log('try again');
                        });
                $scope.$apply();
            });
        };
    }]);