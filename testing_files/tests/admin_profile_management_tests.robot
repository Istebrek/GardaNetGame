*** Settings ***
Name             Admin Profile Management Page Tests
Documentation    Gårda grupp 4
...              Tests related to admin customer profiles
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***
Add product to assortment
    [Tags]  not_ready    extra
    [Documentation]    Tests the ability to add a product to the shop.
    ...                User Story:112
    Given I am on my Admin Page
    When I add a product to the assortment
    Then it is available on the product page

Add a game to assortment
    [Tags]  not_ready    extra
    [Documentation]    Tests the ability to add a game to the shop.
    ...                User Story:112
    Given I am on my Admin Page
    When I add a game to the assortment
    Then it is available on the game page

Update product inventory
    [Tags]  not_ready    extra
    [Documentation]    Tests the ability to update product inventory.
    ...                User Story:112
    Given I am on my Admin Page
    When I update the inventory on a product
    Then it is updated in the product availability

Visibility of incomplete purchases
    [Tags]  not_ready    extra
    [Documentation]    Assures incomplete purchases are visable to admin.
    ...                User Story:114
    Given a user has an incomplete purchase
    When the user does not complete the purchase within an hour
    Then the incomplete purchase is logged 
    And the log is visible for the Admin

Visibility of order history
    [Tags]  not_ready    sprint 2
    [Documentation]    Assures completed purchases are visable to admin.
    ...                User Story:109
    Given I have previous orders
    When I navigate to Admin order history
    Then I can see all previous purchases

Admin update of personal details
    [Tags]  not_ready    sprint 2
    [Documentation]    Assures completed purchases are visable to admin.
    ...                User Story:111
    Given I am on my Admin Page
    And I click the edit option
    Then I can update the Admin details 

Create Events
    [Tags]  not_ready    extra
    [Documentation]    Tests the creation of a events.
    ...                User Story:113
    Given I am on the Admin Page
    When I add an event 
    Then it is updated in the events calendar

Creation of promo codes
    [Tags]  not_ready    sprint 2
    [Documentation]    Tests the creation of a promo code.
    ...                User Story:110
    Given I am on the Admin promotions page
    When a promo code is created
    Then the promo code becomes valid for customers to use

View Registered customers
    [Tags]  not_ready    sprint 2
    [Documentation]    Tests the visibility of registered customers.
    ...                User Story:115
    Given there are registered customers
    When I navigate to Admin tools
    Then I can see a list of all registered customers
