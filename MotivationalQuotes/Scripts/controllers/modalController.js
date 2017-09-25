(function () {
    'use strict';

    angular.module(AppName).controller('modalController', ModalController);

    ModalController.$inject = ['quoteService', '$scope', '$location', '$uibModalInstance', 'edit'];

    function ModalController(quoteService, $scope, $location, $uibModalInstance, edit) {
        var vm = this;

        vm.quoteService = quoteService;
        vm.edit = edit;
        vm.$scope = $scope;
        vm.cancel = _cancel;
        vm.save = _save;
        vm.$uibModalInstance = $uibModalInstance;

        vm.quotes = [];

        function _save(data) {
            if (data.hasOwnProperty('id')) {
                //update
                vm.quoteService.put(data.id, data);
            } else {
                //insert
                vm.quoteService.post(data).then(function () {
                    vm.quoteService.getAll();
                }).catch(function (ex) {
                    console.log(ex);
                })
            }
            vm.quotes = null;
            vm.$uibModalInstance.close();
        }

        function _cancel() {
            vm.$uibModalInstance.dismiss("cancel");
        }

    }
})();