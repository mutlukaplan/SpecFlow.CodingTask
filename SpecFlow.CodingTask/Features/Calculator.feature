Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers
Link to a feature: [Calculator](SpecFlow.CodingTask/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**


@mytag2
Scenario: Scenario1
	Given Given the basket has 1 bread, 1 butter and 1 milk
	When When I total the basket
	Then the total should be £2.95

@mytag2
Scenario: Scenario2
	Given Given the basket has 2 butter and 2 bread
	When When I total the basket
	Then the total should be £3.10

@mytag3
Scenario: Scenario3
	Given Given the basket has 4 milk
	When When I total the basket
	Then the total should be £3.45

@mytag4
Scenario: Scenario4
	Given  the basket has 2 butter, 1 bread and 8 milk
	When When I total the basket
	Then the total should be £9.00