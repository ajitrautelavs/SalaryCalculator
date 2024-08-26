using SalaryCalculator.Abstracts;

namespace SalaryCalculator.Classes.Deductions
{
    public class BudgetRepairLevy : Deduction
    {
        private List<TaxBand> _taxBands;
        public BudgetRepairLevy(List<TaxBand> taxBands)
        {
            _taxBands = taxBands;
        }
        public override string DeductionName => "Budget Repair Levy";
        public override List<TaxBand> TaxBands => _taxBands;
    }
}
