(function () {
    'use strict';

    angular
        .module('myApp.common')
        .service('PersonService', PersonService);

    PersonService.$inject = ['$http'];

    function PersonService($http) {
        this.getPersons = getPersons;
        this.addPerson = addPerson;
		this.updatePerson = updatePerson;

        function getPersons() {
             return $http({
                method: 'GET',
                url: 'http://localhost:3928/api/person',
				headers: {
					"Content-Type": "application/json" 
				}
            });
        }
        function addPerson(person) {
             return $http({
                method: 'POST',
                url: '/api/person',
                data: person
            });
        }
		function updatePerson(person){
			var Person = new Object(); 
			Person.PersonId = person.personId;
			Person.FirstName = person.firstName;  
			Person.LastName = person.lastName;  
			Person.JobTitle = person.jobTitle; 
        
			return $http({
                method: 'POST',
                url: 'http://localhost:3928/api/person',
				headers: {
					'Content-Type': 'application/json'
				},
                data: Person
            });
			
		}
    }
})();