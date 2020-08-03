using DocsVisionClient.DocsVisionService;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DocsVisionClient.DocsVisionWindows
{
    #region Объявляем делегаты
    public delegate void ShowLettersList(int positionIndex, string selectCondition); // Объявляем тип делегата метода отображения списка писем
    #endregion

    /// <summary>
    /// Логика взаимодействия для LettersWindow.xaml (окно работы с письмами)
    /// </summary>
    public partial class LettersWindow : Window
    {
        #region Блок определений
        private List<Letters> lettersList = new List<Letters>();                                  // Создаем список писем
        private List<Departments> departmentsList = new List<Departments>();                      // Создаем список отделов
        private List<TagsOfLetter> tagsOfLetterList = new List<TagsOfLetter>();                   // Создаем список тэгов письма
        private readonly DocsVisionServiceClient DocsVisionStage = new DocsVisionServiceClient(); // Подключаемся к WCF-сервису
        private string selectCondition;                                                           // Объявляем условие поиска
        #endregion

        /// <summary>
        /// Конструктор окна работы с письмами
        /// </summary>
        public LettersWindow()
        {
            InitializeComponent();
            // Получаем кортеж списка отделов и кода ошибки
            (List<Departments> selectDepartments, int selectErrCode) = DocsVisionStage.GetAllDepartments();
            if(selectErrCode == 1) // Проверка на успешность выборки списка отделов
            {
                departmentsList = selectDepartments; // Сохраняем список отделов
                if(departmentsList.Count == 0)
                {
                    // В БД не обнаружены отделы - дальнейшая работа с письмами невозможна, уведомляем об этом пользователя
                    MessageBox.Show("В базе данных нет ни одного отдела! Работа с письмами невозможна!\nСоздайте хотя бы один отдел!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // Закрываем окно
                }
                else
                {
                    // Если в БД есть отделы, то продолжаем
                    Loaded += LettersWindow_Loaded; // Подписываемся на событие загрузки окна
                }
            }
            else
            {
                // В случае неуспешной выборки отделов выдаем сообщение пользователю
                MessageBox.Show("Не удалось получить список отделов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //TODO Проработать действия на случай неудачного запроса
            }
            selectCondition = "SELECT * FROM tbLetters"; // Задаем условие поиска всех писем - данное условие может быть изменено в окне настроек
        }

        /// <summary>
        /// Обработчик загрузки окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LettersWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lookUpDepartments.ItemsSource = departmentsList; // Присоединяем к LookUp-полю список отделов
            #region Подписываемся на события нажатия кнопок
            btnNewLetter.Click    += BtnNewLetter_Click;    // Кнопка создания нового письма
            btnDeleteLetter.Click += BtnDeleteLetter_Click; // Кнопка удаления выбранного письма
            btnEditLetter.Click   += BtnEditLetter_Click;   // Кнопка редактирования выбранного письма
            btnSelect.Click       += BtnSelect_Click;       // Кнопка поиска по критериям
            #endregion
            ShowLetters(0, selectCondition); // Отображение списка писем по указанному запросу выборки - здесь: все письма из БД
            dgLetters.SelectionChanged += DgLetters_SelectionChanged; // Подписываемся на событие выбора записи в DataGrid
            dgLetters.Focus();                                        // Устанавливаем фокус на первой записи
        }

        /// <summary>
        /// Обработчик нажатия кнопки поиска по условию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            dgLetters.SelectionChanged -= DgLetters_SelectionChanged; // Отписываемся от события выбора позиции в DataGrid
            SelectBuilder(); // Вызываем метод построителя запроса поиска - результат - измененное поле selectCondition
            ShowLetters(0, selectCondition); // Отображаем письма с позиционированием на первой записи в соответствии с уловиями поиска
            dgLetters.SelectionChanged += DgLetters_SelectionChanged; // Подписываемся на событие выбора записи в DataGrid
            dgLetters.Focus(); // Устанавливаем фокус на первой записи
        }

        /// <summary>
        /// Построитель динамического запроса поиска
        /// </summary>
        /// <returns></returns>
        private void SelectBuilder()
        {
            // Вводим блок переменных для потенциальной корректировки и расширения
            string whereString = "SELECT * FROM tbLetters";
            string nameString = "%" + tbSearchString.Text + "%";
            string senderString = "%" + tbSearchSender.Text + "%";
            string recepientString = "%" + tbSearchRecipient.Text + "%";
            string tagString = "%" + tbSearchTag.Text + "%";
            // Далее возможны два варианта событий - поле тэга имеет значение и не имеет значения - то есть - пустое
            if (tbSearchTag.Text == "")
            {
                whereString += $" WHERE letterName LIKE '{nameString}' AND letterFrom LIKE '{senderString}' AND letterTo LIKE '{recepientString}'";
            }
            else
            {
                whereString += $", tbTagsOfLetters, tbTags " +
                               $"WHERE id_Letter = id_LetterLink AND id_Tag = id_TagLink AND " +
                               $"letterName LIKE '{nameString}' AND letterFrom LIKE '{senderString}' AND letterTo LIKE '{recepientString}' AND tagName LIKE '{tagString}'";
            }
            // Устанавливаем пустые строки для дат
            string dateStart = "";
            string dateEnd = "";
            // Задание переменных в части условий поиска по датам
            if(dpSince.SelectedDate != null)
            {
                dateStart = $" AND letterDateTime >= '{dpSince.SelectedDate}'";
            }
            if (dpUpTo.SelectedDate != null)
            {
                dateEnd = $" AND letterDateTime <= '{dpUpTo.SelectedDate}'";
            }
            whereString += dateStart;
            whereString += dateEnd;
            selectCondition = whereString; // Завершаем формирование строки поиска
        }

        /// <summary>
        /// Обработчик нажатия на кнопку создания нового письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewLetter_Click(object sender, RoutedEventArgs e)
        {
            dgLetters.SelectionChanged -= DgLetters_SelectionChanged; // Отписываемся от события выбора позиции в DataGrid
            // Вызываем окно создания нового письма и передаем в конструктор окна (первый перегруженный конструктор) следующие аргументы:
            // 1. Список отделов организации;
            // 2. Делегат метода отображения списка писем;
            // 3. Условие поиска
            AddEditLetterWindow addEditLetterWindow = new AddEditLetterWindow(departmentsList, ShowLetters, selectCondition);
            addEditLetterWindow.ShowDialog(); // Вызываем окно как диалог (модально)
            dgLetters.SelectionChanged += DgLetters_SelectionChanged; // Снова подписываемся на событие выбора позиции в DataGrid
            dgLetters.Focus(); // Устанавливаем фокус на позиционированной записи (свойство SelectedIndex - эта позиция задается в методе ShowLetters, вызываемом через делегат)
        }

        /// <summary>
        /// Обработчик нажатия на кнопку редактирования выбранного письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditLetter_Click(object sender, RoutedEventArgs e)
        {
            dgLetters.SelectionChanged -= DgLetters_SelectionChanged; // Отписываемся от события выбора позиции в DataGrid
            // Вызываем окно создания нового письма и передаем в конструктор окна (второй перегруженный конструктор) следующие аргументы:
            // 1. Список отделов организации;
            // 2. Делегат метода отображения списка писем;
            // 3. Экземпляр выбранного для редактирования письма;
            // 4. Условие поиска
            AddEditLetterWindow addEditLetterWindow = new AddEditLetterWindow(departmentsList, ShowLetters, lettersList[dgLetters.SelectedIndex], selectCondition);
            addEditLetterWindow.ShowDialog(); // Вызываем окно как диалог (модально)
            dgLetters.SelectionChanged += DgLetters_SelectionChanged; // Снова подписываемся на событие выбора позиции в DataGrid
            dgLetters.Focus(); // Устанавливаем фокус на позиционированной записи (свойство SelectedIndex - эта позиция задается в методе ShowLetters, вызываемом через делегат)
        }

        /// <summary>
        /// Обработчик нажатия на кнопку удаления выбранного письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteLetter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Выбранное письмо ''{lettersList[dgLetters.SelectedIndex].LetterName}''\n" +
                                 "будет удалено!\n\n Продолжить?", "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                dgLetters.SelectionChanged -= DgLetters_SelectionChanged; // Отписываемся от события изменения выбора в DataGrid
                int indexPosition = dgLetters.SelectedIndex; // Получаем индекс выбранной (удаляемой) строки
                // Вызываем метод удаления письма (на сервере). После анализируем код ошибки
                int errorCode = DocsVisionStage.DeleteLetter(lettersList[dgLetters.SelectedIndex].IDLetter);
                if (errorCode == 1)
                {
                    // Удаление прошло успешно (код = 1)
                    if (indexPosition != 0) // Проверяем, был ли индекс удаляемой записи нулевым (первая запись)
                    {
                        ShowLetters(indexPosition -1, "SELECT * FROM tbLetters"); // Позиционируем выбор в DataGrid на предыдущей записи перед удаляемой записью
                    }
                    // Если индекс удаляемой записи был равен 0, то ничего не делаем
                }
                else
                {
                    // Если сервер вернул отрицательное значение - неизвестная ошибка-код, то выводится сообщение пользователю
                    MessageBox.Show($"Во время операции удаления письма возникла ошибка: {errorCode}\n Требуется хирургическое вмешательство!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            dgLetters.Focus();                                        // Устанавливаем фокус на строке позиционирования
            dgLetters.SelectionChanged += DgLetters_SelectionChanged; // Снова подписываемся на события изменения выбора в DataGrid
        }

        /// <summary>
        /// Обработчик события выбора записи в DataGrid (список писем)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgLetters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowLetterCharachteristics(); // Вызываем метод отображения параметров письма (таких как: комментарий и т.п.)
            // Вызываем метод получения тэгов выбранного письма - передаем в него идентификатор письма
            // Возвращаемое значение - кортеж
            // Первый параметр: Список тэгов выбранного письма;
            // Второй параметр: код ошибки
            (List<TagsOfLetter> selectTags, int tagsCode) = DocsVisionStage.GetTagsOfLetter(lettersList[dgLetters.SelectedIndex].IDLetter);
            if(tagsCode < 0)
            {
                // Произошла ошибка при получении списка тэгов письма, сообщаем об этом пользователю
                MessageBox.Show("При получении списка тэгов письма произошла ошибка! Тэги отображены не будут!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tagsOfLetterList = selectTags; // Сохраняем список тэгов письма
                listbxTagsLetter.ItemsSource = tagsOfLetterList; // Отображаем тэги в контроле-списке
            }
        }

        /// <summary>
        /// Метод отображения подробной информации по выделенному письму
        /// </summary>
        public void ShowLetterCharachteristics()
        {
            tbLetterContent.Text = lettersList[dgLetters.SelectedIndex].LetterContent; // Отображаем содержимое письма
            tbComment.Text = lettersList[dgLetters.SelectedIndex].LetterComment;       // Отображаем комментарий к письму
            // Отображаем системную дату (и время) занесения письма в БД на сервере (дата и время формируются автоматически)
            tbRegistrationDateTime.Text = lettersList[dgLetters.SelectedIndex].LetterRegisterDateTime.ToString("dd.MM.yyyy HH:mm:ss");
        }

        /// <summary>
        /// Метод отображения полученного списка писем в главном окне писем (метод является делегатом)
        /// </summary>
        /// <param name="positionIndex"> Индекс позиционируемой строки в списке писем </param>
        /// <param name="selectCondition"> Условие поиска </param>
        private void ShowLetters(int positionIndex, string selectCondition)
        {
            // Вызываем метод получения списка писем - в качестве аргумента передаем условие поиска
            // Возвращаемое значение - кортеж
            // Первый параметр: Список писем, соответствующий условию поиска;
            // Второй параметр: код ошибки
            (List<Letters> selectLetters, int selectCode) = DocsVisionStage.GetLetters(selectCondition);
            if(selectCode < 0)
            {
                // Если код ошибки отрицательный, то выборка не удалась, сообщаем пользователю
                MessageBox.Show($"Произошла ошибка при выборке писем! Код ошибки: {selectCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(positionIndex == 100000000)
            {
                // Если код ошибки равен 100000000 (сто миллионов), то это говорит о том, что добавленное или отредактированное письмо не попадает в условия поиска
                // Следовательно, оно отображено не будет, о чем будет сообщено пользователю
                // Метод кривой - надо искать другое решение (потому что записей в таблице писем божет быть больше ста миллионов)
                lettersList.Clear(); // Очищаем список писем
                MessageBox.Show("Созданное или отредактированное письмо не попадает в заданные критерии поиска! Оно отображено не будет!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                lettersList = selectLetters; // Получаем письма в соответствии с условиями поиска
                dgLetters.ItemsSource = lettersList;              // Перепривязываем список писем к DataGrid
                dgLetters.SelectedIndex = 0;                      // Устанавливаем позиционирование на первой записи результирующего списка писем
            }
            else
            {
                // Если все условия соответствуют, то:
                lettersList.Clear();                     // Очищаем список писем
                lettersList = selectLetters;             // Сохраняем список писем
                dgLetters.ItemsSource = lettersList;     // Перепривязываем список писем к DataGrid
                dgLetters.SelectedIndex = positionIndex; // Позиционируем список выбранных писем на индексированной записи
            }
        }
    }
}