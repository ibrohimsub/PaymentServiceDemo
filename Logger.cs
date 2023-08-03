namespace PaymentServiceDemo
{
    public class Logger
    {
        public void LogTransaction(string message)
        {
            Console.WriteLine($"[Transaction Log] {DateTime.Now}: {message}");
        }
    }
}

