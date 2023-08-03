namespace PaymentServiceDemo
{
    public interface ISmsService
    {
        void SendSms(string phoneNumber, string message);
    }
}

