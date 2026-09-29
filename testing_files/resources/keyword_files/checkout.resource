*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Documentation    keywords used for checkout page testing

*** Keywords ***

I am on the checkout page
   [Tags]   sprint 2
   
I have items in the cart
   [Tags]  sprint 2

I fill in payment and shipping form
   [Tags]     sprint 2

click on the pay button
   [Tags]        sprint 2

the purchase should be completed successfully
   [Tags]     sprint 2

I should see a confirmation message
   [Tags]     sprint 2

I try to submit empty checkout form
   [Tags]    sprint 2

an error message should be displayed
   [Tags]   sprint 2

I select Pay in store as the payment method
   [Tags]     sprint 2

the option should be selected
   [Tags]     sprint 2

I should be able to place the order without entering online payment details
   [Tags]     sprint 2

I select Klarna as online payment method  
   [Tags]     sprint 2   

complete the payment
   [Tags]     sprint 2

the purchase should be successful
   [Tags]    sprint 2

I should be redirected to a confirmation page
   [Tags]    sprint 2

I enter a valid discount code
   [Tags]    extra

I click on Apply button
   [Tags]    extra

the discount should be applied to the total price
   [Tags]     extra

I enter an invalid discount code
   [Tags]    extra


   




