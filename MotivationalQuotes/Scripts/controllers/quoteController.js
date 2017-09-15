(function () {
    'use strict';

    angular.module(AppName).controller('quoteCtrl', QuoteCtrl);
    QuoteCtrl.$inject = ['quoteService', '$scope', '$location', '$window'];

    function QuoteCtrl(quoteService, $scope, $location, $window) {
        var vm = this;
        vm.quoteService = quoteService;
        vm.$scope = $scope;
        vm.$window = $window;
        vm.$location = $location;

        vm.randomQuote = _randomQuote;
        //vm.getAllQuotes = _getAllQuotes;
        //vm.selectQuote = _selectQuote;
        //vm.deleteQuote = _deleteQuote;
        //vm.updateQuote = _updateQuote;
        //vm.postQuote = _postQuote;

        vm.quotes = [];

        _randomQuote();

        function _randomQuote() {
            return vm.quoteService.getRand().then(function (data) {
                vm.quotes = data;
            })
        }
    }
})();