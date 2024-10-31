using System.Data.SqlClient;

namespace B1FirstTaskConsoleApp.Classes
{
    public class DatabaseImporter
    {
        public static void ImportData(string fileName, string tableName)
        {
            string connectionString = @"Data Source=.;Initial Catalog=B1FirstTaskDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            int importedRows = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split("||");
                        string sql = $"INSERT INTO {tableName} (Date, LatinChars, RussianChars, EvenNumber, DecimalNumber) VALUES (@Date, @LatinChars, @RussianChars, @EvenNumber, @DecimalNumber)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Date", Convert.ToDateTime(fields[0]));
                            command.Parameters.AddWithValue("@LatinChars", fields[1]);
                            command.Parameters.AddWithValue("@RussianChars", fields[2]);
                            command.Parameters.AddWithValue("@EvenNumber", Convert.ToInt32(fields[3]));
                            command.Parameters.AddWithValue("@DecimalNumber", Convert.ToDouble(fields[4]));
                            command.ExecuteNonQuery();
                        }

                        importedRows++;

                        // Выводим информацию о ходе импорта
                        if (importedRows % 10000 == 0)
                        {
                            Console.WriteLine($"Импортировано строк: {importedRows}");
                        }
                    }
                }
            }

            Console.WriteLine($"Импортировано строк: {importedRows}");
        }
    }
}
