using B1FirstTaskConsoleApp.Classes;

namespace B1FirstTaskConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                FileGenerator.GenerateFile($"file{i}.txt");
            }

            string pattern = "*.txt";
            string outputFileName = "merged.txt";
            string deletePattern = "abc";

            while (true)
            {
                Console.WriteLine("Введите паттерн удаления символов из строк:");
                deletePattern = Console.ReadLine();
                if (!deletePattern.All(char.IsLetter))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, вводите только английские буквы.");
                }
                else
                {
                    break;
                }
            }

            FileMerger.MergeFiles(pattern, outputFileName, deletePattern);

            string fileName = "merged.txt";
            string tableName = "FirstTaskData";

            DatabaseImporter.ImportData(fileName, tableName);

            DatabaseCalculator.CalculateAndDisplay();
            
            Console.WriteLine("Мы проделали все 4 операции один раз, дальше следует меню\n");

            // Повторяем операции, пока пользователь не выберет выход
            bool continueLoop = true;
            while (continueLoop)
            {
                // Выводим меню
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("2. Объединить файлы и удалить строки");
                Console.WriteLine("3. Импортировать данные в БД");
                Console.WriteLine("4. Вычислить сумму и медиану");
                Console.WriteLine("5. Выйти из программы");

                // Получаем выбор пользователя
                int choice = int.Parse(Console.ReadLine());

                // Выполняем выбранную операцию
                switch (choice)
                {
                    case 2:
                        // Объединение файлов и удаление строк
                        while (true)
                        {
                            Console.WriteLine("Введите паттерн удаления символов из строк:");
                            deletePattern = Console.ReadLine();
                            if (!deletePattern.All(char.IsLetter))
                            {
                                Console.WriteLine("Неверный ввод. Пожалуйста, вводите только английские буквы.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        FileMerger.MergeFiles(pattern, outputFileName, deletePattern);
                        break;
                    case 3:
                        // Импорт данных в БД

                        DatabaseImporter.ImportData(fileName, tableName);
                        break;
                    case 4:
                        // Вычисление суммы и медианы
                        DatabaseCalculator.CalculateAndDisplay();
                        break;
                    case 5:
                        // Выход из программы
                        continueLoop = false;
                        break;
                    default:
                        // Неверный выбор
                        Console.WriteLine("Неверный выбор. Повторите попытку.");
                        break;
                }
            }
        }
    }
}
