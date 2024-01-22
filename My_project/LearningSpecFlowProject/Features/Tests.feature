Feature: Tests
	In order to easily find needed documentation
	As a specflow user
	I want to be able to Search in Search Doc field

@Smoke
Scenario Outline: Searching in Search Doc field on SpecFlow page opens corresponding page
	Given I open official SpecFlow web site
	When I close Data Privacy pop up
		And I hover the '<menuItem>' menu item from the main menu
		And I click '<subMenuItem>' option from the main menu
	Then Page with '<title>' title should be opened
	When I click Search Docs input field on SpecFlow page
		And I click Search input field on SearchPopup
		And I enter '<searchData>' into Search input field on SearchPopup
		And I click first search result on Search popup
	Then Page with '<searchData>' title should be opened

	Examples: 
	| menuItem | subMenuItem | title               | searchData   |
	| Docs     | SpecFlow    | SpecFlow            | Installation |