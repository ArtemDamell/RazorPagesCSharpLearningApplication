using IndividualLessons.Models;
using IndividualLessons.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_1_Strings.Pages
{
    public class StringsModel : PageModel
    {
        // Внедряем зависимость псевдо базы данных через интерфейс -------------------------
        // Создаём приватную, только для чтения переменную для доступа к методам интерфейса
        private readonly IStringRepository _stringRepository;

        // Создаём конструктор класса без параметров, чтобы инициализировать переменную
        public StringsModel(IStringRepository stringRepository)
        {
            // Инициализируем переменную данными
            _stringRepository = stringRepository;
        }
        // ---------------------------------------------------------------------------------

        // Привязываем модель данных к представлению
        // Без привязки модель работает только на POST метод
        [BindProperty]
        public StringsEssential FirstString { get; set; }

        // GET метод представления
        public void OnGet()
        {

        }

        // Логика POST метода представления
        public IActionResult OnPost()
        {
            // Проверяем свойство перечислителя модели на переданное значение и переданную строку для обработки на null
            if (FirstString.FunctionEnum != FunctionEnum.None && FirstString.OriginalString != null)
            {
                // Передаём данные перечислителя в логическую конструкцию для выбора метода обработки
                switch (FirstString.FunctionEnum)
                {
                    // Если перечислитель передаёт значение Capitalize, то выполняем следующий код
                    case FunctionEnum.Capitalize:
                        {
                            // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                            // Сохраняем данные в модель представления
                            FirstString = _stringRepository.GetStringCapitalizeFormat(FirstString.OriginalString);

                            // Возвращаем представление
                            return Page();
                        }

                    // Exercise 1.2
                    // Если перечислитель передаёт значение WordCount, то выполняем следующий код
                    case FunctionEnum.WordCount:
                    {
                        // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                        // Сохраняем данные в модель представления
                        FirstString = _stringRepository.GetWordsCount(FirstString.OriginalString);

                        // Возвращаем представление
                        return Page();
                    }

                    // Exercise 1.3
                    // Если перечислитель передаёт значение WordCount, то выполняем следующий код
                    case FunctionEnum.SomeWordStartFinish:
                    {
                        // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                        // Сохраняем данные в модель представления
                        FirstString = _stringRepository.StartAndFinishChar(FirstString.WordStartEndCharacter,
                            FirstString.OriginalString);

                        // Возвращаем представление
                        return Page();
                    }

                    // Exercise 1.4
                    // Если перечислитель передаёт значение WordCount, то выполняем следующий код
                    case FunctionEnum.SomeWordsCount:
                    {
                        // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                        // Сохраняем данные в модель представления
                        FirstString = _stringRepository.SomeWordsCount(FirstString.SearchingWord,
                            FirstString.OriginalString);

                        // Возвращаем представление
                        return Page();
                    }

                    // Exercise 1.5
                    // Если перечислитель передаёт значение, то выполняем следующий код
                    case FunctionEnum.ContainWord:
                    {
                        // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                        // Сохраняем данные в модель представления
                        FirstString = _stringRepository.ContainWord(FirstString.OriginalString);

                        // Возвращаем представление
                        return Page();
                    }

                    // Exercise 1.6
                    // Если перечислитель передаёт значение, то выполняем следующий код
                    case FunctionEnum.ReplaceWord:
                    {
                        // Вызываем метод обработки через приватную переменную, передав в качесте параметра строку текста для обработки
                        // Сохраняем данные в модель представления
                        FirstString = _stringRepository.ReplaceWord(FirstString.OriginalString, FirstString.SearchingWord, FirstString.ReplacingWord);

                        // Возвращаем представление
                        return Page();
                    }
                }
            }

            // В любом другом случаи озвращаем представление
            return Page();
        }
    }
}