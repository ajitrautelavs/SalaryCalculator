using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes.Calculations
{
    public class TaxableIncome : ICalculation
    {
        private readonly decimal _superannuationRate;

        public TaxableIncome(decimal superannuationRate)
        {
            _superannuationRate = superannuationRate;
        }

        public decimal Calculate(decimal grossSalary)
        {
            return Math.Round(grossSalary / ((decimal) 1 + (_superannuationRate / 100)), 2);
        }
    }
}
