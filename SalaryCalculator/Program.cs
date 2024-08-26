using SalaryCalculator.Abstracts;
using SalaryCalculator.Classes;
using SalaryCalculator.Classes.Deductions;
using SalaryCalculator.Enums;

namespace SalaryCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Can be easily adjusted if superannuation rate changes without changing the implementation
            const decimal superannuationPercentage = (decimal)9.5;
            // Any new future/ past deduction types can be added here without changing the main class code
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

            // Process input
            int retries = 3;
            decimal grossSalary = (decimal)0;

            // 3 retries to enter valid input
            while (retries > 0)
            {
                Console.Write("Enter your salary package amount: ");
                var salaryInput = Console.ReadLine();

                if (decimal.TryParse(salaryInput, out grossSalary) == false)
                    Console.WriteLine("Invalid salary package amount. Try again");
                else break;

                retries--;
                if (retries == 0) Environment.Exit(0);
            }
            
            retries = 3;
            PayFrequencyEnum payFrequency = 0;
            while (retries > 0)
            {
                Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
                var payFrequencyInput = Console.ReadLine();

                if (Enum.TryParse(typeof(PayFrequencyEnum), payFrequencyInput, true, out object? result) == false)
                    Console.WriteLine("Invalid pay frequency. Try again");
                else
                {
                    payFrequency = (PayFrequencyEnum)result;
                    break;
                }

                retries--;
                if (retries == 0) Environment.Exit(0);
            }

            var calculator = new SalaryDetailsCalculator(grossSalary, payFrequency);

            try
            {
                Console.WriteLine("");
                Console.WriteLine("Calculating salary details...");
                Console.WriteLine("");

                // Set variables that can change depending on year
                // Set super rate
                calculator.SetSuperannuationPercentage(superannuationPercentage);
                // Set any deduction types
                calculator.SetDeductions(deductions);

                var details = calculator.Calculate();

                Console.WriteLine("Gross package: {0:C2}", grossSalary);
                Console.WriteLine("Superannuation: {0:C2}", details.Superannuation);
                Console.WriteLine("");

                Console.WriteLine("Taxable income: {0:C2}", details.TaxableIncome);
                Console.WriteLine("");

                // Deductions are in a list
                if (details.Deductions.Count > 0) Console.WriteLine("Deductions:");
                foreach (var deduct in details.Deductions)
                {
                    Console.Write(deduct.DeductionName + ": ");
                    Console.WriteLine("{0:C2}", deduct.DeductionAmount);
                }
                Console.WriteLine("");

                Console.WriteLine("Net income: {0:C2}", details.NetIncome);
                Console.WriteLine("Pay packet: {0:C2} {1}", details.PayPacket, details.PayPacketFrequencyString);
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}
