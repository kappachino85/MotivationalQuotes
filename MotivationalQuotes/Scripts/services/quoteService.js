//quoteService = quoteService || {};

(function () {
    'use strict';

    angular.module(AppName).factory("quoteService", QuoteService);
    QuoteService.$inject = ["$http", "$q"];

    function QuoteService($http, $q) {

        var srv = {
            getAll: _getAll,
            getRand: _getRand,
            getById: _getById,
            post: _post,
            put: _put,
            deleteQuote: _deleteQuote
        };

        return srv;

        function _getAll() {
            return $http.get("/api/quotes")
                .then(getAllSuccess)
                .catch(getAllFailure)

            function getAllSuccess(response) {
                return response;
            }

            function getAllFailure(response) {
                return $q.reject(response);
            }
        }

        function _getRand() {
            return $http.get("/api/quotes/rand")
                .then(getRandSuccess)
                .catch(getRandFailure)

            function getRandSuccess(response) {
                console.log(response.data[0]);
                return response.data[0];
            }

            function getRandFailure(response) {
                return $q.reject(response);
            }
        }

        function _getById(id) {
            return $http.get("/api/quotes/" + id)
                .then(getByIdSuccess)
                .catch(getByIdFailure)

            function getByIdSuccess(response) {
                return response;
            }

            function getByIdFailure(response) {
                return $q.reject(response);
            }
        }

        function _post() {
            return $http.post("/api/quotes")
                .then(postSuccess)
                .catch(postFailure)

            function postSuccess(response) {
                return response;
            }

            function postFailure(response) {
                return $q.reject(response);
            }
        }

        function _put(id) {
            return $http.put("/api/quotes/" + id)
                .then(putSuccess)
                .catch(putFailure)

            function putSuccess(response) {
                return response;
            }

            function putFailure(response) {
                return $q.reject(response);
            }
        }

        function _deleteQuote(id) {
            return $http.delete("/api/quotes/" + id)
                .then(deleteSuccess)
                .catch(deleteFailure)

            function deleteSuccess(response) {
                return response;
            }

            function deleteFailure(response) {
                return $q.reject(response);
            }
        }
    }
})();