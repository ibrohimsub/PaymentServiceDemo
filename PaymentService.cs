namespace PaymentServiceDemo
{
    public class PaymentService
    {
        private readonly ISmsService _smsService;

        public PaymentService(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public decimal CalculateTotalAmount(ProductCategory productCategory, decimal amount)
        {
            decimal totalAmount = amount;

            if (productCategory == ProductCategory.Smartphone)
            {
                totalAmount += amount * 0.03m;
            }
            else if (productCategory == ProductCategory.Computer)
            {
                totalAmount += amount * 0.04m;
            }
            else if (productCategory == ProductCategory.TV)
            {
                totalAmount += amount * 0.05m;
            }

            return totalAmount;
        }
    }
}
