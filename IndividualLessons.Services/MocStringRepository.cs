using IndividualLessons.Models;

namespace IndividualLessons.Services
{
    public class MocStringRepository : IStringRepository
    {
        private StringsEssential _strings;


        /// <summary>
        /// This method capitalizes the first letter of each sentence in a given string.
        /// </summary>
        /// <param name="capitalizeFormattingText">The string to be capitalized.</param>
        /// <returns>A StringsEssential object containing the capitalized string.</returns>
        public StringsEssential GetStringCapitalizeFormat(string capitalizeFormattingText)
        {
            _strings = new StringsEssential();

            var tempVar = capitalizeFormattingText.ToLower().Split('.');
            foreach (var item in tempVar)
            {
                var temp = item;

                if (temp.StartsWith(" "))
                    temp = temp.Remove(0, 1);

                if (temp == "")
                    break;

                temp = temp.Substring(0, 1).ToUpper() + (temp.Length > 1 ? temp.Substring(1) : "");
                temp = $"{temp}. ";

                _strings.ConvertedString += temp;
            }
            _strings.FunctionEnum = FunctionEnum.Capitalize;
            return _strings;
        }

        /// <summary>
        /// This method returns an object of type StringsEssential which contains the character count of the given string after removing all spaces.
        /// </summary>
        /// <param name="originalString">The string for which the character count is to be calculated.</param>
        /// <returns>An object of type StringsEssential containing the character count of the given string.</returns>
        public StringsEssential GetWordsCount(string originalString)
        {
            _strings = new StringsEssential();
            var tempString = originalString;

            tempString = tempString.Replace(" ", "");

            _strings.CharCount = tempString.Length;
            _strings.FunctionEnum = FunctionEnum.WordCount;

            return _strings;
        }

        /// <summary>
        /// This method takes a character and a string as parameters and returns a StringsEssential object. 
        /// It checks if the words in the string start and end with the given character and returns the number of words that do and 
        /// the modified string.
        /// </summary>
        /// <param name="startEndChar">The character to check for at the start and end of words</param>
        /// <param name="originalString">The string to check for words starting and ending with the given character</param>
        /// <returns>
        /// A StringsEssential object containing the number of words that start and end with the given character and the 
        /// modified string
        /// </returns>
        public StringsEssential StartAndFinishChar(char startEndChar, string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("–", "")
                .Replace("!", "")
                .Replace(".", "")
                .Split(' ');

            foreach (var item in tempString)
            {
                if (item.StartsWith(startEndChar.ToString().ToLower()) && item.EndsWith(startEndChar.ToString().ToLower()))
                {
                    _strings.CharCount += 1;
                    _strings.ConvertedString += $"'{item}'   ";
                }
            }

            if (string.IsNullOrWhiteSpace(_strings.ConvertedString))
                _strings.ConvertedString = $"Words not contain char in start and end '{startEndChar}'";

            _strings.FunctionEnum = FunctionEnum.SomeWordStartFinish;
            _strings.WordStartEndCharacter = startEndChar;

            return _strings;
        }

        // Exercise 1.4
        /// <summary>
        /// Counts the number of occurrences of a given word in a string.
        /// </summary>
        /// <param name="searchingWord">The word to search for.</param>
        /// <param name="originalString">The string to search in.</param>
        /// <returns>A StringsEssential object containing the number of occurrences of the given word.</returns>
        public StringsEssential SomeWordsCount(string searchingWord, string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("?", "")
                .Replace(",", "")
                .Replace(":", "")
                .Split(' ');

            foreach (var item in tempString)
            {
                if (item.Contains(searchingWord))
                    _strings.CharCount += 1;
            }

            _strings.ConvertedString = searchingWord;
            _strings.FunctionEnum = FunctionEnum.SomeWordsCount;

            return _strings;
        }

        /// <summary>
        /// This method takes a string and returns a StringsEssential object containing a dictionary of characters and their count, as well as the function enum.
        /// </summary>
        /// <param name="originalString">The string to be processed.</param>
        /// <returns>A StringsEssential object containing a dictionary of characters and their count, as well as the function enum.</returns>
        public StringsEssential ContainWord(string originalString)
        {
            _strings = new StringsEssential();

            var tempString = originalString.ToLower()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("?", "")
                .Replace(",", "")
                .Replace(":", "")
                .Replace(" ", "")
                .ToCharArray();

            foreach (var item in tempString)
            {
                if (!_strings.CharacterDictionary.ContainsKey(item))
                {
                    _strings.CharacterDictionary.Add(item, 1);
                }
                else
                {
                    _strings.CharacterDictionary[item] += 1;
                }
            }

            _strings.FunctionEnum = FunctionEnum.ContainWord;

            return _strings;
        }

        /// <summary>
        /// Replaces a word in a string with another word.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <param name="currentWord">The word to be replaced.</param>
        /// <param name="replacingWord">The word to replace the current word.</param>
        /// <returns>A StringsEssential object containing the converted string and the function enum.</returns>
        public StringsEssential ReplaceWord(string originalString, string currentWord, string replacingWord)
        {
            _strings = new StringsEssential();

            var tempString = originalString;

            tempString = tempString.Replace(currentWord, replacingWord);

            _strings.ConvertedString = tempString;
            _strings.FunctionEnum = FunctionEnum.ReplaceWord;

            return _strings;
        }
    }
}
