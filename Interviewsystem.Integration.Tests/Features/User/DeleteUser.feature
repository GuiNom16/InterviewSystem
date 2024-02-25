Feature: Delete user

@deletingUser
Scenario: Successfully deleting a user
    Given I have seleceted the id 1 of the user I want to delete
    When I click the delete button
    Then I will get the message of successful deletion