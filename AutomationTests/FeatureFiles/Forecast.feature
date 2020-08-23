Feature: Forecast

Scenario: Verify Get Forecasts returned
	Given I run the forecast api
	Then response should be returning code 200
	And forecasts returned is equal to <value>
	And the date should be a future date
	And celsius temparature and fahrenheit temparature should match
	And should get a correct summary
Examples: 
	| value |
	| 5     |