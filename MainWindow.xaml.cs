using System.Collections.Generic;
using System.Windows;

namespace DocsVisionClient.DocsVisionWindows
{
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
            // Создаем экземпляр класса окна работы с отделами
            DepartmentsWindow departmentsWindow = new DepartmentsWindow();
            departmentsWindow.ShowDialog(); // Вызываем как диалоговое окно
        }

        /// <summary>
        /// Обработчик нажатия на кнопку вызова окна работы с письмами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLetters_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр класса окна работы с письмами
            LettersWindow lettersWindow = new LettersWindow();
            lettersWindow.ShowDialog(); // Вызываем как диалоговое окно
        }
    }
}
