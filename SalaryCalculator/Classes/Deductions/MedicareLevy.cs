using SalaryCalculator.Abstracts;

namespace SalaryCalculator.Classes.Deductions
{
    public class MedicareLevy : Deduction
    {
        private List<TaxBand> _taxBands;

        public MedicareLevy(List<TaxBand> taxBands)
        {
            _taxBands = taxBands;
        }
        public override string DeductionName => "Medicare Levy";
        public override List<TaxBand> TaxBands => _taxBands;
    }
}
