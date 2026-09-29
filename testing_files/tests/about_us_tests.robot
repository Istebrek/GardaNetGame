*** Settings ***
Name             About Us Page Tests
Documentation    Gårda grupp 4
...              Tests related to about us page
Library          SeleniumLibrary
Resource         ../resources/keyword_files/base_keywords.resource
Test Setup        Open the Website
Test Teardown     Close Browser

*** Test Cases ***
