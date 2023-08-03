using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

using PaymentServiceDemo;

public enum ProductCategory
{
    Smartphone = 9,
    Computer = 12,
    TV = 18
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ISmsService smsService = new SmsService();
            PaymentService paymentService = new PaymentService(smsService);

            Console.Write("Enter product category (Smartphone/Computer/TV): ");
            if (!Enum.TryParse<ProductCategory>(Console.ReadLine(), true, out ProductCategory productCategory))
            {
                Console.WriteLine("Invalid product category.");
                return;
            }

            Console.Write("Enter product amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Amount must be a positive number.");
                return;
            }

            decimal totalAmount = paymentService.CalculateTotalAmount(productCategory, amount);

            Console.Write("Enter installment months (3/6/9/12/18/24): ");
            if (!int.TryParse(Console.ReadLine(), out int installmentMonths) || !IsValidInstallment(productCategory, installmentMonths))
            {
                Console.WriteLine("Invalid installment months.");
                return;
            }

            Console.Write("Enter customer phone number: ");
            string phoneNumber = Console.ReadLine();

            Logger logger = new Logger();
            logger.LogTransaction($"Payment completed for {productCategory} - Total Amount: {totalAmount}");

            PaymentRepository paymentRepository = new PaymentRepository();
            List<CustomerPayment> payments = paymentRepository.LoadPaymentsFromDatabase();
            payments.Add(new CustomerPayment
            {
                ProductCategory = productCategory,
                Amount = amount,
                InstallmentMonths = installmentMonths,
                TotalAmount = totalAmount,
                PhoneNumber = phoneNumber,
                PaymentDate = DateTime.Now
            });
            paymentRepository.SavePaymentsToDatabase(payments);

            string smsMessage = $"Thank you for your purchase!\nProduct: {productCategory}, Total Amount: {totalAmount} somonies";
            smsService.SendSms(phoneNumber, smsMessage);

            Console.WriteLine("Payment completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while processing the payment: " + ex.Message);
        }

        Console.ReadLine();
    }

    static bool IsValidInstallment(ProductCategory productCategory, int months)
    {
        int maxMonths = (int)productCategory;
        return months >= 3 && months <= maxMonths;
    }
}
