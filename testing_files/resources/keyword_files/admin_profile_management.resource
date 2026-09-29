*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Documentation    keywords used for admin profile testing

*** Keywords ***
I add a ${product_type} to the assortment
    [Tags]  sprint 2

it is available on the ${product_type} page
    [Tags]  sprint 2

I update the inventory on a product
    [Tags]  sprint 2

it is updated in the product availability
    [Tags]  sprint 2

a user has an incomplete purchase
    [Tags]  sprint 2

the user does not complete the purchase within an hour
    [Tags]  sprint 2

the incomplete purchase is logged 
    [Tags]  sprint 2

the log is visible for the Admin
    [Tags]  sprint 2

I have previous orders
    [Tags]  sprint 2

I navigate to Admin order history
    [Tags]  sprint 2

I can see all previous purchases
    [Tags]  sprint 2

I click the edit option
    [Tags]  sprint 2

I can update the Admin details 
    [Tags]  sprint 2

I add an event 
    [Tags]  sprint 2

it is updated in the events calendar
    [Tags]  sprint 2

I am on the Admin promotions page
    [Tags]  sprint 2

a promo code is created
    [Tags]  sprint 2

the promo code becomes valid for customers to use
    [Tags]  sprint 2

there are registered customers
    [Tags]  sprint 2

I navigate to Admin tools
    [Tags]  sprint 2

I can see a list of all registered customers
    [Tags]  sprint 2