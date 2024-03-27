using System.Windows;

namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for AdminSettingsPanel.xaml
    /// </summary>
    public partial class AdminSettingsPanel : Window
    {
        public AdminSettingsPanel()
        {
            InitializeComponent();
        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CRUD_PANEL_ADMIN create = new CRUD_PANEL_ADMIN();

            create.Show();

            this.Close();
        }

    

        private void UpDateButton_Click(object sender, RoutedEventArgs e)
        {
            CRUD_Update_Admin upd = new CRUD_Update_Admin();

            upd.Show();

            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            CRUD_DEL_PANEL delete = new CRUD_DEL_PANEL();

            delete.Show();

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel admin = new AdminPanel();

            admin.Show();
            this.Close();
        }
    }
}
