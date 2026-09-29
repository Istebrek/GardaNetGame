*** Settings ***
Name             Navbar  
Documentation    Gårda grupp 4
...              Tests related to the cart page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/navbar.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Searches for a game using the search bar
   [Tags]    ready    sprint_2
   [Documentation]   Verifies that an user only see the games listed with matching name as the search input
   Given I see the search bar
   When I type Moonlighter in the search bar
   Then only games with the name Moonlighter should be displayed in the results


Searches for a game that does not exist
   [Tags]       ready
   [Documentation]   Verifies that an user get a message when no matching name of a game is found
   Given I see the search bar 
   When I type Mario in the search bar
   Then a message of no games found should be displayed

Search games by first letter in navbar
   [Tags]         ready
   [Documentation]  Verifies that when an user types in letter M
    ...             a list of names that starts with letter M i show after input in the search bar
   Given I see the search bar
   When I type the letter M into the search field
   Then all games starting with M should be displayed

Navigate to cart from navbar
   [Tags]   ready 
   Given I see the navbar
   When I click on cart button
   Then I should be redirected to shoppingcart page
   
Navigate to login page from navbar
   [Tags]    ready
   Given I see the navbar
   When I click on login button
   Then I should be redirected to login page

Navigate to register page from navbar
   [Tags]     ready
   Given I see the navbar
   When I click on register button
   Then I should be redirected to register page

Navigate to contact page from navbar
   [Tags]    ready
   Given I see the navbar
   When I click on contact us button
   Then I should be redirected to contact page

Navigate to Home page from navbar
   [Tags]     ready
   Given I see the navbar
   When I click on home button
   Then I should be redirected to home page

Navigate to games page from navbar
   [Tags]    ready
   Given I see the navbar
   When I click on game button
   Then I should be redirected to game page

Navigate to Product page from navbar
   [Tags]     ready
   Given I see the navbar
   When I click on products button
   Then I should be redirected to products page






