using System.Windows;
using System.Windows.Controls;
using Delivery.Core.Context;
using Delivery.Repository;

namespace Delivery.UI
{
    public partial class CRUD_DEL_PANEL : Window
    {
        private readonly MenuRepository _menuRepository;

        public CRUD_DEL_PANEL()
        {
            InitializeComponent();
            _menuRepository = new MenuRepository(new DeliveryContextDB()); 
            LoadMenus();
        }

        private async void LoadMenus()
        {
            try
            {
                var menus = await _menuRepository.GetMenusAsync(); 
                MenuListBox.ItemsSource = menus;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилки завантаження меню: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Delivery.Core.Context.Menu selectedMenu = (Delivery.Core.Context.Menu)MenuListBox.SelectedItem;

                if (selectedMenu != null)
                {
                    await _menuRepository.DeleteMenuAsync(selectedMenu);

                    var menus = (List<Delivery.Core.Context.Menu>)MenuListBox.ItemsSource;
                    menus.Remove(selectedMenu);
                    MenuListBox.ItemsSource = null;
                    MenuListBox.ItemsSource = menus; 

                    MessageBox.Show("Пункт меню успішно видалено.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть пункт меню для видалення.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting menu item: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

            AdminSettingsPanel admset = new AdminSettingsPanel();

            admset.Show();

            this.Close();
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
