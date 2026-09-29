*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_contact.py
Documentation    keywords used for contact us page testing

*** Keywords ***

I fill in all required fields with valid data
   [Tags]    sprint 2
   Sleep    2
   Scroll Element Into View    ${contact_form}
   Sleep    0.5
   Input Text    ${name_input}    ${contact_us_name}
   Sleep   0.5
   Input Text    ${email_input}    ${contact_us_email}
   Sleep     0.5
   Input Text     ${message_input}    ${contact_us_message}
   Sleep    0.5
click on the checkbox
   [Tags]    sprint 2
   Wait Until Keyword Succeeds    5s    1s  Click Element  ${checkbox}
   Sleep  2
click on the Send button
   [Tags]   sprint 2
   Sleep    2
   Scroll Element Into View      ${send_button}
   Wait Until Element Is Visible  ${send_button}  timeout=10s  
   Wait Until Element Is Enabled  ${send_button}  timeout=10s  
   Execute Javascript  document.querySelector('button.mud-button.mud-button-filled:not([disabled])').click()
   Sleep    2s


the contact form should be updated and left empty
   [Tags]    Sprint 2
   Wait Until Element Is Visible    ${name_input}
   Element Text Should Be    ${name_input}    ${EMPTY}
   Element Text Should Be    ${email_input}   ${EMPTY}
   Element Text Should Be    ${message_input}    ${EMPTY}
   Sleep    2s

I submit the form with empty required fields
   [Tags]   sprint 2
   Sleep     2
   Scroll Element Into View    ${contact_form}
   Wait Until Element Is Visible    ${contact_form}
   Wait Until Keyword Succeeds  5s    1s    Click Element    ${name_input}
   Wait Until Element Is Visible     ${name_input}
   Wait Until Keyword Succeeds  5s    1s   Click Element    ${email_input}
   Wait Until Element Is Visible     ${email_input}
   Select Checkbox    ${checkbox}
   Unselect Checkbox    ${checkbox}
   Sleep    2s


a error message should be shown for each missing field
   [Tags]    sprint 2
   Wait Until Page Contains    Namn är obligatoriskt!
   Wait Until Page Contains    Email är obligatoriskt
   Wait Until Page Contains    Du måste godkänna villkoren
   Sleep    2s


I see the map
   [Tags]    extra
   Scroll Element Into View    ${google_map_iframe}
   Sleep    0.5
   Wait Until Element Is Visible    ${google_map_iframe}    timeout=30s
   Sleep      0.5
   Select Frame    ${google_map_iframe}
   Sleep    1
   Page Should Contain Element    ${google_map}
   Unselect Frame
   Sleep    2s


I click on zoom out and the map should be zoomed out
   [Tags]    extra
   Scroll Element Into View    ${google_map_iframe}
   Wait Until Element Is Visible    ${google_map_iframe}    timeout=10s
   Select Frame    ${google_map_iframe}
   Sleep    2
   Click Element    ${zoom_out_button}
   Unselect Frame
   Sleep    2s


I click on zoom in and the map should be zoomed in
   [Tags]    extra
   Scroll Element Into View    ${google_map_iframe}
   Wait Until Element Is Visible    ${google_map_iframe}    timeout=10s
   Select Frame    ${google_map_iframe}
   Sleep    2
   Click Element    ${zoom_in_button}
   Sleep    2
   

