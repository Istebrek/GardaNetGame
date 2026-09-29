*** Settings ***
Name             Home Page 
Documentation    Gårda grupp 4
...              Tests related to home page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Display company slogan
  [Tags]    not_ready    sprint_2
  [Documentation]   Verifies that a user can see the company slogan on homepage  
  ...               User story: 77
  Given I am on the homepage 
  When I look through the page
  Then the company slogan is visible 

Display CTA banner for current sale
  [Tags]   not_ready      extra
  [Documentation]    Verifies that a user can see current sales on the homepage 
  ...                User story:86
  Given I have navigated to the CTA banner
  When I look at the banner
  Then I can see any active sale campaigns 

Display Top Rated and New Releases 
   [Tags]   not_ready      extra
   [Documentation]   Verifies that a user can see Top Rated & New Releases on homepage 
   ...               User story:81
   Given I am on the home page
   When I look through the page
   Then I see a section focusing on new releases and top rated products

Display upcoming events
   [Tags]  not_ready     extra
   [Documentation]   Verifies that a user can see upcoming events on the homepage 
   ...               User story: 79
   Given there are upcoming events
   When I am on the home page
   Then I can see upcoming events


