(function () {
    'use strict';

   var app = angular.module('myApp.person', ['angularModalService'])
   //app.controller('PersonController', PersonController);

    //PersonController.$inject = ['PersonService'];

	app.controller('PersonController', function($scope, ModalService, PersonService) {
    
		var self = this;
		
        
		self.person = {};
		self.persons = [];
		self.update = function(person){
			console.log(person);
			PersonService.updatePerson(person).success(function(response) {
				
				location.reload();
			});
			

		}

        self.addPerson = addPerson;
		self.updatePersonDialog = updatePersonDialog; 
		
		
		
		function addPerson() {
            var p = {
                jobTitle: vm.p.jobTitle
            }

            PersonService.addPerson(p).then(function() {
                PersonService.getPersons().success(function(response) {
                    vm.persons = response;
                });
            });
        }
		
		function updatePersonDialog(person)
		{
			ModalService.showModal({
				templateUrl: "edit-person-dialog.html",
				controller: "ModalController",
				inputs: {
					person: person
				}
				
			}).then(function(modal) {
				//bootstrap element, use 'modal' to show it
				modal.element.modal();
				modal.close.then(function(result) {
					console.log(result);
				});
			});
			
			
		}
        function _activate() {
			PersonService.getPersons().success(function(response) {
				self.persons = response;
			});
        }


        _activate();
    });
	
	app.controller('ModalController', ['$scope', 'person', function($scope, person) {
		$scope.person = person;
		$scope.save = function(e){
			console.log(e);
		}
	 //$scope.close = function(result) {
	//	close(result, 500); // close, but give 500ms for bootstrap to animate
	// };

	}]);

	
	
})();