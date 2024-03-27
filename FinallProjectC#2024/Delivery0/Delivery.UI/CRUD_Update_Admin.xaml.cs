
using System.Windows;
using System.Windows.Controls;
using Delivery.Core.Context;
using Delivery.Repository;

namespace Delivery.UI
{
    public partial class CRUD_Update_Admin : Window
    {
        private DishRepository _dishRepository;

        public CRUD_Update_Admin()
        {
            InitializeComponent();
            _dishRepository = new DishRepository(new DeliveryContextDB()); 
            LoadDishes(); 
        }

        private async void LoadDishes()
        {
            var dishes = await _dishRepository.GetAllDishesAsync();
            DataGridInformation.ItemsSource = dishes;
        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var updatedDishes = (IEnumerable<Dish>)DataGridInformation.ItemsSource;

            foreach (var updatedDish in updatedDishes)
            {
                await _dishRepository.UpdateDishAsync(updatedDish);
            }

            MessageBox.Show("Дані оновлено успішно!");
        }




        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminSettingsPanel admset = new AdminSettingsPanel();
            admset.Show();
            this.Close();
        }
    }
}
