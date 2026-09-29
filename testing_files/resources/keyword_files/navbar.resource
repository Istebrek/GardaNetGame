*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_navbar.py
Variables        ../page_object_models/variables_login.py
Documentation    keywords used for navbar testing

*** Keywords ***

I see the search bar
   [Tags]    Sprint 2
   Page Should Contain Element        ${sök_spel}

I type Moonlighter in the search bar
   [Tags]     Sprint 2
   Input Text    ${sök_spel}    Moonlighter
only games with the name Moonlighter should be displayed in the results
   [Tags]      Sprint 2
   Wait Until Page Contains    Moonlighter
   Page Should Contain    Moonlighter
   Sleep     2
   Page Should Not Contain    Undertale
    
I type Mario in the search bar
   [Tags]       Sprint 2
   Input Text   ${sök_spel}    Mario

a message of no games found should be displayed
   [Tags]      Sprint 2
   Wait Until Page Contains    Inga träffar    timeout=10s

I type the letter M into the search field
   [Tags]       Sprint 2
   Input Text    ${sök_spel}      M

all games starting with M should be displayed
   [Tags]      Sprint 2
   Wait Until Page Contains    Moonlighter    timeout=10s
   Page Should Contain         My Time at Portia
   Page Should Contain         Mass Effect (2007)

I see the navbar
   [Tags]    Sprint 2
   Page Should Contain Element        ${navbar}
I click on cart button
   [Tags]    Sprint 2
   Click Element    css=a[href="/shoppingcart"]
   
I should be redirected to shoppingcart page
   [Tags]   Sprint 2
   Location Should Contain    /shoppingcart

I click on login button
   [Tags]    Sprint 2
   Wait Until Element Is Visible    ${customer_navbar_locator}
   Mouse Over    ${customer_navbar_locator}
   Click Link       Logga In

Then I should be redirected to login page
   [Tags]    Sprint 2
   Location Should Contain    /Account/Login

I click on register button
   [Tags]    Sprint 2
   Wait Until Element Is Visible    ${customer_navbar_locator}
   Mouse Over    ${customer_navbar_locator}
   Click Link      Registrera  

I should be redirected to register page
   [Tags]   Sprint 2
   Location Should Contain    /Account/Register

I click on contact us button
   [Tags]    Sprint 2
   Wait Until Element Is Visible    ${site_navigation_dropdown}
   Mouse Over    ${site_navigation_dropdown}
   Click Link    Kontakta Oss
   
I should be redirected to contact page
   [Tags]   Sprint 2
   Location Should Contain   /contactus

I click on home button
   [Tags]   Sprint 2
   Wait Until Element Is Visible    ${site_navigation_dropdown}
   Mouse Over    ${site_navigation_dropdown}
   Click Link    Hem

I should be redirected to home page
   [Tags]  Sprint 2
   Location Should Be    https://gardanetgame-dev.azurewebsites.net/

I click on game button
   [Tags]    Sprint 2
   Wait Until Element Is Visible    ${site_navigation_dropdown}
   Mouse Over    ${site_navigation_dropdown}
   Click Link    Spel

I should be redirected to game page
   [Tags]    Sprint 2
   Location Should Contain    /game

I click on products button
   [Tags]   Sprint 2
   Wait Until Element Is Visible    ${site_navigation_dropdown}
   Mouse Over    ${site_navigation_dropdown}
   Click Link   Gamingtillbehör
I should be redirected to products page
   [Tags]   Sprint 2
   Location Should Contain    /physicalProduct


