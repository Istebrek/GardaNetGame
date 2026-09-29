*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Documentation    keywords used for home page testing

*** Keywords ***

I am on the homepage 
   [Tags]    sprint 2

I look through the page
   [Tags]    sprint 2

the company slogan is visible 
   [Tags]     sprint 2

I have navigated to the CTA banner
   [Tags]     extra

I look at the banner
   [Tags]   extra

I can see any active sale campaigns
   [Tags]     extra

I see a section focusing on new releases and top rated products
   [Tags]     extra

there are upcoming events
   [Tags]    extra

I can see upcoming events
   [Tags]    extra

