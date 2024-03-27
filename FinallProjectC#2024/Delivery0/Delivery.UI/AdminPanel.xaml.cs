using Delivery.Core.Context;
using Delivery.Repository;
using System.Windows;
using System.Windows.Controls;

namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private readonly DishRepository _dishRepository;
        private readonly RestaurantsRepository _restaurantsRepository;
        private readonly MenuRepository _menuRepository;

        public AdminPanel()
        {
            InitializeComponent();
            _dishRepository = new DishRepository(new DeliveryContextDB());
            _restaurantsRepository = new RestaurantsRepository(new DeliveryContextDB());
            _menuRepository = new MenuRepository(new DeliveryContextDB());
            FillDishesListBoxAsync();
            FillRestaurantsListBoxAsync();
        }

        private async Task FillDishesListBoxAsync()
        {
            try
            {
                var dishes = await _dishRepository.GetAllDishesAsync();
                dishListBox.Items.Clear();
                foreach (var dish in dishes)
                {
                    dishListBox.Items.Add(dish);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження страв: {ex.Message}");
            }
        }

        private async Task FillRestaurantsListBoxAsync()
        {
            try
            {
                var restaurants = await _restaurantsRepository.GetAllRestaurantsAsync();
                RestourantListBox.Items.Clear();
                foreach (var restaurant in restaurants)
                {
                    RestourantListBox.Items.Add(restaurant);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження ресторану: {ex.Message}");
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RestourantListBox.SelectedItem == null || dishListBox.SelectedItem == null)
                {
                    MessageBox.Show("Будь ласка, оберіть ресторан та страву.");
                    return;
                }

                var selectedRestaurant = (Restaurants)RestourantListBox.SelectedItem;
                var selectedDish = (Dish)dishListBox.SelectedItem;

                var existingMenuItem = await _menuRepository.GetMenuByRestaurantAndDishAsync(selectedRestaurant.Id, selectedDish.Id);
                if (existingMenuItem != null)
                {
                    MessageBox.Show("Цей пункт меню вже існує.");
                    return;
                }
       
                Delivery.Core.Context.Menu newMenuItem = new Delivery.Core.Context.Menu
                {
                    RestaurantId = selectedRestaurant.Id,
                    DishId = selectedDish.Id
                };

                await _menuRepository.AddMenuAsync(newMenuItem);
                MessageBox.Show("Пункт меню додано успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка додавання пункту меню:{ex.Message}");
            }
        }

  

        private void AddAllButton_Click(object sender, RoutedEventArgs e)
        {
            AdminSettingsPanel admset = new AdminSettingsPanel();

            admset.Show();

            this.Close();
        }

        private void EixtButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ReLogButton_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();

            log.Show();

            this.Close();
        }
    }
}
