Feature: Updating user

@updatingUser
Scenario: Updating a user's information
    Given I have changed the user's role
    | UserId | Profile |
    | 1      | 1       |
    When I click on save button
    Then I will get a success message