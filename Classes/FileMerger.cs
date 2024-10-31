namespace B1FirstTaskConsoleApp.Classes
{
    public class FileMerger
    {
        public static void MergeFiles(string pattern, string outputFileName, string deletePattern)
        {
            int deletedRows = 0;
            List<string> mergedLines = new List<string>(); // Создайте список для хранения строк

            foreach (string filePath in Directory.GetFiles(".", pattern))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.Contains(deletePattern))
                        {
                            mergedLines.Add(line); // Добавьте строку в список
                        }
                        else
                        {
                            deletedRows++;
                        }
                    }
                }
            }

            // Запишите все строки в файл после чтения всех файлов
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string line in mergedLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Удалено строк: {deletedRows}");
        }
    }
}
