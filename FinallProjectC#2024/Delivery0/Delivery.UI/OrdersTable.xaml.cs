using Delivery.Core.Context;
using Delivery.Core.Entity;
using Delivery.Core.Repository;
using Delivery.Repository;
using Microsoft.Win32;
using System.Text;
using System.Windows;

namespace Delivery.UI
{
    public partial class OrdersTable : Window
    {
        private readonly OrderItemRepository _orderItemRepository;
        private readonly UsersRepository _usersRepository;
        private readonly OrderRepository _orderRepository;

        public OrdersTable()
        {
            InitializeComponent();

            _orderItemRepository = new OrderItemRepository(new DeliveryContextDB());
            _usersRepository = new UsersRepository(new DeliveryContextDB());
            _orderRepository = new OrderRepository(new DeliveryContextDB());

            LoadData();
        }

       private async void LoadData()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            var filteredOrders = orders.Where(order => order.StatusId != 3).ToList();
            DeliverList.ItemsSource = filteredOrders;

            var orderItems = await _orderItemRepository.GetAllAsync();
            var filteredOrderItems = orderItems.Where(item => item.Orders.status.Id != 3).ToList();

            orderItemDataGrid.ItemsSource = filteredOrderItems;
        }



        private async void ChekButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = UserPhoneTxtBox.Text;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                int? userId = await _usersRepository.GetUserIdByPhoneNumberAsync(phoneNumber);

                if (userId.HasValue)
                {
                    var userOrders = await _orderItemRepository.GetUserOrdersAsync(userId.Value);

                    if (userOrders.Any())
                    {
                        string csvContent = GenerateCsvFromOrders(userOrders);
                        SaveCsvToFile(csvContent);
                    }
                    else
                    {
                        MessageBox.Show($"Користувач із номером телефону {phoneNumber} не має замовлень.");
                    }
                }
                else
                {
                    MessageBox.Show($"Користувач із номером телефону {phoneNumber} не знайдений.");
                }
            }
            else
            {
                MessageBox.Show("Введіть номер телефону.");
            }
        }

        private string GenerateCsvFromOrders(IEnumerable<OrderItem> orders)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("NameDish,OrderDate,DishPrice,Address,TotalPrice");

            foreach (var order in orders)
            {
                if(order.Orders.status.Id != 3) { 
                int totalPrice = orders.Sum(o => o.DishPrice);
                csvContent.AppendLine($"{order.NameDish},{order.OrderDate},{order.DishPrice},{order.Address},{totalPrice}");
                    }
            }

            return csvContent.ToString();
        }

        private void SaveCsvToFile(string csvContent)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                System.IO.File.WriteAllText(filePath, csvContent);
                MessageBox.Show("Файл успішно збережений.");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = UserPhoneTxtBox.Text;

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                int? userId = await _usersRepository.GetUserIdByPhoneNumberAsync(phoneNumber);

                if (userId.HasValue)
                {
                    var userOrders = await _orderItemRepository.GetUserOrdersAsync(userId.Value);
                    var filteredUserOrders = userOrders.Where(order => order.Orders.status.Id != 3).ToList();

                    orderItemDataGrid.ItemsSource = filteredUserOrders;

                    if (!filteredUserOrders.Any())
                    {
                        MessageBox.Show($"Користувач із номером телефону {phoneNumber} не має замовлень.");
                    }
                }
                else
                {
                    MessageBox.Show($"Користувач із номером телефону {phoneNumber} не знайдений.");
                }
            }
            else
            {
                MessageBox.Show("Введіть номер телефону.");
            }
        }


        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {

            Orders selectedOrder = DeliverList.SelectedItem as Orders;

            if (selectedOrder != null)
            {

                if (selectedOrder.StatusId == 2)
                {
                    MessageBox.Show("Замовлення вже в дорозі.");
                    return;
                }

                selectedOrder.StatusId = 2;

                try
                {

                    await _orderRepository.UpdateOrderAsync(selectedOrder);


                    MessageBox.Show($"Статус замовлення змінено на 2.(В процесі)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при оновленні статусу замовлення: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть замовлення зі списку.");
            }
        }

        private async void FinishOrderBTN_Click(object sender, RoutedEventArgs e)
        {
            Orders selectedOrder = DeliverList.SelectedItem as Orders;

            if (selectedOrder != null)
            {
                if (selectedOrder.StatusId == 2)
                {
                    selectedOrder.StatusId = 3;

                    try
                    {
                        await _orderRepository.UpdateOrderAsync(selectedOrder);

                        MessageBox.Show($"Статус замовлення змінено на 3 (доставлено).");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при оновленні статусу замовлення: {ex.Message}");
                    }
                }
                else if (selectedOrder.StatusId == 1)
                {
                    MessageBox.Show("Замовлення не взято.");
                }
                else if (selectedOrder.StatusId == 3)
                {
                    MessageBox.Show("Замовлення вже доставлено.");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть замовлення зі списку.");
            }
        }

        private async void Deliver_Click(object sender, RoutedEventArgs e)
        {
          
            string phoneNumber = UserPhoneTxtBox.Text;

            int? roleId = await _usersRepository.GetRoleIdByPhoneNumberAsync(phoneNumber);

            if (roleId.HasValue)
            {

                CheckUserRole(roleId.Value);
            }
            else
            {
                MessageBox.Show("Недостатньо повноважень", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckUserRole(int roleId)
        {
            if (roleId == 3)
            {
                DeliverList.Visibility = Visibility.Visible;
                ChangeStatusButton.Visibility = Visibility.Visible;
                FinishOrderBTN.Visibility = Visibility.Visible;
            }
            else
            {
                DeliverList.Visibility = Visibility.Collapsed;
                ChangeStatusButton.Visibility = Visibility.Collapsed;
                FinishOrderBTN.Visibility = Visibility.Collapsed;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
