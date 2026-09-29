*** Settings ***
Library          SeleniumLibrary
Library          Collections
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_products.py
Variables        ../page_object_models/variables_games.py
Resource         ../keyword_files/base_keywords.resource
Documentation    keywords used for product page testing

*** Keywords ***

I click the filter button 
   [Tags]    sprint 1
    Sleep    1s
    Execute JavaScript    document.evaluate("(//button[.//span[contains(text(), 'Filter')]])[1]", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()
    Sleep    1s

I click the ${button_name} sort button
    Set Test Variable    ${name}    ${button_name}
    Wait Until Keyword Succeeds    5s    1s    Click Element    ${${name}_sort_button}
    Sleep    2s

I click the ${button_name} sort button twice
    [Tags]    sprint 1
    Set Test Variable    ${name}    ${button_name}
    I click the ${name} sort button
    I click the ${name} sort button
    Sleep    2s

the products should be displayed in ascending alphabetical order
   [Tags]     sprint 1 
   [Documentation]  Verifies that products on the listing page are sorted in alphabetical order 
   ...    by creating a for loop  to iterate through the product names and sorth them.
    the unfiltered products are logged by name
   # sorts the list by alphabetical order (if not already sorted) to compare it with the original list.
    Normalize product names    ${product_names}
    ${sorted_names}=    Copy List    ${normalized_names}
    Sort List    ${sorted_names}
    Should Be Equal    ${normalized_names}    ${sorted_names}
    Sleep    2s


the products should be displayed in descending alphabetical order
   [Tags]   sprint 1
    the unfiltered products are logged by name
   # sorts the list by alphabetical order and reverses it to compare it with the original list.
    Normalize product names    ${product_names}
    ${sorted_names}=    Copy List    ${normalized_names}
    Sort List    ${sorted_names}
    Reverse List    ${sorted_names}
    Should Be Equal    ${normalized_names}    ${sorted_names}
    Sleep    2s


the products should be displayed in ascending price order
   [Tags]   sprint 1
    the products are logged by price
   # sorts the list by price to compare it with the original list.
    ${sorted_prices}=    Copy List    ${price_texts}
    Sort List    ${sorted_prices}
    Should Be Equal    ${price_texts}    ${sorted_prices}
    Sleep    2s


the products should be displayed in descending price order
    [Tags]    sprint 1
    the products are logged by price
    # sorts the list by price and reverses it to compare it with the original list.
    ${sorted_prices}=    Copy List    ${price_texts}
    Sort List    ${sorted_prices}
    Reverse List    ${sorted_prices}
    Should Be Equal    ${price_texts}    ${sorted_prices}
    Sleep    2s


I clear the product filter
    [Tags]   sprint 2
    [Documentation]    Verifies that the filter is cleared by checking if the 
    ...                original page is displayed.
    Wait Until Element Is Visible    ${clear_product_filter_button}
    Wait Until Keyword Succeeds    5s    1s     Click Button    ${clear_product_filter_button}
    Sleep    2s

I clear the game filter
    [Tags]   sprint 2
    [Documentation]    Verifies that the filter is cleared by checking if the 
    ...                original page is displayed.
    Wait Until Element Is Visible    ${clear_game_filter_button}
    Wait Until Keyword Succeeds    5s    1s     Click Button    ${clear_game_filter_button}
    Sleep    2s

# Creates a list of products by price or name to be used in other keywords 
the products are logged by price 
    [Tags]    sprint 2
      Wait Until Page Contains Element    ${price_locator}
  # creating the list of the prices visable on the page
   ${price_elements}   Get WebElements    ${price_locator}
    @{price_texts}       Create List
   FOR    ${element}    IN    @{price_elements}
          ${text}=    Get Text    ${element}
          ${price}=    Extract Price From Text    ${text}
         Append To List    ${price_texts}    ${price}
   END
    Set Suite Variable    ${price_texts}
    Sleep    2s


the unfiltered products are logged by name
    [Documentation]    Creates a list of all products on a page.
    [Tags]    sprint 1
    Wait Until Page Contains Element    ${product_name_locator}    10s
    @{names}=    Get WebElements    ${product_name_locator}
    @{product_names}=    Create List
    FOR    ${name_element}    IN    @{names}
        ${status}    ${name_text}=    Run Keyword And Ignore Error    Get Text    ${name_element}
        Run Keyword If    '${status}' == 'FAIL'    Log    Stale element encountered, skipping.
        Run Keyword If    '${status}' == 'PASS'    Append To List    ${product_names}    ${name_text}
    END
    Set Suite Variable    ${product_names}
    Sleep    2s


# Formatting keywords
Normalize product names 
    [Documentation]    AI solution: Normalizes product names by removing extra spaces and special characters.
    [Arguments]    ${product_names}
    ${normalized_names}=    Create List
    FOR    ${name}    IN    @{product_names}
        ${cleaned}=    Evaluate    ' '.join("""${name}""".strip().split()) if """${name}""" else ''
        ${cleaned}=    Evaluate    re.sub(r'[^a-zA-Z0-9\\s\\-\\']', '', """${cleaned}""") if """${cleaned}""" else ''    modules=re
        ${cleaned}=    Evaluate    """${cleaned}""".lower()
        Append To List    ${normalized_names}    ${cleaned}
        Set Suite Variable    ${normalized_names}
    END
    Sleep    2s


Extract Price From Text
    [Arguments]    ${text}
    ${number}=    Evaluate    re.sub(r'[^0-9.]', '', '''${text}''')    re
    ${price}=     Convert To Number    ${number}
    RETURN      ${price}
    Sleep    2s


# not for this sprint 
I have sorted products by name A-Z
   [Tags]    extra
   
I have sorted products by name Z-A
   [Tags]     extra

I have sorted products by price high to low
   [Tags]    extra

I have sorted products by price low to high
   [Tags]   extra
