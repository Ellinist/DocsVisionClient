namespace DocsVisionClient.DocsVisionClasses
{
    /// <summary>
    /// Класс отделов организации
    /// </summary>
    public class Departments
    {
        // Задаем автосвойства - в случае необходимости осуществления проверок - заменить на свойства
        public int IDDepartment { get; set; }         // Идентификатор отдела (генерируется сервером)
        public string DepartmentName { get; set; }    // Название отдела
        public string DepartmentComment { get; set; } // Комментарий по отделу
        public bool MainDepartmentFlag { get; set; }  // Флаг принадлежности отдела к головному
    }
}
