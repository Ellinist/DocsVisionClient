using DocsVisionClient.DocsVisionService;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DocsVisionClient.DocsVisionWindows
{
    /// <summary>
    /// Логика взаимодействия для TagsWindows.xaml
    /// </summary>
    public partial class TagsWindows : Window
    {
        #region Блок определений
        List<DocsVisionClasses.Tags> tagsList = new List<DocsVisionClasses.Tags>();
        private DocsVisionServiceClient DocsVisionStage = new DocsVisionServiceClient(); // Подключаемся к WCF-сервису "BasicHttpBinding_IDocsVisionService"
        #endregion

        /// <summary>
        /// Конструктор окна работы с тэгами
        /// </summary>
        public TagsWindows()
        {
            InitializeComponent();
            Loaded += TagsWindows_Loaded; // Подписываемся на событие загрузки окна
        }

        /// <summary>
        /// Обработчик события загрузки окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TagsWindows_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем кортеж с параметрами: список тэгов, код ошибки
            (List<DocsVisionService.Tags> inputTagsList, int errorCode) = DocsVisionStage.GetTags();
            if(errorCode < 0)
            {
                // Если код ошибки отрицательный - запрос неудачен! Выводим код ошибки
                MessageBox.Show($"При получении списка тэгов возникла ошибка: {errorCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // В случае успешности выборки
                GetTags(inputTagsList);   // Конвертируем список тэгов и отображаем в контроле списка тэгов
                lbxTags.SelectedItem = 0; // Позиционируемся на первую запись
                lbxTags.Focus();          // Устанавливаем фокус на записи позиционирования
                #region Подписываемся на события
                btnAddTag.Click += BtnAddTag_Click;
                btnDeleteTag.Click += BtnDeleteTag_Click;
                btnRenameTag.Click += BtnRenameTag_Click;
                #endregion
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку редактирования тэга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRenameTag_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на непустую строку названия тэга
            // В идеале необходимо добавить проверки на коды управления и иную логику
            if(tbNewTag.Text == "")
            {
                // Строка названия тэга не определена
                MessageBox.Show("Необходимо задать имя тэга!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Вызываем метод изменения названия тэга - передаем два параметра: идентификатор корректируемого тэга, новое название тэга
                DocsVisionStage.RenameTag((int)lbxTags.SelectedValue, tbNewTag.Text);
                RefreshTags(); // Вызываем метод обновления списка тэгов
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку удаления тэга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            // Запрос пользователю о необходимости удаления тэга
            if(MessageBox.Show("Выбранный тэг будет удален! Продолжить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Если пользователь настаивает, вызываем метод удаления выбранного тэга, передаем один параметр: идентификатор выбранного тэга
                DocsVisionStage.DeleteTag((int)lbxTags.SelectedValue);
                RefreshTags(); // Вызываем метод обновления списка тэгов
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку добавления тэга
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddTag_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на непустую строку названия тэга
            // В идеале необходимо добавить проверки на коды управления и иную логику
            if (tbNewTag.Text == "")
            {
                // Строка названия тэга не определена
                MessageBox.Show("Необходимо задать имя тэга!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Вызываем метод добавления тэга - передаем параметр: название тэга (идентификатор тэга будет задан сервером инкрементно)
                DocsVisionStage.AddTag(tbNewTag.Text);
                RefreshTags(); // Вызываем метод обновления списка тэгов
            }
        }

        /// <summary>
        /// Метод обновления отображаемого списка тэгов
        /// </summary>
        private void RefreshTags()
        {
            tagsList.Clear(); // Очищаемы список
            // Получаем список тэгов с сервера
            // Результат - кортеж: первый параметр - список тэгов, второй параметр - код ошибки
            (List<DocsVisionService.Tags> inputTagsList, int errorCode) = DocsVisionStage.GetTags();
            if(errorCode < 0)
            {
                // Если выборка неуспешна, выводим сообщение с кодом ошибки
                MessageBox.Show($"При получении списка тэгов возникла ошибка: {errorCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // В случае успешности выборки
                GetTags(inputTagsList);   // Конвертируем список тэгов и отображаем в контроле списка тэгов
                lbxTags.SelectedItem = 0; // Позиционируемся на первую запись
                lbxTags.Focus();          // Устанавливаем фокус на записи позиционирования
            }
        }

        /// <summary>
        /// Метод конвертирования списка тэгов (из одного в другое пространство имен)
        /// </summary>
        /// <param name="inputTags"></param>
        private void GetTags(List<DocsVisionService.Tags> inputTags)
        {
            // Созщдаем в пространстве имен клиента список тэгов 
            List<DocsVisionClasses.Tags> resultTags = new List<DocsVisionClasses.Tags>();
            // Пробегаем по циклу списка тэгов, полученного с сервера
            for (int i = 0; i < inputTags.Count; i++)
            {
                // Копируем параметры
                DocsVisionClasses.Tags tag = new DocsVisionClasses.Tags
                {
                    IDTag = inputTags[i].IDTag,
                    TagName = inputTags[i].TagName
                };
                resultTags.Add(tag);
            }
            tagsList = resultTags;            // Обновляем переменную класса окна
            lbxTags.ItemsSource = resultTags; // Устанавливаем у контрола списка тэгов источник записей
        }
    }
}