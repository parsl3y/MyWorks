using System.Windows;
using System.Windows.Media;
using Delivery.Repository;
using Delivery.Core.Context;
namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private UsersRepository usersRepository;
        public Registration()
        {
            InitializeComponent();
            usersRepository = new UsersRepository(new DeliveryContextDB());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            Login login = new Login();
            
            login.Show();

            this.Close();
        }
        private void passboxInsert_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pass = passboxInsert.Password;
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            
            foreach (char c in pass)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            string status;

            if (hasUppercase && hasLowercase && hasDigit)
            {
                status = "strong";
                labelstatus.Style = (Style)FindResource("StrongStatusStyle");
            }
            else if (hasLowercase && hasDigit) 
            {
                status = "medium";
                labelstatus.Style = (Style)FindResource("MediumStatusStyle");
            }
            else
            {
                status = "weak";
                labelstatus.Style = (Style)FindResource("WeakStatusStyle");
            }

            labelstatus.Content = status;
        }

        private async void BtnRegestation_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text.Trim();
            string pass = passboxInsert.Password;
            string passCheck = passboxCheck.Password;
            string email = txtBoxEmail.Text.Trim().ToLower();
            string phone = txtBoxPhone.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                txtBoxLogin.ToolTip = "Введіть логін 5 або більше символів";
                txtBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passboxInsert.ToolTip = "Введіть пароль 5 або більше символів";
                passboxInsert.Background = Brushes.DarkRed;
            }
            else if (!pass.Any(char.IsDigit) || !pass.Any(char.IsLetter))
            {
                passboxInsert.ToolTip = "Пароль повинен містити як мінімум одну цифру та одну букву";
                passboxInsert.Background = Brushes.DarkRed;
            }
            else if (pass != passCheck)
            {
                passboxCheck.ToolTip = "Паролі не співпадають!";
                passboxCheck.Background = Brushes.DarkRed;
            }
            else if (!(email.Contains("@") && email.Contains(".")))
            {
                txtBoxEmail.ToolTip = "Введіть коректну пошту, використовуючи символи '@' та '.'!";
                txtBoxEmail.Background = Brushes.DarkRed;
            }
            else if (!(phone.Length == 10 && phone.All(char.IsDigit)))
            {
                txtBoxPhone.ToolTip = "Введіть коректний номер телефону";
                txtBoxPhone.Background = Brushes.DarkRed;
            }
            else
            {
                passboxInsert.ToolTip = "";
                passboxInsert.Background = Brushes.White;
                passboxCheck.ToolTip = "";
                passboxCheck.Background = Brushes.White;
                txtBoxEmail.ToolTip = "";
                txtBoxEmail.Background = Brushes.White;
                txtBoxLogin.ToolTip = "";
                txtBoxLogin.Background = Brushes.White;
                txtBoxPhone.ToolTip = "";
                txtBoxPhone.Background = Brushes.White;

              
                Users newUser = new Users
                {
                    Name = login,
                    Password = pass,
                    Email = email,
                    Phone = phone
                };

                await usersRepository.AddUserAsync(newUser);

                MessageBox.Show("Аккаунт додано до бази!");
            }
        }

    }
}