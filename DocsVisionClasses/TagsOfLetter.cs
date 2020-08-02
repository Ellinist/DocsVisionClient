namespace DocsVisionClient.DocsVisionClasses
{
    /// <summary>
    /// Класс привязки тэгов к письмам
    /// </summary>
    public class TagsOfLetter
    {
        // Задаем автосвойства - в случае необходимости осуществления проверок - заменить на свойства
        public int IDLetterLink { get; set; } // Идентификатор письма
        public int IDTagLink { get; set; }    // Идентификатор привязанного к письму тэга
        public string TagName { get; set; }   // Название тэга
    }
}