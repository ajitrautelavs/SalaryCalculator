using SalaryCalculator.Enums;
using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes.Calculations
{
    public class PayPacket : ICalculation
    {
        private readonly PayFrequencyEnum _payFrequency;
        private string _payFrequencySuffix;

        public PayPacket(PayFrequencyEnum payFrequency)
        {
            _payFrequency = payFrequency;
        }

        public string FrequencySuffix
        {
            get
            {
                return _payFrequencySuffix;
            }
        }

        public decimal Calculate(decimal netSalary)
        {
            decimal amount = (decimal)0;
            switch (_payFrequency)
            {
                case PayFrequencyEnum.W:
                    amount = netSalary / (decimal)52;
                    _payFrequencySuffix = "per week";
                    break;
                case PayFrequencyEnum.F:
                    amount = netSalary / (decimal)26;
                    _payFrequencySuffix = "per fornight";
                    break;
                case PayFrequencyEnum.M:
                    amount = netSalary / (decimal)12;
                    _payFrequencySuffix = "per month";
                    break;
                default:
                    _payFrequencySuffix = string.Empty;
                    break;
            }

            return Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
