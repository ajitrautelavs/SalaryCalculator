using SalaryCalculator.Abstracts;

namespace SalaryCalculator.Classes.Deductions
{
    public class IncomeTax : Deduction
    {
        private List<TaxBand> _taxBands;

        public IncomeTax(List<TaxBand> taxBands)
        {
            _taxBands = taxBands;
        }
        public override string DeductionName => "Income Tax";
        public override List<TaxBand> TaxBands => _taxBands;
    }
}
