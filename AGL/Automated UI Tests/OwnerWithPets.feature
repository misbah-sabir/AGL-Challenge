Feature: OwnerWithPets
	
@OwnerWithPets
Scenario: Check the owners with Cats
	Given I have a list of owners by calling 'people.json' api
	When I find the list of only owners with pet as 'Cat' as Pet by calling 'people.json' api
	And I find a list of 'male' owners of pet as 'Cat' by calling 'people.json' api
	And I find a list of 'female' owners of pet as 'Cat' by calling 'people.json' api
	And I find the name of pet as 'Cat' for 'male' owners by calling 'people.json' api
	And I find the name of pet as 'Cat' for 'female' owners by calling 'people.json' api
