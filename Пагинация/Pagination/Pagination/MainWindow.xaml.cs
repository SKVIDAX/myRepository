using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pagination
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Подключение через модель ADO.NET (Добавить - Новый элемент - ADO.NET)
        private Koroleva_1_dbEntities _context = Koroleva_1_dbEntities.GetContext();
        private int _currentPage = 1; //Номер страницы
        private int _pageSize = 5; //Количество записей на одной странице
        private int _totalPages;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void GoNextPage(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            LoadData();
        }

        private void GoPrevPage(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            LoadData();
        }

        private void LoadData()
        {
            /* DataGridUsers.ItemsSource = _context.PAGINATION_USERS.Skip((_currentPage - 1) * _pageSize)
                        .Take(_pageSize)
                        .ToList();*/

            // Получаем общее количество элементов
            int totalItems = _context.PAGINATION_USERS.Count();

            // Вычисляем общее количество страниц
            _totalPages = (int)Math.Ceiling((double)totalItems / _pageSize);

            // Ограничиваем текущую страницу
            _currentPage = Math.Max(1, Math.Min(_currentPage, _totalPages));

            // Загружаем данные для текущей страницы
            var users = _context.PAGINATION_USERS.OrderBy(user => user.id)
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            DataGridUsers.ItemsSource = users;
            NumberPage.Text = _currentPage.ToString();

            // Обновляем состояние кнопок
            UpdateButtonStates();
        }


        private void UpdateButtonStates()
        {
            // Кнопка "Назад" отключена, если текущая страница - первая
            GoPrevPageButton.IsEnabled = _currentPage > 1;

            // Кнопка "Вперед" отключена, если текущая страница - последняя
            GoNextPageButton.IsEnabled = _currentPage < _totalPages;
        }
    }
}
