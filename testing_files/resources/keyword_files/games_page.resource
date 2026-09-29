*** Settings ***
Library          SeleniumLibrary
Library          Collections
Variables        ../page_object_models/variables_base.py
Variables        ../page_object_models/variables_games.py
Resource         ../keyword_files/filters.resource
Documentation    keywords used for games page testing

*** Keywords ***
I press Add to Cart
    [Tags]    sprint 1

the product is added to my cart
    [Tags]    sprint 1

I filter by ${restriction_category} age restriction
    [Tags]    sprint 2
    Sleep    1s
    Set Test Variable   ${name}     ${restriction_category}
    Select From List By Value    ${PEGI_sort_button}    ${${name}_age_restriction}
    Sleep    2s

the games should be filtered
    [Documentation]    Verifies that the games are filtered by comparing 
    ...                the list of current visible games to the original page. 
      Wait Until Page Contains Element    ${product_name_locator}
    @{names}    Get WebElements    ${product_name_locator}
    @{filtered_names}    Create List
    FOR    ${name_element}    IN    @{names}
        ${name_text}=    Get Text    ${name_element}
        Append To List    ${filtered_names}    ${name_text}
    END
    Should Not Be Equal    ${product_names}    ${filtered_names}
    Sleep    2s

I search for a game title
    Wait until page contains element    ${title_search_bar}
    Input Text    ${title_search_bar}    ${game_title}
    Click Button    ${title_magnifying_glass}
    Sleep    2s

the products with the searched title should be displayed
    the unfiltered products are logged by name
        FOR    ${item}    IN    @{product_names}
        Should Contain    ${item.lower()}    ${game_title.lower()}
        END
        Sleep    2s


I search by genre
    [Tags]    sprint 2
    Wait until page contains element    ${genre_search_bar}
    Input Text    ${genre_search_bar}    ${genre_search}
    Click Button    ${genre_magnifying_glass}
    Sleep    2s

I have used a filter
    [Tags]    sprint 2
    [Documentation]    encapsules price sorting into a keyword
        I click the filter button 
        I click the price sort button
        Sleep    2s

    
the page should be unfiltered
      [Tags]    not_ready    sprint_2
      [Documentation]  Verifies that the products are unfiltered when the filters are cleared.
          Wait Until Page Contains Element    ${product_name_locator}
        @{names}    Get WebElements    ${product_name_locator}
        @{unfiltered_names}    Create List
        FOR    ${name_element}    IN    @{names}
            ${name_text}=    Get Text    ${name_element}
            Append To List    ${unfiltered_names}    ${name_text}
        END
        Should Be Equal    ${product_names}    ${unfiltered_names}
        Sleep    2s
