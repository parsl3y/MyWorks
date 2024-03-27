using Delivery.Core.Context;
using Delivery.Repository;
using System.Windows;
using System.Windows.Controls;


namespace Delivery.UI
{
    /// <summary>
    /// Interaction logic for ReviewsPanel.xaml
    /// </summary>
    public partial class ReviewsPanel : Window
    {
        private readonly ReviewsRepository _reviewsRepository;
        private readonly UsersRepository _usersRepository;
        private readonly RestaurantsRepository _restaurantsRepository;
        private int restaurantId;
        public ReviewsPanel()
        {
            InitializeComponent();
            _reviewsRepository = new ReviewsRepository(new DeliveryContextDB());
            _usersRepository = new UsersRepository(new DeliveryContextDB());
            _restaurantsRepository = new RestaurantsRepository(new DeliveryContextDB());

            FillComboBoxWithRestaurants();
        }

        private async void FillComboBoxWithRestaurants()
        {
            try
            {
                var allRestaurants = await _restaurantsRepository.GetAllRestaurantsAsync();
                RestoranNameCmbBox.ItemsSource = allRestaurants;
                RestoranNameCmbBox.DisplayMemberPath = "Name"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedRestaurant = e.AddedItems[0] as Restaurants;

                if (selectedRestaurant != null)
                {
                    restaurantId = selectedRestaurant.Id;
                    string restaurantName = selectedRestaurant.Name;
                }
            }
        }
        private async void AddReview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string phoneNumber = PhoneInfoTextBox.Text;
                int? userId = await _usersRepository.GetUserIdByPhoneNumberAsync(phoneNumber);

                if (userId.HasValue)
                {
                    bool hasUserReviewed = await _reviewsRepository.HasUserReviewedAsync(userId.Value, restaurantId);
                    if (hasUserReviewed)
                    {
                        MessageBox.Show("Ви вже залишали відгук для цього ресторану.");
                        return;
                    }
                    var selectedRestaurant = RestoranNameCmbBox.SelectedItem as Restaurants;

                    if (selectedRestaurant != null)
                    {
                        int restaurantId = selectedRestaurant.Id;
                        string restaurantName = selectedRestaurant.Name;
                        string reviewText = TextReviewTextBox.Text;
                        int rating = 0;
                        if (!string.IsNullOrEmpty(RatingTextBox.Text) && int.TryParse(RatingTextBox.Text, out rating))
                        {
                            if (rating < 1 || rating > 5)
                            {
                                MessageBox.Show("Рейтинг повинен бути числом від 1 до 5.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Будь ласка, введіть коректний рейтинг.");
                            return;
                        }
                        var review = new Reviews
                        {
                            UserId = userId.Value,
                            RestaurantsId = restaurantId,
                            TextReviews = reviewText,
                            Rating = rating
                        };

                        await _reviewsRepository.AddReviewAsync(review);

                        MessageBox.Show("Відгук додано успішно!");
                    }
                    else
                    {
                        MessageBox.Show("Будь ласка, виберіть ресторан!");
                    }
                }
                else
                {
                    MessageBox.Show("Користувача не знайдено за цим номером телефону");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }


        private void RatingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RatingTextBox.Text))
            {
                if (!int.TryParse(RatingTextBox.Text, out int rating) || rating < 1 || rating > 5)
                {
                    MessageBox.Show("Рейтинг повинен бути числом від 1 до 5.");
                    RatingTextBox.Text = string.Empty;
                }
            }
        }

        private void ReLogBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                Login log = new Login();

                log.Show();

                this.Close();
            }
        }
    }
}
