namespace B1FirstTaskConsoleApp.Classes
{
    public class FileGenerator
    {
        private static Random random = new Random();

        public static void GenerateFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int j = 1; j <= 100000; j++)
                {
                    // Генерируем случайную дату в диапазоне последних 5 лет
                    int randomYear = random.Next(DateTime.Now.Year - 5, DateTime.Now.Year + 1);
                    int randomDayOfYear = random.Next(1, 367); // Добавлен +1, чтобы учесть 366 дней в високосном году
                    DateTime randomDate = new DateTime(randomYear, 1, 1).AddDays(randomDayOfYear - 1); //  -1, чтобы получить 1-й день года, а не 2-й 

                    string formattedDate = randomDate.ToString("dd.MM.yyyy");

                    // Генерируем случайные символы
                    string latinChars = GenerateRandomString(10, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
                    string russianChars = GenerateRandomString(10, "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

                    // Генерируем случайные числа
                    int evenNumber = random.Next(1, 50000001) * 2; // Четное число
                    double decimalNumber = random.NextDouble() * 20;

                    // Записываем строку в файл
                    string line = $"{formattedDate}||{latinChars}||{russianChars}||{evenNumber}||{decimalNumber:F8}||";
                    writer.WriteLine(line);
                }
            }
        }

        // Вспомогательная функция для генерации случайной строки
        private static string GenerateRandomString(int length, string chars)
        {
            Random random = new Random();
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
    }
}
