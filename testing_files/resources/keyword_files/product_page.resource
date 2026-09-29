*** Settings ***
Library          SeleniumLibrary
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_products.py
Resource         ../keyword_files/base_keywords.resource
Documentation    keywords used for product page testing

*** Keywords ***

I click on the read more button  
   [Tags]     sprint 2
   Sleep     2s
   Scroll Element Into View    ${read_more_button}
   Wait Until Element Is Visible    ${read_more_button}    timeout=30s
   Click Element     ${read_more_button}
   Sleep    2s


I should see a detail information of the product
   [Tags]     sprint 2
   Sleep      1
   Page Should Contain         Logitech G Pro X Gaming Headset 7.1
   Wait Until Page Contains    Designat i samarbete med och för proffs för avancerade kommandon och exakt ljud.
   Page Should Contain         Lager: 7 
   Sleep    2s

