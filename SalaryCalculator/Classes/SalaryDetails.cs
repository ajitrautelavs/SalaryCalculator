using SalaryCalculator.Abstracts;

namespace SalaryCalculator.Classes
{
    public class SalaryDetails
    {
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome { get; set; }
        public List<Deduction> Deductions { get; set; }
        public decimal NetIncome { get; set; }
        public decimal PayPacket { get; set; }
        public string PayPacketFrequencyString { get; set; }
    }
}
