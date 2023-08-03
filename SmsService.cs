using System;
namespace PaymentServiceDemo
{
    public class SmsService : ISmsService
    {
        public void SendSms(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
        }
    }

}

