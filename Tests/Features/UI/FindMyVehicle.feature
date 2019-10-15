Feature: Validate FindMyVehicle functionality


@browser
Scenario Outline: FindMyVehicle
	Given I am on VFS - FindMyVehicle page
	And I have a registration number - '<RegistrationNumber>'
	When I enter registration number in text field
	And I click on 'FindMyVehicle' button
	Then I should see the result as '<Result>'
	Examples: 
	| RegistrationNumber  | Result                                |
	| Ov12uyy		      | Result for : OV12UYY                  | # Postive
	| ov12uyy			  | Result for : OV12UYY                  |	# Postive
	| OV12UYY             | Result for : OV12UYY                  |	# Postive
	| OV12UYZ             | Sorry record not found                |	# Postive
	| OV12UYYPWENKD       | Sorry record not found                |	# Negative
	| OV12                | Sorry record not found                |	# Negative
	| @V12                | Please enter a valid car registration |	# Negative
	|					  | Please enter a valid car registration |	# Negative