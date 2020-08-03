using DocsVisionClient.DocsVisionService;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DocsVisionClient.DocsVisionWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEditLetterWindow.xaml
    /// </summary>
    public partial class AddEditLetterWindow : Window
    {
        #region Блок определений
        private ShowLettersList ShowLetters;                                    // Объявляем делегат метода обновления списка писем в окне работы с письмами
        private List<Departments> departmentsList = new List<Departments>();    // Создаем список отделов
        private List<Tags> tagsList = new List<Tags>();                         // Создаем список тэгов
        private List<TagsOfLetter> tagsOfLetterList = new List<TagsOfLetter>(); // Создаем список тэгов выбранного письма
        private readonly Letters inputLetters;                                  // Объявляем экземпляр класса письма
        private enum LetterOperation : int { adding = 1, modifying = 2 }        // Расширяемый перечислитель (при необходимости или изменении логики работы окна)
        private LetterOperation operation;                                      // Инициализируем перечислитель
        private DocsVisionServiceClient DocsVisionStage = new DocsVisionServiceClient(); // Подключаемся к WCF-сервису "BasicHttpBinding_IDocsVisionService"
        private string selectCondition;
        #endregion

        /// <summary>
        /// Конструктор для добавления нового письма
        /// </summary>
        /// <param name="departmentsList"> Список отделов организации </param>
        /// <param name="ShowLetters"> Делегат метода отображения списка писем в окне работы с письмами </param>
        /// <param name="selectCondition"> Условие поиска писем </param>
        public AddEditLetterWindow(List<Departments> departmentsList, ShowLettersList ShowLetters, string selectCondition)
        {
            // Инициализируем поля класса
            this.departmentsList = departmentsList;                           // Список отделов организации
            this.ShowLetters = ShowLetters;                                   // Делегат метода отображения списка писем окна работы с письмами
            this.selectCondition = selectCondition;                           // Условие поиска
            InitializeComponent();
            CommonStartActions();                                             // Вызываем метод общих операций
            btnAddEditLetter.Content = "Занести новое письмо в базу данных!"; // Меняем название финальной кнопки
            operation = LetterOperation.adding;                               // Устанавливаем флаг добавления новой записи в таблице писем
        }

        /// <summary>
        /// Конструктор для редактирования выбранного письма
        /// </summary>
        /// <param name="departmentsList"> Список отделов организации </param>
        /// <param name="ShowLetters"> Делегат метода отображения списка писем в окне работы с письмами </param>
        /// <param name="inputLetters"> Экземпляр класса выбранного письма (получен из окна работы с письмами) </param>
        /// <param name="selectCondition"> Условие поиска писем </param>
        public AddEditLetterWindow(List<Departments> departmentsList, ShowLettersList ShowLetters, Letters inputLetters, string selectCondition)
        {
            // Инициализируем поля класса
            this.inputLetters = inputLetters;                             // Экземпляр редактируемого письма
            this.departmentsList = departmentsList;                       // Список отделов организации
            this.ShowLetters = ShowLetters;                               // Делегат метода отображения списка писем окна работы с письмами
            this.selectCondition = selectCondition;                       // Условие поиска
            InitializeComponent();
            CommonStartActions();                                         // Вызываем метод общих операций
            ShowTagsOfLetter();                                           // Отображаем тэги редактируемого письма
            ShowEditableFields(inputLetters);                             // Отображаем поля редактируемого письма
            btnAddEditLetter.Content = "Внести изменения в базу данных!"; // Меняем название финальной кнопки
            operation = LetterOperation.modifying;                        // Устанавливаем флаг операции в значение редактирования письма
        }

        /// <summary>
        /// Метод общих операций для нового письма и редактирования существующего письма
        /// </summary>
        private void CommonStartActions()
        {
            // Подписываемся на события нажатия кнопок
            btnAddEditLetter.Click += BtnAddEditLetter_Click;
            btnAddTag.Click        += BtnAddTag_Click;
            btnDeleteTag.Click     += BtnDeleteTag_Click;
            btnInreaseTags.Click   += BtnInreaseTags_Click;
            combobxDepartments.ItemsSource = departmentsList; // Привязываем комбобокс выбора отдела к списку отделов
            // Вызываем метод получения тэгов (для использования в комбобоксе выбора тэгов)
            // Получаем кортеж: Первый параметр - список тэгов, второй параметр - код ошибки
            (List<Tags> inputTagsList, int errorCode) = DocsVisionStage.GetTags();
            if (errorCode < 0)
            {
                // Если произошла ошибка, выводим сообщение
                MessageBox.Show($"При получении списка тэгов возникла ошибка: {errorCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                combobxTags.ItemsSource = inputTagsList; // Сохраняем и связываем комбобокс со списком тэгов
            }
        }

        /// <summary>
        /// Метод отображения тэгов выбранного письма
        /// Метод вызывается только при редактировании письма - для нового письма метод не вызывается!
        /// </summary>
        private void ShowTagsOfLetter()
        {
            // Вызываем метод получения списка тэгов для выбранного письма по идентификатору письма
            // Получаем кортеж: список тэгов редактируемого письма и код ошибки
            (List<TagsOfLetter> tagsOfLetter, int tagsCode) = DocsVisionStage.GetTagsOfLetter(inputLetters.IDLetter);
            if(tagsCode < 0)
            {
                // В случае возникновения ошибки выводим ее пользователю
                MessageBox.Show($"При получении списка тэгов редактируемого письма произошла ошибка: {tagsCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // В случае успешного выполнения операции, сохраняем список тэгов и отображаем в контроле списка тэгов письма
                tagsOfLetterList = tagsOfLetter;
                listbxTagsOfLetter.ItemsSource = tagsOfLetterList;
                listbxTemp.ItemsSource = tagsOfLetter;
            }
        }

        /// <summary>
        /// Метод обработки нажатия кнопки добавления нового тэга в общий список тэгов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInreaseTags_Click(object sender, RoutedEventArgs e)
        {
            TagsWindows tagsWindows = new TagsWindows(); // Создаем экземпляр класса окна работы с тэгами
            tagsWindows.ShowDialog();                    // Вызываем диалоговое окно
            // После возврата из окна работы с тэгами
            // Вызываем метод получения обновленного списка тэгов из БД (для обновления комбобокса со списком тэгов)
            // Возвращается кортеж: Первый параметр - список тэгов, второй параметр - код ошибки
            (List<Tags> inputTagsList, int errorCode) = DocsVisionStage.GetTags();
            if (errorCode < 0)
            {
                // В случае возникновения ошибки выборки списка тэгов, выводим сообщение пользователю
                MessageBox.Show($"При получении списка тэгов возникла ошибка: {errorCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // В случае успешной операции
                tagsList.Clear(); // Очищаем список тэгов в классе окна
                combobxTags.ItemsSource = inputTagsList; // Привязываем обновленный список тэгов к комбобоксу выбора тэгов
            }
        }

        /// <summary>
        /// Метод удаления выбранного тэга письма - нажатие на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            tagsOfLetterList.RemoveAt((int)listbxTagsOfLetter.SelectedIndex); // Удаляем выбранный тэг в списке
            listbxTagsOfLetter.ItemsSource = null;                            // Очищаем контрол отображения тэгов письма
            listbxTagsOfLetter.ItemsSource = tagsOfLetterList;                // Перепривязываем контрол с списку
        }

        /// <summary>
        /// Метод добавления тэга к списку тэгов письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (combobxTags.SelectedValue != null)
            {
                // Если в комбобоксе общего списка тэгов не был сделан выбор, ничего не делаем
                // Если выбор был сделан, проводим добавление
                tagsOfLetterList.Add(new TagsOfLetter() // Создаем новую запись в списке тэгов письма: данные берем из комбобокса
                {
                    IDLetterLink = (operation == LetterOperation.adding) ? 0 : inputLetters.IDLetter, // Указываем идентификатор письма (новое письмо - 0)
                    IDTagLink = (int)combobxTags.SelectedValue,                                       // Указываем идентификатор тэга из таблицы тэгов
                    TagName = combobxTags.Text                                                        // Указываем название тэга
                });
                listbxTagsOfLetter.ItemsSource = null;                                                // Очищаем контрол списка тэгов письма
                listbxTagsOfLetter.ItemsSource = tagsOfLetterList;                                    // Перепривязываем контрол к обновленному списку
            }
        }

        /// <summary>
        /// Метод заврешения добавления или редактирования письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddEditLetter_Click(object sender, RoutedEventArgs e)
        {
            switch(operation) // Используем значение перечислителя для определения типа операции
            {
                case LetterOperation.adding: // В случае добавления нового письма
                    if(CheckValidity()) // Осуществляем проверку на заполненность основных данных письма
                    {
                        // Вызываем метод добавления письма (на сервере) и передаем в него параметры
                        // Возвращаемые значения: Индекс позиции письма в списке писем, Идентификатор нового письма
                        (int index, int idNewLetter) = DocsVisionStage.AddLetter((int)combobxDepartments.SelectedValue,
                                                                                 tbLetterName.Text,
                                                                                 (DateTime)dpLetterDateTime.SelectedDate,
                                                                                 tbLetterTopic.Text,
                                                                                 tbLetterFrom.Text,
                                                                                 tbLetterTo.Text,
                                                                                 tbLetterContent.Text,
                                                                                 tbLetterComment.Text,
                                                                                 (bool)cbxIsIncoming.IsChecked,
                                                                                 selectCondition);
                        FinalOperation(index, idNewLetter); // Выполняем финальную операцию: передаем в нее индекс письма и идентификатор письма
                    }
                    break;
                case LetterOperation.modifying:
                    if (CheckValidity()) // Осуществляем проверку на заполненность основных данных письма
                    {
                        // Вызываем метод добавления письма (на сервере) и передаем в него параметры
                        // Возвращаемое значение: Индекс позиции письма в списке писем
                        int index = DocsVisionStage.EditLetter(inputLetters.IDLetter,
                                                               (int)combobxDepartments.SelectedValue,
                                                               tbLetterName.Text,
                                                               (DateTime)dpLetterDateTime.SelectedDate,
                                                               tbLetterTopic.Text,
                                                               tbLetterFrom.Text,
                                                               tbLetterTo.Text,
                                                               tbLetterContent.Text,
                                                               tbLetterComment.Text,
                                                               (bool)cbxIsIncoming.IsChecked,
                                                               selectCondition);
                        FinalOperation(index, inputLetters.IDLetter); // Выполняем финальную операцию: передаем в нее индекс письма и идентификатор письма
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод проверки параметров письма на заполненность
        /// Основными обязательными параметрами письма являются:
        /// Отдел организации, к которому отнесено письмо;
        /// Дата получения или отправки письма
        /// </summary>
        /// <returns> Флаг валидности параметров письма:
        /// Все параметры валидны - значение true
        /// Есть хотя бы один невалидный параметр - значение false
        /// </returns>
        private bool CheckValidity()
        {
            bool letterChecked = true; // Устанавливаем флаг - в случае, если все заполнено правильно, флаг не меняем
            if (combobxDepartments.SelectedValue == null)
            {
                MessageBox.Show("Не выбран соответствующий отдел!\n\nНеобходимо выбрать отдел, к которому относится письмо!", "Не заполнены требуемые параметры!", MessageBoxButton.OK, MessageBoxImage.Information);
                letterChecked = false;
            }
            else if (dpLetterDateTime.SelectedDate == null)
            {
                MessageBox.Show("Не задана дата письма!\n\nНеобходимо задать дату, когда письмо было получено!", "Не заполнены требуемые параметры!", MessageBoxButton.OK, MessageBoxImage.Information);
                letterChecked = false;
            }
            return letterChecked; // Возвращаем флаг
        }

        /// <summary>
        /// Метод финальной операции добавления или редактирования письма
        /// </summary>
        /// <param name="index"> Индекс письма в списке писем </param>
        /// <param name="idNewRecord"> Идентификатор редактируемого или добавленного письма </param>
        public void FinalOperation(int index, int idNewRecord)
        {
            if (index < 0) // Если из внешнего метода (с сервера) вернулось значение меньше нуля, то произошла ошибка, запись не добавлена
            {
                switch (index)
                {
                    case -1:
                        MessageBox.Show("Произошла ошибка выборки после добавления письма! Зовите санитаров!", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case -2:
                        MessageBox.Show("Нарушено условие уникальности задаваемого названия письма!\nПисьмо не добавлено!\n\nОткорректируйте название!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        MessageBox.Show($"Что-то не так - новая запись не добавлена! Нужен доктор! Код ошибки: {index}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            else
            {
                // В случае, если с сервера пришел индекс, а не отрицательный код ошибки, то на данный момент письмо добавлено или отредактировано
                // Вызываем метод обновления списка тэгов добавленного или отредактированного письма
                // И проверяем код ошибки (возвращаемый параметр)
                int code = DocsVisionStage.UpdateTagsOfLetter(tagsOfLetterList, idNewRecord);
                if (code < 0)
                {
                    // Во время выборки списка тэгов письма произошла ошибка, сообщаем о ней пользователю
                    MessageBox.Show($"Не удалось получить список тэгов письма! Код ошибки: {code}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close(); // Закрываем окно
                }
                else
                {
                    // В случае, если выборка тэгов письма прошла успешно, вызываем метод отображения списка писем основного окна работы с письмами
                    // Передаем туда два параметра: Индекс позиционируемой записи и условие поиска (для выполнения обновленного запроса поиска писем, соответствующих условию)
                    ShowLetters(index, selectCondition);
                    this.Close(); // Закрываем окно
                }
            }
        }

        /// <summary>
        /// Метод отображения параметров редактируемого письма
        /// </summary>
        /// <param name="inputLetters"> Экземпляр класса писем - редактируемое письмо </param>
        private void ShowEditableFields(Letters inputLetters)
        {
            tbLetterName.Text = inputLetters.LetterName;                        // Название письма
            tbLetterTopic.Text = inputLetters.LetterTopic;                      // Тема письма
            tbLetterFrom.Text = inputLetters.LetterFrom;                        // Отправитель
            tbLetterTo.Text = inputLetters.LetterTo;                            // Адресат
            tbLetterComment.Text = inputLetters.LetterComment;                  // Комментарий к письму
            cbxIsIncoming.IsChecked = inputLetters.IsLetterIncoming;            // Флаг - входящее или исходящее письмо
            dpLetterDateTime.SelectedDate = inputLetters.LetterDateTime;        // Дата получения или отправки письма
            tbLetterContent.Text = inputLetters.LetterContent;                  // Содержание письма
            combobxDepartments.SelectedValue = inputLetters.IDDepartmentLetter; // Идентификатор отдела, к которому относится письмо
        }
    }
}