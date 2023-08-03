using System;
using PaymentServiceDemo;

public enum ProductCategory
{
    Smartphone,
    Computer,
    TV
}

class Program
{
    static void Main(string[] args)
    {
        PaymentService paymentService = new PaymentService();
        ISmsService smsService = new SmsService();

        Console.Write("Enter product category (Smartphone/Computer/TV): ");
        ProductCategory productCategory = Enum.Parse<ProductCategory>(Console.ReadLine(), true);
        if (!Enum.IsDefined(typeof(ProductCategory), productCategory))
        {
            Console.WriteLine("Invalid product category.");
            return;
        }

        Console.Write("Enter product amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter installment months (3/6/9/12/18/24): ");
        int installmentMonths = int.Parse(Console.ReadLine());
        if (amount <= 0 || installmentMonths <= 0)
        {
            Console.WriteLine("Amount and installment months must be greater than 0.");
            return;
        }

        Console.Write("Enter customer phone number: ");
        string phoneNumber = Console.ReadLine();

        decimal totalAmount = paymentService.CalculateTotalAmount(productCategory, amount, installmentMonths);

        Logger logger = new Logger();
        logger.LogTransaction($"Payment completed for {productCategory} - Total Amount: {totalAmount}");

        string smsMessage = $"Thank you for your purchase!\nProduct: {productCategory}, Total Amount: {totalAmount} somonies";
        smsService.SendSms(phoneNumber, smsMessage);

        Console.WriteLine("Payment completed successfully.");
    }
}
