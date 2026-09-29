*** Settings ***
Name             Cart Page 
Documentation    Gårda grupp 4
...              Tests related to the cart page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/cart_page.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***
Decrease product quantity
   [Tags]    ready    sprint_1
   [Documentation]  Verifies that the product quantity of an item in the cart decrease by one 
   ...              when clicking on the minus button
   ...              User story: 239               
   Given I am on the shoppingcart page
   And the cart contains more than one of the same item
   When I click on the minus button
   Then the quantity should decrease by one

Increase product quantity
   [Tags]    ready    sprint_1
   [Documentation]   Verifies that when the user increases the quantity of a product in the cart 
   ...               the quantity and the total price updates correctly.
   ...               User story: 202
   Given I am on the shoppingcart page
   And the cart contains a product  
   When I click on the plus button
   Then the quantity should increase by one

Remove a product from the cart
   [Tags]    ready    sprint_1
   [Documentation]    Verifies that when a user clicks on remove button 
   ...                the product gets removed from the cart
   ...                User story: 203
   Given I am on the shoppingcart page 
   And the cart contains a product
   When I click on the delete button
   Then a message should say that product is removed from the cart

Update cart totals after removing a product
   [Tags]    not_ready    sprint_1
   [Documentation]    Verifies when the cart refreshes after a product is removed 
    ...               the total cost and cart updates correctly
    ...               User story: 203
   Given I am on the shoppingcart page
   And the cart contains a product
   When I click on the plus button
   Then the cart total should be updated

Update cart totals after quantity change
   [Tags]    not_ready    sprint_1
   [Documentation]   Verifies that the total price in the cart updates 
   ...               after the quantity of an item in the cart is decreased.
   ...               User story: 239
   Given I am on the shoppingcart page
   And the quantity of an item in the cart is decreased
   When the cart updates
   Then the total price for the item and the cart total should be updated

Redirect to checkout page
   [Tags]    not_ready    sprint_1
   [Documentation]  Verifies that the user can navigate from the cart to checkout  
   ...              User story: 200
   Given I am on the shoppingcart page
   And the cart contains a product
   When I click the checkout button in the cart
   Then I should be redirected to the checkout page

Remove product automatically when quantity is set to zero
   [Tags]    not_ready    sprint_1
   [Documentation]   Verifies that when the product quantity in cart is set to zero 
   ...               the product is auto removed from cart
   ...               User story: 246
   Given I am on the shoppingcart page 
   And the cart contains a product
   When I set its quantity to zero
   Then the product is removed from the cart

Update cart totals after product removal
   [Tags]    not_ready    sprint_1
    [Documentation]   Verifies when the cart refreshes after a product is auto removed 
    ...               the total cost and cart updates correctly
    ...               User story: 246
    Given the product is be removed from the cart
    When I refresh the cart page
    Then the quantity and the cart total should be updated

Display empty cart message when the last products quantity is set to zero
   [Tags]    not_ready    sprint_1
   [Documentation]    Verifies that when the cart becomes empty after auto removal 
   ...                a message should show to indicate the cart is empty
   ...                User story: 246
   Given the cart contains a product
   When I set the quantity to zero
   Then I should see a message indicating the cart is empty

Display empty cart message when the last product is removed
   [Tags]    not_ready    sprint_1
   [Documentation]   Verifies that when the cart becomes empty after removal 
   ...               a message should show to indicate the cart is empty
   ...               User story: 203
   Given the cart contains a product
   When I delete the product
   Then I should see a message indicating the cart is empty

Add to Cart button in Game detail page
   [Tags]    not_ready    sprint_1
   [Documentation]  Tests the add to cart button on the Night in the woods detail page. 
    ...             User story: 287
    Given I am on the Night in the woods detail page
    When I click on Add to Cart
    Then the product is added to my cart

Add to Cart button in Product page
   [Tags]    not_ready    sprint_1
   [Documentation]  Tests the add to cart button on the Physical products page. 
    ...             User story: 
    Given I am on the products page
    When I click on Add to Cart
    Then the product is added to my cart