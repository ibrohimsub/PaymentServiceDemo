using System;
namespace PaymentServiceDemo
{
    public class PaymentService
    {
        private readonly ISmsService _smsService;

        public PaymentService(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public decimal CalculateTotalAmount(ProductCategory productCategory, decimal amount, int installmentMonths)
        {
            decimal totalAmount = amount;

            if (productCategory == ProductCategory.Smartphone)
            {
                totalAmount += amount * (installmentMonths - 3) * 0.03m;
            }
            else if (productCategory == ProductCategory.Computer)
            {
                totalAmount += amount * (installmentMonths - 3) * 0.04m;
            }
            else if (productCategory == ProductCategory.TV)
            {
                totalAmount += amount * (installmentMonths - 3) * 0.05m;
            }

            return totalAmount;
        }
    }

}
