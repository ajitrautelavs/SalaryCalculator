using SalaryCalculator.Abstracts;
using SalaryCalculator.Classes.Calculations;
using SalaryCalculator.Enums;
using SalaryCalculator.Interfaces;

namespace SalaryCalculator.Classes
{
    public class SalaryDetailsCalculator : ICalculator
    {
        private readonly decimal _grossSalary;
        private readonly PayFrequencyEnum _payFrequency;
        private decimal _superannuationPercentage;
        private SalaryDetails _salaryDetails;

        public SalaryDetailsCalculator(decimal grossSalary, PayFrequencyEnum payFrequency)
        {
            _grossSalary = grossSalary;
            _payFrequency = payFrequency;
            _salaryDetails = new SalaryDetails();
            _salaryDetails.Deductions = new List<Deduction>();
        }

        public SalaryDetails Calculate()
        {
            //Taxable income
            var taxableCalc = new TaxableIncome(_superannuationPercentage);
            _salaryDetails.TaxableIncome = taxableCalc.Calculate(_grossSalary);
            
            // Set superannuation rate
            var superCalc = new Superannuation(_superannuationPercentage);
            _salaryDetails.Superannuation = superCalc.Calculate(_salaryDetails.TaxableIncome);

            //Total deductions
            decimal totalDeductions = (decimal)0.00;
            foreach (var deduct in _salaryDetails.Deductions)
            {
                totalDeductions += deduct.CalculateAmount(_salaryDetails.TaxableIncome);
            }

            //Net income
            var netIncomeCalc = new NetIncome(totalDeductions);
            _salaryDetails.NetIncome = netIncomeCalc.Calculate(_salaryDetails.TaxableIncome);

            //Pay packet
            var payPacketCalc = new PayPacket(_payFrequency);
            _salaryDetails.PayPacket = payPacketCalc.Calculate(_salaryDetails.NetIncome);
            _salaryDetails.PayPacketFrequencyString = payPacketCalc.FrequencySuffix;

            return _salaryDetails;
        }

        public void SetSuperannuationPercentage(decimal percentage)
        {
            _superannuationPercentage = percentage;
        }

        public void SetDeductions(Deduction[] deductions)
        {
            foreach (var deduct in deductions)
            {
                _salaryDetails.Deductions.Add(deduct);
            }
        }
    }
}
