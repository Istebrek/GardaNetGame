*** Settings ***
Library          SeleniumLibrary
Variables        ${EXECDIR}/testing_files/resources/
Documentation    keywords used for customer profile management testing

*** Keywords ***
I have made previous purchases    
    [Tags]    sprint 2

I navigate to my profile page
    [Tags]    sprint 2

Customer receives personalized recommendations
    [Tags]    sprint 2

I click on Order History
    [Tags]    sprint 2

I see a summary of my previously placed orders
    [Tags]    sprint 2

I want to see customized product suggestions
    [Tags]    sprint 2

I am on my account management page
    [Tags]    sprint 2

I change my details
    [Tags]    sprint 2

my details are updated
    [Tags]    sprint 2

I change my password
    [Tags]    extra

my login password is successfully changed
    [Tags]    extra
