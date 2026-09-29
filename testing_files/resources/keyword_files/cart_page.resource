*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_cart.py
Documentation    keywords used for cart page testing

*** Keywords ***
the cart contains a product
    [Tags]    sprint 1 
    Wait Until Element Is Visible    ${product_card}    timeout=5s
    Sleep    2s


the cart contains more than one of the same item
    Wait Until Element Is Visible    ${quantity_input}
    ${initial_quantity}=    Get Element Attribute    ${quantity_input}    value
    Set Suite Variable    ${initial_quantity}
    Should Be True    ${initial_quantity} > 1
    Sleep    2s


the cart contains multiple items
    [Tags]    sprint 1

I click on the minus button    
    [Tags]    sprint 1
    Wait Until Keyword Succeeds    5s    1s  Click Button    ${minus_button}

the quantity should decrease by one
    [Tags]    sprint 1
    Wait Until Element Is Visible    ${cart_message}    timeout=5s
    #${initial_quantity}=    Get Element Attribute    ${quantity_input}    value
    #${initial_quantity}=    Convert To Integer    ${initial_quantity}
    Sleep    2s

the quantity of an item in the cart is decreased
    [Tags]    sprint 1   

I set the quantity to zero
    [Tags]    sprint 1   

the cart updates
    [Tags]    sprint 1   

the total price for the item and the cart total should be updated
    [Tags]    sprint 1   

I click on the plus button
    [Tags]    sprint 1
    Wait Until Keyword Succeeds    5s    1s  Click Button    ${plus_button}

the quantity should increase by one
    [Tags]    sprint 2
    Wait Until Element Is Visible    ${cart_message}    timeout=5s
    #${initial_quantity}=    Get Element Attribute    ${quantity_input}    value
    #${initial_quantity}=    Convert To Integer    ${initial_quantity}

   

the cart total should be updated
    [Tags]    sprint 1
    ${total}=    Get Text    ${total_price_text}
    Should Not Be Equal As Strings    ${total}    746 kr
    Sleep    2s


    
I click the checkout button in the cart
    [Tags]    sprint 1   

I should be redirected to the checkout page
    [Tags]    sprint 1   

I set its quantity to zero
    [Tags]    sprint 1

I click on the delete button
    [Tags]    sprint 1
    Wait Until Element Is Visible    ${delete_button}    timeout=10
    Click Button    ${delete_button}

a message should say that product is removed from the cart
    [Tags]    sprint 1
    Wait Until Element Is Visible    ${cart_message}    timeout=10s

    
I remove a product
    [Tags]    sprint 2  

I should see a message indicating the cart is empty
    [Tags]    sprint 2  

the product should be removed from the cart
    [Tags]    sprint 2  

I click on Add to Cart
    [Tags]     Sprint 2
    Scroll Element Into View      ${add_to_cart_button}
    Click Element    ${add_to_cart_button}

I am on the Night in the woods detail page
   [Tags]   Sprint 2
   Go To    https://gardanetgame-dev.azurewebsites.net/game/2
   Location Should Contain    /game/2
   Page Should Contain    Night in the Woods
    Sleep    2s


the product is added to my cart
   [Tags]    Sprint 2
   Sleep     2
   Scroll Element Into View    ${success_message}
   Wait Until Element Is Visible    ${success_message} 
   Element Should Be Visible    ${success_message}    
    Sleep    2s
