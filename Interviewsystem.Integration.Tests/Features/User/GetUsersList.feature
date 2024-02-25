Feature: List all users

@listAllUsersTag
Scenario: Listing all users
	Given I have these users in my Database
	| UserId | Fullname | Login             | Profile |
	| 8      | John Doe | johndoe@gmail.com | 1       |
	| 9      | Jane Doe | janedoe@gmail.com | 0       |
	| 10     | Mike Doe | mikedoe@gmail.com | 0       |
	When I access the role page, a call back to endpoint is made
	Then response should be true and I need to have the following info:
	| UserId | Fullname | Login             | Profile |
	| 8      | John Doe | johndoe@gmail.com | 1       |
	| 9      | Jane Doe | janedoe@gmail.com | 0       |
	| 10     | Mike Doe | mikedoe@gmail.com | 0       |