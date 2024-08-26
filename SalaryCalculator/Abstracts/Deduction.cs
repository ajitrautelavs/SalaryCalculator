using SalaryCalculator.Classes.Deductions;

namespace SalaryCalculator.Abstracts
{
    public abstract class Deduction
    {
        private decimal _amount;
        public decimal DeductionAmount => _amount;
        public abstract List<TaxBand> TaxBands { get; }
        public abstract string DeductionName { get; }
        //public abstract List<TaxBand> SetTaxBands();
        public decimal CalculateAmount(decimal taxableIncome)
        {
            _amount = (decimal)0;

            // Round down to nearest dollar
            taxableIncome = Math.Round(taxableIncome, 0, MidpointRounding.ToNegativeInfinity);

            foreach (var band in TaxBands)
            {
                if (taxableIncome > band.LowerLimit)
                {
                    decimal taxableForBand;
                    if (band.SumType == Enums.TaxSumTypeEnum.Cumulative)
                    {
                        // Cummulative, add into previous band amount
                        taxableForBand = Math.Min(band.UpperLimit - band.LowerLimit, taxableIncome - band.LowerLimit);
                        decimal taxForBand = taxableForBand * (band.TaxRate / 100);
                        _amount += taxForBand;
                    }
                    else
                    {
                        // Absolute, percentage of taxable income
                        _amount = taxableIncome * (band.TaxRate / 100);
                    }
                }
            }

            // Round upto nearest dollar
            _amount = Math.Round(_amount, 0, MidpointRounding.ToPositiveInfinity);
            return _amount;
        }
    }
}