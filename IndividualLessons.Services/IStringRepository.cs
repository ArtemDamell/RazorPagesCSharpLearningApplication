using IndividualLessons.Models;

namespace IndividualLessons.Services
{
    // Создаём интерфейс с необходимыми методами обработки запросов к базе данных
    // Интерфейсу не надо знать, как методы будут реализовывать логику, тут мы только декларируем, что методы будут принимать и какой тип будет возвращать
    public interface IStringRepository
    {
        // Exercise 1.1
        StringsEssential GetStringCapitalizeFormat(string capitalizeFormattingText);

        // Exercise 1.2
        StringsEssential GetWordsCount(string originalString);

        // Exercise 1.3
        StringsEssential StartAndFinishChar(char startEndChar, string originalString);

        // Exercise 1.4
        StringsEssential SomeWordsCount(string searchingWord, string originalString);

        // Exercise 1.5
        StringsEssential ContainWord(string originalString);

        // Exercise 1.6
        StringsEssential ReplaceWord(string originalString, string currentWord, string replacingWord);
    }
}
