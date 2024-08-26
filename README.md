# SalaryCalculator
#### Input
User is asked to enter gross package, the gross package is inclusive of superannuation 
User is asked to enter a pay frequency (weekly, fortnightly or monthly) 
#### Output
##### Salary breakdown shows: 
* Gross package (annual) 
* Superannuation contribution (annual) 
* Taxable income (annual) 
* List of deductions and their annual amount, deductions included: 
    - Medicare Levy 
    - Budget Repair Levy 
    - Income tax 
* Net income (annual) 
* Pay packet amount
##### Developer comments
* The app has been developed following clean code practices, OOD and OOP in .NET.
* Use of Abstract classes and Interfaces has been showcased to use Encapsulation, Inheritance, Abstraction concepts.
* The solution is architectured in a way that code is highly readable and maintainable.
* Many SOLID principles have been applied.
* Variables (superannuation rate and deductions' tax bands) that can change have been implemented outside of classes, so that they can be adjusted as needed.
* The app can be extended to introduce any new tax/ levy types in income without the need to change any existing classes.
* A unit test project has been created to test the given results
  
<code>
  
Enter your salary package amount: 65000 
Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): M

Calculating salary details... 

Gross package: $65,000.00
Superannuation: $5,639.27 

Taxable income: $59,360.73 

Deductions: 
Medicare Levy: $1,188.00 
Budget Repair Levy: $0.00
Income Tax: $10,839.00 

Net income: $47,333.73 
Pay packet: $3,944.48 per month 

Press any key to end...

</code>
