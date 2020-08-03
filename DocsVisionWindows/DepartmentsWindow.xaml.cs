using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DocsVisionClient.DocsVisionService;

namespace DocsVisionClient.DocsVisionWindows
{
    /// <summary>
    /// Логика взаимодействия для DepartmentsWindow.xaml
    /// </summary>
    public partial class DepartmentsWindow : Window
    {
        #region Блок определений
        public List<Departments> departmentsList; // Объявляем список отделов
        /// <summary>
        /// Определяем перечислитель для ветвления при выборе операции (флаг операций)
        /// </summary>
        private enum DepartmentOperation : int { adding = 1, modifying = 2 } // Расширяемый перечислитель (при необходимости или изменении логики работы окна)
        private DepartmentOperation operation; // Инициализируем перечислитель
        // Определяем сервис работы с контрактами сервера
        private DocsVisionServiceClient DocsVisionStage = new DocsVisionServiceClient();
        #endregion

        /// <summary>
        /// Конструктор окна работы с отделами
        /// </summary>
        public DepartmentsWindow()
        {
            InitializeComponent();
            // Вытягиваем со стороны сервера кортеж со списком отделов и кодом выполнения операции
            (List<Departments> selectDepartments, int selectErrCode) = DocsVisionStage.GetAllDepartments();
            if (selectErrCode == 1) // Проверка на успешность операции (через элемент кортежа по контракту)
            {
                // Все успешно - продолжаем работу
                departmentsList = selectDepartments;
                #region Установка начальных параметров элементов окна
                tbDepartmentName.IsEnabled = false;                        // Устанавливаем недоступность поля "Название отдела"
                tbDepartmentComment.IsEnabled = false;                     // Устанавливаем недоступность поля "Комментарий к отделу"
                cbxDepartmentMain.IsEnabled = false;                       // Устанавливаем недоступность поля "Головной отдел"
                btnDenyOperation.Visibility = Visibility.Collapsed;        // Скрываем кнопку осуществления операций
                btnDepartmentOperation.Visibility = Visibility.Collapsed;  // Скрываем кнопку отмены действий
                dgDepartments.IsHitTestVisible = true;                     // Разрешаем кликать по DataGrid  
                #endregion
                #region Подключение обработчиков событий (подписываемся на события)
                Loaded += DepartmentsWindow_Loaded;                           // Обработчик события отображения окна
                btnDepartmentEdit.Click += BtnDepartmentEdit_Click;           // Обработчик события нажатия на кнопку "Редактировать отдел"
                btnDepartmentOperation.Click += BtnDepartmentOperation_Click; // Обработчик события нажатия на кнопку "Применить изменения"
                btnDenyOperation.Click += BtnDenyOperation_Click;             // Обработчик события нажатия на кнопку "Отмена"
                btnDepartmentNew.Click += BtnDepartmentNew_Click;             // Обработчик события нажатия на кнопку "Создать новый отдел"
                btnDepartmentDelete.Click += BtnDepartmentDelete_Click;       // Обработчик события нажатия на кнопку "Удалить отдел"
                #endregion
            }
            else
            {
                MessageBox.Show($"Не удалось получить список отделов организации! Код ошибки: {selectErrCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //TODO Подумать, что делать в случае неудачи с первичной выборкой записей списка отделов
            }
        }

        /// <summary>
        /// Метод обработки события загрузки окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgDepartments.ItemsSource = departmentsList;                      // Связываем DataGrid со списком отделов организации
            dgDepartments.SelectionChanged += DgDepartments_SelectionChanged; // Подписываемся на событие изменения выбора в DataGrid
            dgDepartments.SelectedIndex = 0;                                  // Позиционируем выбор в DataGrid на первой записи
            dgDepartments.Focus();                                            // Устанавливаем фокус на строке позиционирования
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку добавления нового отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDepartmentNew_Click(object sender, RoutedEventArgs e)
        {
            dgDepartments.SelectionChanged -= DgDepartments_SelectionChanged;                    // Отписываемся от события изменения выбора в DataGrid
            ChangeStatusControls();                                                              // Меняем статус элементов управления окна
            operation = DepartmentOperation.adding;                                              // Устанавливаем флаг добавления новой записи в таблице отделов
            btnDepartmentOperation.Content = "Занести новый отдел";                              // Задаем название для кнопки
            tbDepartmentComment.Text = "В это поле введите комментарий по создаваемому отделу!"; // Задаем подсказки - поле комментария по отделу
            tbDepartmentName.Text = "Введите название отдела!";                                  // Задаем подсказки - поле названия отдела
            cbxDepartmentMain.IsChecked = false;                                                 // По умолчанию новый отдел - не главный (!!!)
            tbDepartmentName.Focus();                                                            // Устанавливаем фокус на поле названия отдела
        }

        /// <summary>
        /// Метод обработчика нажатия на кнопку операций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDepartmentOperation_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                #region Блок добавления нового отдела
                case DepartmentOperation.adding: // В случае добавления записи в таблицу отделов
                    int oldInsertIndex = dgDepartments.SelectedIndex; // Сохраняем текущий индекс позиции
                    // Вызываем метод добавления новой записи в таблицу отделов
                    // Передаем только три параметра из четырех, так как поле id_Department является автоинкрементным
                    // Возвращаемый параметр - индекс позиционирования добавленной записи в списке отделов
                    int index = DocsVisionStage.AddNewDepartment(tbDepartmentName.Text, tbDepartmentComment.Text, (bool)cbxDepartmentMain.IsChecked);
                    if (index < 0) // Если из внешнего метода вернулось значение меньше нуля, то произошла ошибка, то запись не добавлена
                    {
                        switch (index)
                        {
                            case -1:
                                MessageBox.Show("Произошла ошибка выборки после добавления отдела! Зовите санитаров!", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            case -2:
                                MessageBox.Show("Нарушено условие уникальности задаваемого названия отдела! Отдел не добавлен!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            default:
                                MessageBox.Show($"Что-то не так - новая запись не добавлена! Нужен доктор! Код ошибки: {index}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                        dgDepartments.SelectedIndex = oldInsertIndex; // Устанавливаем сохраненный индекс позиции - до попытки добавления отдела
                    }
                    else
                    {
                        // Вызываем метод получения обновленного списка отделов - возврат: кортеж (список отделов, код ошибки)
                        (List<Departments> selectDepartments, int selectErrCode) = DocsVisionStage.GetAllDepartments();
                        if(selectErrCode == 1)
                        {
                            departmentsList.Clear();                     // Очищаем существующий список отделов
                            departmentsList = selectDepartments;         // Ссылаемся на новый список отделов в кортеже
                            dgDepartments.ItemsSource = departmentsList; // Связываем DataGrid со списком отделов организации
                            dgDepartments.SelectedIndex = index;         // Позиционируем выбор в DataGrid на добавленной записи
                        }
                        else
                        {
                            MessageBox.Show($"Произошла ошибка выборки списка отделов после добавления записи! Код ошибки: {selectErrCode}", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            dgDepartments.SelectedIndex = oldInsertIndex;
                        }
                    }
                    ChangeStatusControls();                                           // Меняем статус элементов управления
                    dgDepartments.SelectionChanged += DgDepartments_SelectionChanged; // Снова подписываемся на событие изменения выбора в DataGrid
                    dgDepartments.Focus();                                            // Устанавливаем фокус на строке позиционирования
                    break;
                #endregion
                #region Блок редактирования отдела
                case DepartmentOperation.modifying: // В случае редактирования записи в таблице отделов
                    int oldUpdateIndex = dgDepartments.SelectedIndex; // Сохраняем текущий индекс позиции
                    // Вызываем метод редактирования выбранной записи в таблице отделов
                    // Передаем только четыре параметра, включая идентификатор редактируемого отдела
                    // Возвращаемый параметр - индекс позиционирования отредактированной записи в списке отделов
                    index = DocsVisionStage.UpdateDepartment(departmentsList[dgDepartments.SelectedIndex].IDDepartment, tbDepartmentName.Text, tbDepartmentComment.Text, (bool)cbxDepartmentMain.IsChecked);
                    if (index < 0) // Если из внешнего метода вернулось значение меньше нуля, то произошла ошибка, то запись не обновлена
                    {
                        switch (index)
                        {
                            case -1:
                                MessageBox.Show("Произошла ошибка выборки после обновления отдела! Зовите санитаров!", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            case -2:
                                MessageBox.Show("Нарушено условие уникальности задаваемого названия отдела! Отдел не добавлен!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            default:
                                MessageBox.Show($"Что-то не так - новая запись не обновлена! Нужен доктор! Код ошибки: {index}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                        dgDepartments.SelectedIndex = oldUpdateIndex; // Устанавливаем сохраненный индекс позиции - до попытки редактирования отдела
                    }
                    else
                    {
                        (List<Departments> selectDepartments, int selectErrCode) = DocsVisionStage.GetAllDepartments();
                        if(selectErrCode == 1)
                        {
                            departmentsList.Clear();                     // Очищаем существующий список отделов
                            departmentsList = selectDepartments;         // Ссылаемся на новый список отделов в кортеже
                            dgDepartments.ItemsSource = departmentsList; // Связываем DataGrid со списком отделов организации
                            dgDepartments.SelectedIndex = index;         // Позиционируем выбор в DataGrid на обновленной записи
                        }
                        else
                        {
                            MessageBox.Show("Произошла ошибка выборки списка отделов после обновления записи!", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            dgDepartments.SelectedIndex = oldUpdateIndex;
                        }
                    }
                    ChangeStatusControls();                                           // Меняем статус элементов управления
                    dgDepartments.SelectionChanged += DgDepartments_SelectionChanged; // Снова подписываемся на событие изменения выбора в DataGrid
                    dgDepartments.Focus();                                            // Устанавливаем фокус на строке позиционирования
                    break;
                    #endregion
            }
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку "Отмена" - производится возвращение в исходное состояние
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDenyOperation_Click(object sender, RoutedEventArgs e)
        {
            dgDepartments.SelectionChanged += DgDepartments_SelectionChanged; // Снова подписываемся на события изменения выбора в DataGrid
            ChangeStatusControls();                                           // Меняем статус элементов управления
            DgDepartments_SelectionChanged(null, null);                       // Отображаем исходные характеристики выбранного отдела
            dgDepartments.Focus();
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку удаления выбранного отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDepartmentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Выбранный отдел ''{departmentsList[dgDepartments.SelectedIndex].DepartmentName}''\n" +
                                 "будет удален!\n\n Продолжить?", "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                int indexPosition = dgDepartments.SelectedIndex;                    // Получаем индекс выбранной (удаляемой) строки (и временно сохраняем)
                dgDepartments.SelectionChanged -= DgDepartments_SelectionChanged;   // Отписываемся от события изменения выбора в DataGrid
                // Вызываем метод удаления записи - передаем в метод идентификатор удаляемого отдела
                int errorCode = DocsVisionStage.DeleteDepartment(departmentsList[dgDepartments.SelectedIndex].IDDepartment);
                if (errorCode == 1) // Проверка на успешность операции
                {
                    // Удаление прошло успешно
                    // Получаем обновленный список отделов
                    (List<Departments> selectDepartments, int selectErrCode) = DocsVisionStage.GetAllDepartments();
                    if (selectErrCode == 1)
                    {
                        departmentsList.Clear();                     // Очищаем список отделов
                        departmentsList = selectDepartments;         // Ссылаемся на новый список отделов в кортеже
                        dgDepartments.ItemsSource = departmentsList; // Связываем DataGrid со списком отделов организации
                        // Позиционируемся в DataGrid после удаления
                        dgDepartments.SelectedIndex = (indexPosition == 0) ? 0 : indexPosition - 1;
                    }
                    else
                    {
                        MessageBox.Show($"Произошла ошибка выборки списка отделов после удаления записи! Код ошибки: {selectErrCode}", "Критическая ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        dgDepartments.SelectedIndex = indexPosition;
                    }
                }
                else if (errorCode == -2)
                {
                    MessageBox.Show("Операция не выполнена! Не допускается удалять головной отдел!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Если сервер вернул иное значение - неизвестная ошибка
                    MessageBox.Show($"Во время операции удаления отдела возникла ошибка! Требуется хирургическое вмешательство! Код ошибки: {errorCode}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            dgDepartments.Focus();                                            // Устанавливаем фокус на строке позиционирования
            dgDepartments.SelectionChanged += DgDepartments_SelectionChanged; // Снова подписываемся на события изменения выбора в DataGrid
        }

        /// <summary>
        /// Метод обработки нажатия на кнопку редактирования выбранного отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDepartmentEdit_Click(object sender, RoutedEventArgs e)
        {
            dgDepartments.SelectionChanged -= DgDepartments_SelectionChanged; // Отписываемся от события изменения выбора в DataGrid
            btnDepartmentOperation.Content = "Сохранить изменения";           // Отображаем надпись сохранения изменений на кнопке операций
            operation = DepartmentOperation.modifying;                        // Устанавливаем флаг операции в значение редактирования
            ChangeStatusControls();                                           // Меняем статус элементов управления
            tbDepartmentName.Focus();
        }

        /// <summary>
        /// Метод обработки события выбора записи в DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Отображаем параметры выбранного отдела
            tbDepartmentName.Text = departmentsList[dgDepartments.SelectedIndex].DepartmentName;
            tbDepartmentComment.Text = departmentsList[dgDepartments.SelectedIndex].DepartmentComment;
            cbxDepartmentMain.IsChecked = departmentsList[dgDepartments.SelectedIndex].MainDepartmentFlag;
        }

        /// <summary>
        /// Метод инвертирования состояния элементов управления
        /// </summary>
        private void ChangeStatusControls()
        {
            tbDepartmentName.IsEnabled = !tbDepartmentName.IsEnabled;
            tbDepartmentComment.IsEnabled = !tbDepartmentComment.IsEnabled;
            cbxDepartmentMain.IsEnabled = !cbxDepartmentMain.IsEnabled;
            btnDepartmentOperation.Visibility = (btnDepartmentOperation.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            btnDenyOperation.Visibility = (btnDenyOperation.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            btnDepartmentNew.Visibility = (btnDepartmentNew.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            btnDepartmentEdit.Visibility = (btnDepartmentEdit.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            btnDepartmentDelete.Visibility = (btnDepartmentDelete.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            dgDepartments.IsHitTestVisible = !dgDepartments.IsHitTestVisible;
        }
    }
}