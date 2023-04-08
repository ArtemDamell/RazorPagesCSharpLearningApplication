using ConsoleAppForTest.Models;

namespace ConsoleAppForTest.Methods
{
    public class CharCountMethod
    {
        // Простой вариант реализации, выводим только количество символов (1.2)
        /// <summary>
        /// The method show char count in string
        /// </summary>
        /// <param name="originalString">Input string value</param>
        /// <returns>int Char Count</returns>
        public int GetCount(string originalString)
        {
            // Убираем все пробелы в строке
            var tempString = originalString.Replace(" ", "");

            // Получаем количество символов и возвращаем его
            return tempString.Length;
        }

        /// <summary>
        /// Get all characters and his count
        /// </summary>
        /// <param name="originalString">Input string value</param>
        /// <returns>Dictionary char word and count value</returns>
        // Сложный вариант реализации логики подсчёта символов (1.2, 1.5) (Вариант 2)
        public StringsLearnModel GetCharCount(string originalString)
        {
            // Инициализируем новый экземпляр класса модели
            StringsLearnModel slm = new StringsLearnModel();

            // Конвертируем в массив символов
            var charArray = originalString.ToCharArray();

            // Пробегаем циклом по всем элементам строки
            for (int i = 0; i < charArray.Length; i++)
            {
                // Если словарь == null или не содержит элемента с таким ключём и символ не пуст
                if (slm.CharacterDictionary == null || !slm.CharacterDictionary.ContainsKey(charArray[i]) && charArray[i] != ' ')
                {
                    // Добавляем значемие в словарь
                    slm.CharacterDictionary?.Add(charArray[i], 1);
                }
                // Иначе, если словарь содержит ключ
                else if (slm.CharacterDictionary.ContainsKey(charArray[i]))
                {
                    // Добавляем 1 к значению ключа
                    slm.CharacterDictionary[charArray[i]] += 1;
                }
            }
            // Возвращаем модель
            return slm;
        }
    }
}
