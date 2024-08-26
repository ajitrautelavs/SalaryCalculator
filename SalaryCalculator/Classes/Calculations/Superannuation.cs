using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes.Calculations
{
    public class Superannuation : ICalculation
    {
        private readonly decimal _superannuationRate;

        public Superannuation(decimal superannuationRate)
        {
            _superannuationRate = superannuationRate;
        }

        public decimal Calculate(decimal taxableSalary)
        {
            if (_superannuationRate == 0)
                return 0;

            return Math.Round(taxableSalary * (_superannuationRate / 100), 2);
        }
    }
}
