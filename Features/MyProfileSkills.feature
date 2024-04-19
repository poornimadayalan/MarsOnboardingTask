Feature: This test suite runs skill test scenarios

Scenario: 1. Verify user is able to add known skills with experience level
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds 'Guitar' skill with 'Beginner' experience level into the known skills list
	Then The 'Guitar' skill with 'Beginner' experience level should appear in the known skills list

Scenario: 2. Verify user is able to edit an existing known skill with experience level
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user edits the 'Guitar' skill with 'Intermediate' experience level from the known skills list
	Then The experience level for 'Guitar' skill should be updated to 'Intermediate'

Scenario: 3. Verify user is able to edit a experience level from the known language
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user edits the 'Existing' skill with 'Expert' experience level from the known skills list
	Then The experience level for 'Existing' skill should be updated to 'Expert'

Scenario: 4. Verify user is able to delete an existing known skill
	Given User logs into Mars application
	When User clicks on the skill feature
	And The User deletes the skill 'Guitar'
	Then The skill 'Guitar' should not be visible on the profile page

	
Scenario: 5. Verify user attempting to add a skill already present in the known skills list
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds 'Problem Solving' skill with 'Expert' experience level into the known skills list
	And The user adds skill 'Problem Solving' with 'Expert' experience level that is already displayed in their known skills list
	Then The skill 'Problem Solving' should not be duplicated in the known skills list

Scenario: 6. Verify user tries to add a skill with the same name but different cases
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds 'Piano' skill with 'Beginner' experience level into the known skills list
	And The user adds 'PIaNO' skill with 'Beginner' experience level with the same name but different cases
	Then The system should accept the same skill 'PIaNO' with 'Beginner' experience level with different case

Scenario: 7. Verify that the system rejects saving an empty skill field with the chosen experience level in the skill profile section
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '' skill with 'Beginner' experience level into the known skills list
	Then The system should reject showcasing an empty 'skill' field and display an error message