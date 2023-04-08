using System.Collections.Generic;
using IndividualLessons.Models;

namespace ConsoleAppForTest.Models
{
    public class StringsLearnModel
    {
        public string OriginalString { get; set; }
        public string ConvertedString { get; set; }
        public FunctionEnum FunctionEnum { get; set; } = FunctionEnum.None;

        // Свойство для лёгкой реализации задания 1.2
        public int CharCount { get; set; }
        // Свойство для сложного варианта реализации задания 1.2
        public Dictionary<char, int> CharacterDictionary { get; set; } = new Dictionary<char, int>();
    }
}
