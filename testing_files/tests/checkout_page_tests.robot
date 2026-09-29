*** Settings ***
Name             Checkout Page 
Documentation    Gårda grupp 4
...              Tests related to the checkout page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/checkout.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Complete checkout with valid details
   [Tags]    not_ready    sprint_2
   [Documentation]    Verifies that a user can complete a purchase with vaild details  
   ...                User story:98
   Given I am on the checkout page
   And I have items in the cart
   When I fill in payment and shipping form
   And click on the pay button
   Then the purchase should be completed successfully
   And I should see a confirmation message

Attempt checkout with missing information
   [Tags]    not_ready    sprint_2
   [Documentation]   Verifies that a user can't complete a purchase without filling in required fields
   ...               User story: 98
   Given I am on the checkout page
   When I try to submit empty checkout form
   Then an error message should be displayed

Select pay in store option
   [Tags]    not_ready    extra
   [Documentation]   Verifies that a user can choose payment method to pay in store 
   ...               User story:212
   Given I am on the checkout page
   When I select Pay in store as the payment method
   Then the option should be selected
   And I should be able to place the order without entering online payment details

Select and complete payment using Klarna as online method
   [Tags]    not_ready    extra
   [Documentation]     Verifies that a user can choose Klarna as online payment metod successfully 
   ...                 User story:216
   Given I am on the checkout page
   When I select Klarna as online payment method 
   And complete the payment
   Then the purchase should be successful
   And I should be redirected to a confirmation page

Apply valid discount code
   [Tags]    not_ready    extra
   [Documentation]    Verifies that when a user adds a discount code it applies to the total price 
   ...                User Story:215
   Given I have items in the cart
   And I am on the checkout page
   When I enter a valid discount code
   And I click on Apply button
   Then the discount should be applied to the total price

Enter invalid discount code
   [Tags]    not_ready    extra
   [Documentation]    Verifies that a error message is displayed when a user enters a invalid discount code 
   ...                User story:215
   Given I am on the checkout page
   When I enter an invalid discount code
   Then an error message should be displayed
