using Delivery.Core.Context;
using Delivery.Repository;
using System.Windows;

namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for RestouranMap.xaml
    /// </summary>
    public partial class RestouranMap : Window
    {
        private Users _currentUser;
        public RestouranMap(Users currentUser) 
        {
            InitializeComponent();
            _currentUser = currentUser; 

            CheckUserRole(); 
        }

        private async void CheckUserRole()
        {
            if (_currentUser != null && _currentUser.RoleId == 1)
            {
             
                adminBtn.Visibility = Visibility.Visible;
            }
            else
            {
             
                adminBtn.Visibility = Visibility.Collapsed;
            }
        }

        private async void Rest2Button_Click(object sender, RoutedEventArgs e)
        {
            int restaurantId = 3; 

            using (var context = new DeliveryContextDB())
            {
                Menu rest3 = new Menu(restaurantId, _currentUser); 
                rest3.Show();

                await rest3.LoadData(restaurantId);
            }

            this.Close();
        }

        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            admin.Show();
            this.Close();
        }

        private async void Rest1Button_Click(object sender, RoutedEventArgs e)
        {
            int restaurantId = 1;
            using (var context = new DeliveryContextDB())
            {
                Menu rest1 = new Menu(restaurantId, _currentUser); 
                rest1.Show();

                await rest1.LoadData(restaurantId);
            }

            this.Close();
        }


        private async void Rest3Button_Click(object sender, RoutedEventArgs e)
        {
            int restaurantId = 2;

            using (var context = new DeliveryContextDB())
            {
                UsersRepository userRepository = new UsersRepository(context);
                int? userId = await userRepository.GetUserIdByPhoneNumberAsync(_currentUser.Phone);

                if (userId.HasValue)
                {
                    Menu rest2 = new Menu(restaurantId, _currentUser); 
                    rest2.Show();
                    await rest2.LoadData(restaurantId);
                }
                else
                {
                   
                }
            }

            this.Close();
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RelogBtn_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();

            log.Show();

            this.Close();
        }

 
    }
}
