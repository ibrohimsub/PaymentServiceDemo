using System.Text.Json;

namespace PaymentServiceDemo
{
    public class PaymentRepository
    {
        private const string PaymentFilePath = "payments.json";

        public List<CustomerPayment> LoadPaymentsFromDatabase()
        {
            if (File.Exists(PaymentFilePath))
            {
                string json = File.ReadAllText(PaymentFilePath);
                return JsonSerializer.Deserialize<List<CustomerPayment>>(json);
            }
            else
            {
                return new List<CustomerPayment>();
            }
        }

        public void SavePaymentsToDatabase(List<CustomerPayment> payments)
        {
            string json = JsonSerializer.Serialize(payments, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PaymentFilePath, json);
        }
    }
}

