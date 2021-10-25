# SpecFlow.CodingTask

Dependencies;

- SpecRun.SpecFlow 3.9.7
- FluentAssertions 5.10.3
- Microsoft.NET.Test.Sdk 16.5.0
- SpecRun.Runner 3.9.7
- SpecFlow.Tools.MsBuild.Generation 3.9.22

> Warning;  **In order to run specflow tests, you must register their web site to open an account to be connected your visual studio account. And u must have a internet connection. You also need to install specflow extention for visual studio 2019.**

## Problem
Create a customer basket that allows a customer to add products and provides a total cost of the basket including applicable discounts. Offers can be cumulative.

### Available products:

#### Product Cost
- Butter £0.80
- Milk £1.15
- Bread £1.00

Offers:
- Buy 2 Butter and get a Bread at 50% off
- Buy 3 Milk and get the 4th milk for free


## Scenarios:

- Given the basket has 1 bread, 1 butter and 1 milk When I total the basket Then the total should be £2.95
- Given the basket has 2 butter and 2 bread When I total the basket Then the total should be £3.10
- Given the basket has 4 milk When I total the basket Then the total should be £3.45
- Given the basket has 2 butter, 1 bread and 8 milk When I total the basket Then the total should be £9.00

## Test results:

```
  Group Name: Calculator
  Duration: 0:00:00.135
  0 test(s) failed
  0 test(s) skipped
  4 test(s) passed
  ```

![Test Results](/SpecFlow.CodingTask/ResultImg/coding_task_test_resullt.PNG)
