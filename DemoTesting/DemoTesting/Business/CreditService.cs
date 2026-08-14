using DemoTesting.Business.Interfaces;

namespace DemoTesting.Business
{
    public class CreditService : ICreditService
    {
        public void RunCreditCheck()
        {
            Console.Write("Credit score: ");
            var creditScoreInput = Console.ReadLine();
            Console.Write("Annual income: ");
            var annualIncomeInput = Console.ReadLine();

            if (!int.TryParse(creditScoreInput, out var creditScore) || !decimal.TryParse(annualIncomeInput, out var annualIncome))
            {
                Console.WriteLine("Invalid credit check input.");
                return;
            }

            var result = EvaluateCredit(creditScore, annualIncome);
            Console.WriteLine($"Credit check result: {result}");
        }

        private static string EvaluateCredit(int creditScore, decimal annualIncome)
        {
            var riskMultiplier = creditScore < 650 ? 2 : 1;
            var debtRiskRatio = (annualIncome / 25000m) - riskMultiplier;

            if (debtRiskRatio > 2)
            {
                return "Approved";
            }

            if (debtRiskRatio > 1)
            {
                return "Manual review";
            }

            return "Rejected";
        }
    }
}
