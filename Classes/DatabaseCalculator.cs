using System.Data.SqlClient;
using System.Data;

namespace B1FirstTaskConsoleApp.Classes
{
    public class DatabaseCalculator
    {
        public static void CalculateAndDisplay()
        {
            // Подключение к базе данных
            string connectionString = @"Data Source=.;Initial Catalog=B1FirstTaskDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Открытие подключения
                connection.Open();

                // Создание команды для вызова хранимой процедуры
                SqlCommand command = new SqlCommand("dbo.CalculateSumAndMedian", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Выполнение хранимой процедуры
                SqlDataReader reader = command.ExecuteReader();

                // Чтение результатов
                if (reader.Read())
                {
                    decimal sumOfEvenNumbers = reader.GetDecimal(0);
                    decimal medianOfDecimalNumbers = reader.GetDecimal(1);

                    // Вывод результата в консоль
                    Console.WriteLine($"Сумма четных чисел: {sumOfEvenNumbers}");
                    Console.WriteLine($"Медиана десятичных чисел: {medianOfDecimalNumbers}");
                }

                // Закрытие подключения
                connection.Close();
            }
        }
    }
}
