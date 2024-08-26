using SalaryCalculator.Abstracts;
using SalaryCalculator.Classes;
using SalaryCalculator.Classes.Deductions;
using SalaryCalculator.Enums;
using System;

namespace Tests
{
    [TestClass]
    public class SalaryDetailsTest
    {
        [TestMethod]
        public void Calculate_SalaryDetails_Gross65000_Super9_5()
        {
            // Arrange
            var calculator = new SalaryDetailsCalculator(65000, PayFrequencyEnum.M);
            calculator.SetSuperannuationPercentage((decimal)9.5);
            Deduction[] deductions = [
                new MedicareLevy(new List<TaxBand>
                {
                    new TaxBand((decimal)0, (decimal)21335, (decimal)0, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)21336, (decimal)26668, (decimal)10, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)26669, Decimal.MaxValue, (decimal)2, TaxSumTypeEnum.Absolute)
                }),
                new BudgetRepairLevy(new List<TaxBand>
                {
                    new TaxBand((decimal)0, (decimal)180000, (decimal)0, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)180001, Decimal.MaxValue, (decimal)2 , TaxSumTypeEnum.Cumulative)
                }),
                new IncomeTax( new List<TaxBand>
                {
                    new TaxBand((decimal)0, (decimal)18200, (decimal)0, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)18201, (decimal)37000, (decimal)19, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)37001, (decimal)87000, (decimal)32.5, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)87001, (decimal)180000, (decimal)37, TaxSumTypeEnum.Cumulative),
                    new TaxBand((decimal)180001, Decimal.MaxValue, (decimal)47, TaxSumTypeEnum.Cumulative)
                })];
            calculator.SetDeductions(deductions);

            // Act
            var details = calculator.Calculate();

            // Assert
            Assert.AreEqual((decimal)5639.27, details.Superannuation, 0);
            Assert.AreEqual((decimal)59360.73, details.TaxableIncome, 0);
            foreach (var deduct in details.Deductions)
            {
                if (deduct.DeductionName == "Medicare Levy")
                    Assert.AreEqual((decimal)1188.00, deduct.DeductionAmount, 0);
                if (deduct.DeductionName == "Budget Repair Levy")
                    Assert.AreEqual((decimal)0, deduct.DeductionAmount, 0);
                if (deduct.DeductionName == "Income Tax")
                    Assert.AreEqual((decimal)10839.00, deduct.DeductionAmount, 0);
            }
            Assert.AreEqual((decimal)47333.73, details.NetIncome, 0);
            Assert.AreEqual((decimal)3944.48, details.PayPacket, 0);
            Assert.AreEqual("per month", details.PayPacketFrequencyString,  true);
        }
    }
}