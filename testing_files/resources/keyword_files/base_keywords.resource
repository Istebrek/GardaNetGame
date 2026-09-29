*** Settings ***
Library          SeleniumLibrary
Library          String
Library          DateTime
Library          BuiltIn
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_login.py
Variables        ../page_object_models/variables_register.py
Documentation    keywords used for base testing

*** Variables ***

# defines variables to be able to generate a unique email address per test case
${EMAIL_PREFIX}      testuser
${EMAIL_DOMAIN}      @testing.com
${PASSWORD}          Testpass123!

*** Keywords ***

Open the Website
    Set Selenium Speed    0.5s
    Open Browser    ${develop_url}    ${BROWSER}

I am on the ${page_name} page
    [Tags]    sprint 1   
    Set Test Variable    ${page}    ${page_name}
    Go To    ${develop_url}/${${page}_link}

Generate Unique Email
    [Documentation]    Generates a unique email address for testing purposes.
    ${timestamp}=     Get Time    epoch
    ${EMAIL}=         Catenate    SEPARATOR=    ${EMAIL_PREFIX}+${timestamp}    ${EMAIL_DOMAIN}
    Set Test Variable    ${unique_email}    ${EMAIL}

I enter a unique username and password
    [Tags]    sprint 1
    Generate Unique Email
    Input Text    ${register_email_input}    ${unique_email}
    Input Text    ${register_password_input}    ${customer_password}
    Input Text    ${register_password_confirmation_input}    ${customer_password}
    Sleep    2s

I enter my customer username and password
    [Tags]    sprint 1
    Input Text    ${login_username_input}    ${customer_username}
    Input Text    ${login_password_input}    ${customer_password}
    Sleep    2s
    
I click the register button
    Wait Until Keyword Succeeds    15s    5s  Click Button    ${register_button}
    Sleep    2s

click the login button
    Wait Until Keyword Succeeds    15s    5s  Click Button    ${login_button}
    Sleep    2s

I confirm my email
    Click Link    ${confirmation_link}

I enter a username that is already registered
    [Tags]    sprint 1
    Input Text    ${register_email_input}    ${customer_username}
    Input Text    ${register_password_input}    ${customer_password}
    Input Text    ${register_password_confirmation_input}    ${customer_password}
    Sleep    2s


I am successfully registered and my email is confirmed
    [Tags]    sprint 1
    Wait Until Element Is Visible    ${success_alert}
    Page Should Contain Element    ${success_alert}
    Sleep    2s


I cannot create an account
    [Tags]    sprint 1
    Wait Until Element Is Visible    ${fail_alert}
    Sleep    2s


I am successfully logged in
    [Tags]    sprint 1
    Wait Until Element Is Visible   ${customer_navbar_locator}
    Mouse Over    ${customer_navbar_locator}
    Wait Until Element Is Visible    ${logout_button}
    Sleep    2s


I enter my admin username and password
    [Tags]    sprint 1
    Input Text    ${login_username_input}    ${admin_username}
    Input Text    ${login_password_input}    ${admin_password}
    Sleep    2s