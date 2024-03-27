using Delivery.Core.Context;
using Delivery.Repository;
using System.Windows;


namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly UsersRepository usersRepository;
        public Login()
        {
            InitializeComponent();
            usersRepository = new UsersRepository(new DeliveryContextDB());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
             Registration reg = new Registration();

            reg.Show();

            this.Close();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxName.Text.Trim();
            string pass = passBoxPass.Password;

            Users user = await usersRepository.GetUserByLoginAsync(login);

            if (user != null && user.Password == pass)
            {
                RestouranMap ResMap = new RestouranMap(user);
                ResMap.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль!");
            }
        }

    }
}

