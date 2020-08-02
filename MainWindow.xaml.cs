using System.Collections.Generic;
using System.Windows;
using Departments = DocsVisionClient.DocsVisionClasses.Departments;

namespace DocsVisionClient.DocsVisionWindows
{
    /// <summary>
    /// Объявляем делегат на метод, который будет вызываться из окна работы с отделами и окна работы с письмами
    /// </summary>
    /// <param name="inputDepartments"> Список отделов пространства имен сервера </param>
    /// <returns> Конвертированный список отделов </returns>
    public delegate List<Departments> ConvertedDepartments(List<DocsVisionService.Departments> inputDepartments);

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор по умолчанию главного окна программы (стартового окна)
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            #region // Подписываемся на события нажатия кнопок главного окна
            ButtonSettings.Click += ButtonSettings_Click;       // Событие нажатия на кнопку настроек
            ButtonDepartments.Click += ButtonDepartments_Click; // Событие нажатия на кнопку работы с отделами
            ButtonLetters.Click += ButtonLetters_Click;         // Событие нажатия на кнопку работы с письмами
            #endregion
        }

        /// <summary>
        /// Обработчик нажатия на кнопку вызова окна настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр класса окна работы с настройками программы
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog(); // Вызываем как диалоговое окно
        }

        /// <summary>
        /// Обработчик нажатия на кнопку вызова окна работы с отделами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDepartments_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр класса окна работы с отделами и передаем в его конструктор делегат метода конвертирования из одного в другое пространство имен
            DepartmentsWindow departmentsWindow = new DepartmentsWindow(ConvertDepartments);
            departmentsWindow.ShowDialog(); // Вызываем как диалоговое окно
        }

        /// <summary>
        /// Обработчик нажатия на кнопку вызова окна работы с письмами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLetters_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр класса окна работы с письмами и передаем в его конструктор делегат метода конвертирования из одного в другое пространство имен
            LettersWindow lettersWindow = new LettersWindow(ConvertDepartments);
            lettersWindow.ShowDialog(); // Вызываем как диалоговое окно
        }

        /// <summary>
        /// Метод конвертирования полученного списка отделов (из одного в другое пространство имен)
        /// </summary>
        /// <param name="inputDepartments"> Список получен в другом пространстве имен (со стороны сервера) </param>
        /// <returns> Конвертированный список отделов </returns>
        private List<Departments> ConvertDepartments(List<DocsVisionService.Departments> inputDepartments)
        {
            Departments departments; // Объявляем временный список отделов
            List<Departments> ConvertedDepartments = new List<Departments>(); // Создаем экземпляр конвертированного списка отделов
            #region Цикл: пробегаем по элементам полученного с сервера списка
            for (int i = 0; i < inputDepartments.Count; i++)
            {
                departments = new Departments(); // Создаем новый экземпляр класса отделов
                departments.IDDepartment = inputDepartments[i].IDDepartment;
                departments.DepartmentName = inputDepartments[i].DepartmentName;
                departments.DepartmentComment = inputDepartments[i].DepartmentComment;
                departments.MainDepartmentFlag = inputDepartments[i].MainDepartmentFlag;
                ConvertedDepartments.Add(departments); // Добавляем в список конвертированный отдел
            }
            #endregion
            return ConvertedDepartments; // Возвращаем конвертированный список отделов
        }
    }
}
