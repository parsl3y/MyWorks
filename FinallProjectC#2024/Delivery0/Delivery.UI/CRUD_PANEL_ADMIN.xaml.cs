using Delivery.Core.Context;
using Delivery.Repository;
using Microsoft.Win32;
using System.Windows;

namespace Delivery.UI
{
    public partial class CRUD_PANEL_ADMIN : Window
    {
        private readonly DishRepository _dishRepository;

        public CRUD_PANEL_ADMIN()
        {
            InitializeComponent();
            _dishRepository = new DishRepository(new DeliveryContextDB());
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Фотографії (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                photoTextBox.Text = filePath;
            }
        }

        private void AdminMenuClick_Click(object sender, RoutedEventArgs e)
        {
            AdminSettingsPanel admset = new AdminSettingsPanel();
            admset.Show();
            this.Close();
        }

        private async void CreateDish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTxtBox.Text;
                int price = Convert.ToInt32(PriceTxtBox.Text); 
                string photoUrl = photoTextBox.Text;
                Dish newDish = new Dish { Name = name, Price = price, Image_food = photoUrl };
                await _dishRepository.AddDishAsync(newDish);

                MessageBox.Show("Страву успішно додано!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть коректну ціну.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні страви: {ex.Message}");
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }

    }

}

