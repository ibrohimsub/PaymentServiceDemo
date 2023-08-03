using System.Text.Json;

namespace PaymentServiceDemo
{
    public class PaymentRepository
    {
        private const string PaymentFilePath = "/Users/ibragim/Desktop/PaymentServiceDemo/payments.json";

        public List<CustomerPayment> LoadPaymentsFromDatabase()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Error loading payments from database: " + ex.Message);
                return new List<CustomerPayment>();
            }
        }

        public void SavePaymentsToDatabase(List<CustomerPayment> payments)
        {
            try
            {
                string json = JsonSerializer.Serialize(payments, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PaymentFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving payments to database: " + ex.ToString());
            }
        }

    }
}
