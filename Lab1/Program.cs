namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryXMLReader reader = new DictionaryXMLReader();
            Console.WriteLine("Укажите путь к считываемому справочнику N018 в формате XML:");
            String path = Console.ReadLine();
            bool result = false;

            try
            {
                List<DictionaryBaseType> dataList = reader.ReadFromXml(path);

                DictionaryJsonWriter writer = new DictionaryJsonWriter();

                Console.WriteLine("Укажите путь для записи:");
                String outputPath = Console.ReadLine();

                if (dataList.Count < 1)
                {
                    Console.WriteLine("Передан неверный XML");
                }
                else if (dataList.Count == 1)
                {
                    result = writer.WriteToJson(dataList[0], outputPath);
                }
                else
                {
                    result = writer.WriteManyToJson(dataList, outputPath);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка: данный путь не найден");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Попытка записи в защищённую область");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка: Файл не существует");
            }

            if (!result) Console.WriteLine("Произошла ошибка");
            else Console.WriteLine("Файл успешно записан");
        }
    }
}
