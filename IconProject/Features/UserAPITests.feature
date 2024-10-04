Feature: User API Tests

  Scenario: Validate users API response with page=1
    Given I send a GET request to "https://reqres.in/api/users?page=1"
    Then response status code should be 200
    And response should contain 6 users
    And page number should be 1
    And user with first name "Janet", last name "Weaver", email "janet.weaver@reqres.in", and avatar URL "https://reqres.in/img/faces/2-image.jpg" should be present

  Scenario: Validate users API response with page=2
    Given I send a GET request to "https://reqres.in/api/users?page=2"
    Then response status code should be 200
    And response should contain 6 users
    And page number should be 2
    And user with first name "Byron", last name "Fields", email "byron.fields@reqres.in", and avatar URL "https://reqres.in/img/faces/10-image.jpg" should be present

  Scenario: Validate users API response with a non-existent page=12
    Given I send a GET request to "https://reqres.in/api/users?page=12"
    Then response status code should be 200
    And no users should be returned
