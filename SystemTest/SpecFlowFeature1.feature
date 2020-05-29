Feature: SpecFlowFeature1
	Set the cooking time so I can heat my food

@mytag
Scenario: Set cooking time
	Given The oven is reset
	When I press the time button 1 time(s)
	Then the display should show 20 sec
