Feature: Create User

@creatingNewUser
Scenario: Creating a new user
	Given I have entered my information
	| UserId | FirstName | LastName | Email             | Password     |
	| 1      | John      | Doe      | Johndoe@gmail.com | Password@123 |
	When I click on register button
	Then the system should respond with a success message