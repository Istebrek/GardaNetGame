*** Settings ***
Name             Customer Profile Management Page Tests
Documentation    Gårda grupp 4 
...              Tests related to managing customer profiles
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Customers ability to logout
    [Tags]  not_ready    sprint_2
    [Documentation]    Confirms a customer is able to logout.
    Given I am logged in as a customer
    When I click the logout button
    Then I am successfully logged out

Customer's visibility of personal order history
    [Tags]  not_ready    sprint_2
    [Documentation]    Confirms the visibility of a customers order history.
    ...                User story: 102
    Given I have made previous purchases
    And I navigate to my profile page
    When I click on Order History
    Then I see a summary of my previously placed orders

Customer receives personalized recommendations
    [Tags]  not_ready    sprint_2
    [Documentation]    Confirms the customer recommendations are visable on the customer profile.
    ...                User story: 97
    Given I have made previous purchases
    When I navigate to my profile page
    Then I want to see customized product suggestions

Customer ability to change information
    [Tags]  not_ready    sprint_2
    [Documentation]    Confirms a customer is able to change their personal information.
    ...                User story: 96
    Given I am on my account management page
    When I change my details
    Then my details are updated

Customer password reset
    [Tags]  not_ready    extra
    [Documentation]    Confirms a customer is able to change their password.
    ...                User story: 151
    Given I am on my account management page
    When I change my password
    Then my login password is successfully changed

