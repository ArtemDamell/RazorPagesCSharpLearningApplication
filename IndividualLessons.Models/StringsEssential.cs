using System.Collections.Generic;

namespace IndividualLessons.Models
{
    public class StringsEssential
    {
        // Свойство для начальной строки с текстом для отправки на обработку
        public string OriginalString { get; set; }
        // Свойство для возврата обработанной строки
        public string ConvertedString { get; set; }
        // Экземпляр класса перечислителя
        public FunctionEnum FunctionEnum { get; set; } = FunctionEnum.None;
        // Свойство для лёгкой реализации задания 1.2
        public int CharCount { get; set; }
        // Свойство для сложного варианта реализации задания 1.2 либо реализация задания 1.5
        public Dictionary<char, int> CharacterDictionary { get; set; } = new Dictionary<char, int>();

        // 2. (1.3) Создаём свойство для получения символа из представления
        public char WordStartEndCharacter { get; set; }

        // (1.4) Создаём свойство для слова, которое будем искать в строке
        // Остальные свойства уже есть, задействуем их
        public string SearchingWord { get; set; }

        // (1.6) Создаём свойство для получения слова, на которое заменять
        public string ReplacingWord { get; set; }
    }
}
