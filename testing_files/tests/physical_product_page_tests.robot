*** Settings ***
Name             Physical Product Page 
Documentation    Gårda grupp 4
...              Tests related to displaying physical products
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/product_page.resource
Resource         ../resources/keyword_files/games_page.resource
Resource         ../resources/keyword_files/filters.resource
Test Setup       Open the Website
Test Teardown    Close Browser

*** Test Cases ***

Sort products A-Z by name
   [Tags]    not_ready     sprint_1
   [Documentation]  Verifies that products on the listing page are sorted in ascending 
   ...              alphabetical order when selecting "A-Z by name" sorting option.
   ...              User story: 244
   Given I am on the products page
   And I click the filter button 
   When I click the name sort button
   Then the products should be displayed in ascending alphabetical order

Sort products Z-A by name
   [Tags]   not_ready     sprint_1
   [Documentation]  Verifies that products on the listing page are sorted in descending 
   ...              alphabetical order when selecting "Z-A by name" sorting option.
   ...              User story: 244
   Given I am on the products page
   And I click the filter button 
   When I click the name sort button twice
   Then the products should be displayed in descending alphabetical order

Sort products from lowest to highest price
   [Tags]    not_ready     sprint_1
   [Documentation]  Verifies that products are sorted in ascending price order
   ...              when "low to high" is selected.
   ...              User story: 241
   Given I am on the products page
   And I click the filter button 
   When I click the price sort button twice
   Then the products should be displayed in ascending price order

Sort products from highest to lowest price
    [Tags]     not_ready      sprint_1
    [Documentation]  Verifies that products are sorted in descending price order
    ...              when "high to low" is selected.
    ...              User story: 241
   Given I am on the products page
   And I click the filter button 
   When I click the price sort button
   Then the products should be displayed in descending price order

Clear product filters
   [Tags]    not_ready     sprint_2
   [Documentation]  Verifies that the filter is cleared and the page is unfiltered
   Given I am on the products page
   And the unfiltered products are logged by name
   When I have used a filter
   And I clear the product filter
   Then the page should be unfiltered

Get detail information of the products
    [Tags]    not_ready    sprint_2
    [Documentation]  Verifies that an user can get detail information, price and stock balance of each game 
    ...              by clicking on "Läs mer" button
   Given I am on the products page
   When I click on the read more button
   Then I should see a detail information of the product
 

   



