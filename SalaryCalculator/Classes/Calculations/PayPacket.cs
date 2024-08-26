using SalaryCalculator.Enums;
using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes.Calculations
{
    public class PayPacket : ICalculation
    {
        private readonly PayFrequencyEnum _payFrequency;

        public PayPacket(PayFrequencyEnum payFrequency)
        {
            _payFrequency = payFrequency;
        }

        public string FrequencySuffix
        {
            get
            {
                switch (_payFrequency)
                {
                    case PayFrequencyEnum.W:
                        return "per week";
                    case PayFrequencyEnum.F:
                        return "per fortnight";
                    case PayFrequencyEnum.M:
                        return "per month";
                    default:
                        break;
                }

                return string.Empty;
            }
        }

        public decimal Calculate(decimal netSalary)
        {
            decimal amount = (decimal)0;
            switch (_payFrequency)
            {
                case PayFrequencyEnum.W:
                    amount = netSalary / (decimal)52;
                    break;
                case PayFrequencyEnum.F:
                    amount = netSalary / (decimal)26;
                    break;
                case PayFrequencyEnum.M:
                    amount = netSalary / (decimal)12;
                    break;
                default:
                    break;
            }

            return Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
