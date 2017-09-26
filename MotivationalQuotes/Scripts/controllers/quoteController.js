(function () {
    'use strict';

    angular.module(AppName).controller('quoteCtrl', QuoteCtrl);
    QuoteCtrl.$inject = ['quoteService', '$scope', '$location', '$window', '$uibModal'];

    function QuoteCtrl(quoteService, $scope, $location, $window, $uibModal) {
        var vm = this;
        vm.quoteService = quoteService;
        vm.$scope = $scope;
        vm.$window = $window;
        vm.$location = $location;
        vm.$uibModal = $uibModal;

        vm.render = _render;
        vm.editPage = _editPage;
        vm.randomQuote = _randomQuote;
        vm.getAllQuotes = _getAllQuotes;
        vm.selectQuote = _selectQuote;
        vm.deleteQuote = _deleteQuote;
        vm.postQuote = _postQuote;

        vm.quotes = [];

        function _render() {
            vm.$scope.template = 'quotePage';
            _randomQuote();
        }

        function _randomQuote() {
            return vm.quoteService.getRand().then(function (data) {
                vm.quotes = data;
            })
        }

        function _editPage() {
            vm.$scope.template = 'editPage';
            _getAllQuotes();
        }

        function _getAllQuotes() {
            return vm.quoteService.getAll().then(function (data) {
                vm.quotes = data;
            })
        }

        function _postQuote() {
            var itm = {};
            vm.quote = itm;

            var modalInstance = vm.$uibModal.open({
                templateUrl: 'quoteModal',
                controller: 'modalController as mCtrl',
                animation: true,
                size: 'md',
                resolve: {
                    edit: function () {
                        return itm;
                    }
                }
            });

            modalInstance.result.then(function () {
                _getAllQuotes();
            },function () {});
        }

        function _selectQuote(itm) {
            vm.quote = itm;

            var modalInstance = vm.$uibModal.open({
                templateUrl: 'quoteModal',
                controller: 'modalController as mCtrl',
                animation: true,
                size: 'md',
                resolve: {
                    edit: function () {
                        return itm;
                    }
                }
            });

            modalInstance.result.then(function () { }, function () { });
        }

        function _deleteQuote(itm) {
            vm.quote = itm;

            var modalInstance = vm.$uibModal.open({
                templateUrl: 'deleteModal',
                controller: 'modalController as mCtrl',
                animation: true,
                size: 'md',
                resolve: {
                    edit: function () {
                        return itm;
                    }
                }
            });
            modalInstance.result.then(function () { }, function () { });
        }
    }
})();