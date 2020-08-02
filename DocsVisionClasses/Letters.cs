using System;

namespace DocsVisionClient.DocsVisionClasses
{
    /// <summary>
    /// Класс писем организации
    /// </summary>
    public class Letters
    {
        // Задаем автосвойства - в случае необходимости осуществления проверок - заменить на свойства
        public int IDLetter { get; set; }                    // Идентификатор письма
        public int IDDepartmentLetter { get; set; }          // Идентификатор отдела, к которому относится письмо
        public DateTime LetterRegisterDateTime { get; set; } // Дата регистрации письма на сервере - автоматическое занесение
        public string LetterName { get; set; }               // Название письма
        public DateTime LetterDateTime { get; set; }         // Дата получения или отправки письма
        public string LetterTopic { get; set; }              // Тема письма
        public string LetterFrom { get; set; }               // Отправитель письма
        public string LetterTo { get; set; }                 // Получатель письма (адресат)
        public string LetterContent { get; set; }            // Содержание письма
        public string LetterComment { get; set; }            // Комментарий к письму
        public bool IsLetterIncoming { get; set; }           // Флаг - является ли письмо входящим (true) или исходящим (false)
    }
}