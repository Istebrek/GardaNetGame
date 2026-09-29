*** Settings ***
Name             Contact Us Page 
Documentation    Gårda grupp 4
...              Tests related to the contact us page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Resource         ../resources/keyword_files/contact_us.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***

Fill and submit contact form with valid input
   [Tags]    ready    sprint_2
   [Documentation]     Verifies that a user can fill and submit when entering valid input 
   ...                 User story:172
   Given I am on the contact page
   When I fill in all required fields with valid data
   And click on the checkbox 
   And click on the Send button
   Then the contact form should be updated and left empty

Show error for missing required fields
   [Tags]    ready_not_for_pipline    sprint_2
   [Documentation]    Verifies that a error message shows when a user submit the form with empty fields  
   ...                User story:172
   Given I am on the contact page
   When I submit the form with empty required fields
   Then a error message should be shown for each missing field

Zoom out with the Google map
   [Tags]    ready    sprint_2
   [Documentation]     Verifies that the user can click on the zoom out button   
   ...                 User story:173
   Given I am on the contact page
   When I see the map
   Then I click on zoom out and the map should be zoomed out

Zoom in with the Google map
   [Tags]    not_ready_for_pipeline    sprint_2
   [Documentation]     Verifies that the user can click on the zoom in button    
   ...                 User story:173
   Given I am on the contact page
   When I see the map
   Then I click on zoom in and the map should be zoomed in
