using System;
using ConsoleAppForTest.Methods;
using ConsoleAppForTest.Models;

namespace ConsoleAppForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализируем модель данных и класс реализации методов
            StringsLearnModel slm = new StringsLearnModel();
            CharCountMethod charCountMethod = new CharCountMethod();

            // Вызываем и выводим лёгкий вариант реализации ------------------------
            slm.CharCount = charCountMethod.GetCount("Some string here!");
            Console.WriteLine($"Char count is: {slm.CharCount}\n\n");
            // ---------------------------------------------------------------------

            // Вызываем сложный вариант реализации ----------------------------
            slm = charCountMethod.GetCharCount("Some string here!");

            // Пробегаем по всем элементам словаря
            foreach (var item in slm.CharacterDictionary)
            {
                // Выводим в консоль сообщение со значениями
                Console.WriteLine($"Word '{item.Key}' contain(s) {item.Value} time(s)");
            }
            // ---------------------------------------------------------------
        }
    }
}
