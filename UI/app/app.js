'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'myApp.common',
  'myApp.person',
  'ngRoute',
  'myApp.view1',
  'myApp.view2',
  'myApp.version',
  'angularModalService'
]).
//controller('PersonController', PersonController).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');

  $routeProvider.otherwise({redirectTo: '/view1'});
}]);
