using Microsoft.Extensions.Configuration;

namespace FirstMvcProject.Application.ExtentionFunctions
{
    public class VatCalculator
    {
        private double VAT;
        public VatCalculator(IConfiguration configuration) => VAT = configuration.GetValue<double>("VATSettings:VATPercentage");
        public double CalculateTotalPriceWithVat(int quantity, double price) => quantity * price * (1 + VAT);
    }
}
