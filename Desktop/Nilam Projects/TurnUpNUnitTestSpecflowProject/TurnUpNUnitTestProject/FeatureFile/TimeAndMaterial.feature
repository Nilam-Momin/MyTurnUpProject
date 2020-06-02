Feature: TimeAndMaterial
	As a TurnUp admin
	I want to manage Time and Material portal

@Features
Scenario: Create new Time and Material item
	Given I have logged in to TurnUp portal
	And I have navigated to time and material page
	When I create new Time and material item using<code> and <Description>
	Then I can see the newly created item using<code> and <Description>
	Examples:
	| code  |  Description |
	| 1     |     desc 1    |
	| 2     |     desc 2    |


@Features
Scenario: Edit Time and Material item
	Given I have logged in to TurnUp portal
	And I have navigated to time and material page
	When I edit an existing Time and material item using<code> and <Description>
	Then I can see the edited item using<code> and <Description>
	Examples: 
	| code | Description   |
	| 1    | edited Desc 1 |
	| 2    | edited Desc 2 |

@Features
Scenario: Delete Time and Material item
	Given I have logged in to TurnUp portal
    When I have navigated to time and material page
	Then I can delete an existing Time and material item
