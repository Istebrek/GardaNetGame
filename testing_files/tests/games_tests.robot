*** Settings ***
Name             Games Tests
Documentation    Gårda grupp 4
...              Tests related to the games page.
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/games_page.resource
Resource         ../resources/keyword_files/filters.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Sort Games by PEGI_3 Age Restriction
   [Tags]    ready    sprint_2
   [Documentation]  Tests sort function for age restrictions. 
    ...              User story: 125
   Given I am on the games page
   And the unfiltered products are logged by name
   And I click the filter button 
   When I filter by PEGI_3 age restriction
   Then the games should be filtered

Sort Games by PEGI_7 Age Restriction
   [Tags]    ready    sprint_2
   [Documentation]  Tests sort function for age restrictions. 
    ...              User story: 125
   Given I am on the games page
   And the unfiltered products are logged by name
   And I click the filter button 
   When I filter by PEGI_7 age restriction
   Then the games should be filtered

Sort Games by PEGI_12 Age Restriction
    [Tags]    ready    sprint_2
   [Documentation]  Tests sort function for age restrictions. 
    ...              User story: 125
   Given I am on the games page
   And the unfiltered products are logged by name
   And I click the filter button 
   When I filter by PEGI_12 age restriction
   Then the games should be filtered

Sort Games by PEGI_16 Age Restriction
   [Tags]    ready    sprint_2
   [Documentation]  Tests sort function for age restrictions. 
    ...              User story: 125
   Given I am on the games page
   And the unfiltered products are logged by name
   And I click the filter button 
   When I filter by PEGI_16 age restriction
   Then the games should be filtered

Sort Games by PEGI_18 Age Restriction
   [Tags]    ready    sprint_2
   [Documentation]  Tests sort function for age restrictions. 
    ...              User story: 125
   Given I am on the games page
   And the unfiltered products are logged by name
   And I click the filter button 
   When I filter by PEGI_18 age restriction
   Then the games should be filtered
   
 Sort Games by Genre
   [Tags]    ready    sprint_2
   [Documentation]  Tests sort function by Genre. 
   ...              User story: 129
   Given I am on the games page
   And the unfiltered products are logged by name
   When I click the filter button
   And I search by genre
   Then the games should be filtered

Sort Games by Title A-Z
   [Tags]    ready    sprint_1
   [Documentation]  Tests sort function by alphabetical order A-Z. 
   ...              User story: 136
   Given I am on the games page
   And I click the filter button 
   When I click the name sort button twice
   Then the products should be displayed in ascending alphabetical order

Sort Games by Title Z-A
   [Tags]    ready    sprint_1
   [Documentation]  Tests sort function by alphabetical order Z-A. 
   ...              User story: 136
   Given I am on the games page
   And I click the filter button 
   When I click the name sort button
   Then the products should be displayed in descending alphabetical order

Sort Games by Price Ascending
   [Tags]    ready    sprint_1
   [Documentation]  Tests sort function by price, lowest to highest. 
   ...              User story: 129
   Given I am on the games page
   And I click the filter button 
   When I click the price sort button twice
   Then the products should be displayed in ascending price order

Sort Games by Price Decending
   [Tags]    ready    sprint_1
   [Documentation]  Tests sort function by price, highest to lowest. 
   ...              User story: 129
   Given I am on the games page
   And I click the filter button 
   When I click the price sort button
   Then the products should be displayed in descending price order

Search by Game Title
   [Tags]    ready    sprint_2
   [Documentation]  Tests search function by game title. 
   Given I am on the games page
   And I click the filter button 
   When I search for a game title
   Then the products with the searched title should be displayed

Clear game filters
   [Tags]    ready    sprint_2
   [Documentation]  Tests clear filters function. 
   Given I am on the games page
   And the unfiltered products are logged by name
   When I have used a filter
   And I clear the game filter
   Then the page should be unfiltered

