Feature: FindMyVehicleAPI
	
@api
Scenario Outline: FindMyVehicleAPI Tests
	Given I have FindMyVehicleAPI end point
	And I have a registration number for API - '<RegistrationNumber>'
	When I call the FindMyVehicleAPI
	Then I should see http status code - '<StatusCode>'
	And I should see http response code - '<HttpResponseCode>'
	Examples: 
	| RegistrationNumber | StatusCode | HttpResponseCode |
	| @V12               | 200        | 404              |
	| OV12UYY            | 200        | 200              |
	| OV12               | 200        | 404              |
	| OV12UYYUUU         | 200        | 404              |
	| ov12uyy            | 200        | 200              |
	| Ov12uyy	         | 200        | 200              | 					  					 