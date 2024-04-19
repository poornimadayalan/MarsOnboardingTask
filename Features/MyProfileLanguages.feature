Feature: This test suite runs my profile language related test scenarios

Scenario: 1. Verify user is able to add known languages with proficiency level
	Given User logs into Mars application
	When User adds 'English' language with 'Fluent' proficiency level into the known languages list
	Then The 'English' language with 'Fluent' proficiency level should appear in the known languages list

Scenario: 2. Verify user is able to edit an existing known language with proficiency level
	Given User logs into Mars application
	When User edits the 'English' language with 'Basic' proficiency level from the known languages list
	Then The proficiency level for 'English' language should be updated to 'Basic'

Scenario: 3. Verify user is able to edit a proficiency level from the known language
	Given User logs into Mars application
	When User edits the 'Existing' language with 'Fluent' proficiency level from the known languages list
	Then The proficiency level for 'Existing' language should be updated to 'Fluent'

Scenario: 4. Verify user is able to delete an existing known language
	Given User logs into Mars application
	When The User deletes the language 'English'
	Then The language 'English' should not be visible on the profile page

Scenario: 5. Verify user attempting to add a language already present in the known languages list
	Given User logs into Mars application
	When User adds 'German' language with 'Basic' proficiency level into the known languages list
	And The user adds language 'German' with 'Basic' proficiency level that is already displayed in their known languages list
	Then The language 'German' should not be duplicated in the known languages list

Scenario: 6. Verify that the system rejects saving an empty language field with the chosen proficiency level in the language profile section
	Given User logs into Mars application
	When User adds '' language with 'Fluent' proficiency level into the known languages list
	Then The system should reject showcasing an empty 'language' and display an error message

Scenario: 7. Verify user tries to add a language with the same name but different cases
	Given User logs into Mars application
	When User adds 'Mandrin' language with 'Basic' proficiency level into the known languages list
	And The user adds 'manDRIN' language with 'Basic' proficiency level with the same name but different cases
	Then The system should accept the same language 'manDRIN' with 'Basic' proficiency level with different case