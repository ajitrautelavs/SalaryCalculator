using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes.Calculations
{
    public class NetIncome : ICalculation
    {
        private readonly decimal _totalDeductions;

        public NetIncome(decimal totalDeductions)
        {
            _totalDeductions = totalDeductions;
        }

        public decimal Calculate(decimal taxableIncome)
        {
            return Math.Round(taxableIncome - _totalDeductions, 2);
        }
    }
}
