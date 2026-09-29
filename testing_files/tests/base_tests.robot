*** Settings ***
Name             Base Tests
Documentation    Gårda grupp 4 
...              Tests related to basic functions on the website, such as register and login.
Library           SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Register and Confirm Customer
    [Tags]    ready     sprint_1
    [Documentation]    Tests the registration of a new customer.
    ...                User story: 158
    Given I am on the register page
    And I enter a unique username and password
    When I click the register button
    And I confirm my email
    Then I am successfully registered and my email is confirmed

Customer Cannot Register With Same Username
    [Tags]    ready    sprint_1
    [Documentation]    Confirms the user must have a unique username. 
    ...                User story: 158
    Given I am on the register page
    When I enter a username that is already registered
    And I click the register button
    Then I cannot create an account

Customer Login
    [Tags]    ready    sprint_1
    [Documentation]    Tests the customer login function.
    ...                User story: 154
    Given I am on the login page
    When I enter my customer username and password
    And click the login button
    Then I am successfully logged in

Admin Login
    [Tags]    ready    sprint_1
    [Documentation]    Tests that an admin can log in.
    ...                User story: 153
    Given I am on the login page
    When I enter my admin username and password
    And click the login button
    Then I am successfully logged in
    