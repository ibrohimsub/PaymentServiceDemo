using System;
namespace PaymentServiceDemo
{
    public class CustomerPayment
    {
        public ProductCategory ProductCategory { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentMonths { get; set; }
        public decimal TotalAmount { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

