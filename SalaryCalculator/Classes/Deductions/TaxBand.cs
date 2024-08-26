using SalaryCalculator.Enums;

namespace SalaryCalculator.Classes.Deductions
{
    public class TaxBand
    {
        private decimal _lowerLimit;
        private decimal _upperLimit;
        private decimal _taxRate;
        private TaxSumTypeEnum _sumType;

        public TaxBand(decimal lowerLimit, decimal upperLimit, decimal taxRate, TaxSumTypeEnum sumType)
        {
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
            _taxRate = taxRate;
            _sumType = sumType;
        }

        public decimal LowerLimit
        {
            get
            {
                return _lowerLimit;
            }
            set
            {
                _lowerLimit = value;
            }
        }
        public decimal UpperLimit
        {
            get
            {
                return _upperLimit;
            }
            set
            {
                _upperLimit = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                _taxRate = value;
            }
        }

        public TaxSumTypeEnum SumType
        {
            get
            {
                return _sumType;
            }
            set
            {
                _sumType = value;
            }
        }
    }
}
