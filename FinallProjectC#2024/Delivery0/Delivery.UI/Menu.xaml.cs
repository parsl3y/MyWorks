using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Delivery.Core.Context;
using Delivery.Core.Entity;
using Delivery.Core.Repository;
using Delivery.Repository;
using Microsoft.EntityFrameworkCore;

namespace Delivery.UI
{
    public partial class Menu : Window
    {
        private readonly DeliveryContextDB _context;
        private readonly MenuRepository _menuRepository;
        private readonly UsersRepository _usersRepository;
        private readonly OrderItemRepository _orderItemRepository;

            public Menu(int restaurantId, Users currentUser)
        {
            InitializeComponent();
            _menuRepository = new MenuRepository(new DeliveryContextDB());
            MenuDataGrid.IsReadOnly = true;
            _orderItemRepository = new OrderItemRepository(new DeliveryContextDB());
            _usersRepository = new UsersRepository(new DeliveryContextDB());
            _context = new DeliveryContextDB();
            DisplayOrders();
        }

        public async Task LoadData(int restaurantId)
        {
            var restaurant = await _menuRepository.GetRestaurantByIdAsync(restaurantId);
            if (restaurant != null)
            {
                RestName.Content = restaurant.Name;
                LogoRest.Source = new BitmapImage(new Uri(restaurant.Image_Logo));

                var menuItems = await _menuRepository.GetMenusByRestaurantIdAsync(restaurantId);

                List<MenuItemWithPhoto> menuItemsWithPhoto = new List<MenuItemWithPhoto>();
                foreach (var item in menuItems)
                {
                    menuItemsWithPhoto.Add(new MenuItemWithPhoto(item.Dish.Name, item.Dish.Price, item.Dish.Image_food));
                }

                MenuDataGrid.ItemsSource = menuItemsWithPhoto;
                double? averageRating = await _context.Reviews
                    .Where(r => r.RestaurantsId == restaurantId)
                    .AverageAsync(r => (double?)r.Rating);

                if (averageRating.HasValue)
                {
                    Rating.Content = $"Рейтинг: {averageRating:F2}";
                }
                else
                {
                    Rating.Content = "Немає відгуків.";
                }

                await DisplayReviews(restaurantId);
            }
            else
            {
                MessageBox.Show("Ресторан не знайдено.");
            }
        }
        private async Task DisplayReviews(int restaurantId)
        {
            try
            {
                var reviews = await _context.Reviews
                                        .Where(r => r.RestaurantsId == restaurantId)
                                        .ToListAsync();

                foreach (var review in reviews)
                {
                    ReviewTextListBox.Items.Add(review.TextReviews);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying reviews: {ex.Message}");
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {

            string phoneNumber = PhoneInformationTextBox.Text;
            string address = AdressTextBox.Text;
            string PhoneNumber = PhoneInformationTextBox.Text;
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                int? userId = await _usersRepository.GetUserIdByPhoneNumberAsync(phoneNumber);

                if (userId.HasValue)
                {
                    MenuItemWithPhoto selectedItem = (MenuItemWithPhoto)MenuDataGrid.SelectedItem;
                    Orders selectedOrder = (Orders)OrdersListBox.SelectedItem;
                    if (selectedItem != null && selectedOrder != null)
                    {
                        string itemName = selectedItem.Name;
                        double itemPrice = selectedItem.Price;
                        int orderId = selectedOrder.Id; 
                        DateTime currentDate = DateTime.Now;

                        try
                        {
                            OrderItem orderItem = new OrderItem
                            {
                                UserId = userId.Value,
                                OrdersId = orderId,
                                NameDish = itemName,
                                OrderDate = currentDate,
                                DishPrice = (int)itemPrice,
                                Address = address
                            };

                            await _orderItemRepository.AddAsync(orderItem);

                            MessageBox.Show("Номер замовлення додано успішно.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при додаванні елемента замовлення: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Будь ласка, оберіть пункт меню та номер замовлення.");
                    }
                }
                else
                {
                    MessageBox.Show("Користувача з таким номером телефону не знайдено.");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть номер телефону.");
            }
        }

       
        private void SearchTxtBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTxtBox.Text.ToLower(); 

            foreach (var item in MenuDataGrid.Items)
            {
                if (item is MenuItemWithPhoto menuItem) 
                {
                    var row = (DataGridRow)MenuDataGrid.ItemContainerGenerator.ContainerFromItem(item); 

                    if (string.IsNullOrEmpty(searchText) || menuItem.Name.ToLower().Contains(searchText)) 
                    {
                        if (row != null)
                            row.Visibility = Visibility.Visible; 
                    }
                    else
                    {
                        if (row != null)
                            row.Visibility = Visibility.Collapsed; 
                    }
                }
            }
        }

        private async Task DisplayOrders()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();

                OrdersListBox.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відображенні замовлень: {ex.Message}");
            }
        }

        private async void CreateOrderButton_Click_1(object sender, RoutedEventArgs e)
        {
            Orders newOrder = new Orders
            {
                StatusId = 1
            };

            try
            {
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                MessageBox.Show("Замовлення створено успішно!");

                OrdersListBox.ItemsSource = _context.Orders.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Помилка при створенні замовлення: {ex.Message}");
            }
        }


        private void PanelOrderButton_Click(object sender, RoutedEventArgs e)
        {
             OrdersTable orT = new OrdersTable();
            orT.Show();
            this.Close();
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            ReviewsPanel rp = new ReviewsPanel();

            rp.Show();

            this.Close();
        }

        private void ReviewTextListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewTextListBox.SelectedItem != null)
            {
                string selectedReview = ReviewTextListBox.SelectedItem.ToString();

                MessageBox.Show(selectedReview);
            }
        }

    }

    public class MenuItemWithPhoto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }

        public MenuItemWithPhoto() { }

        public MenuItemWithPhoto(string name, double price, string photoPath)
        {
            Name = name;
            Price = price;
            PhotoPath = photoPath;
        }
    }

}
