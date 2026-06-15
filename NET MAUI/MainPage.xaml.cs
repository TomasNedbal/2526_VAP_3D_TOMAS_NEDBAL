namespace MauiCalculator
{
    using System.ComponentModel;
    using System.Data;
    public partial class MainPage : ContentPage
    {
        public string Expression
        {
            get { return _expression; }
            set
            {
                _expression = value;
                OnPropertyChanged();
            }
        }

        string _expression = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            App.Current.UserAppTheme = AppTheme.Dark;
            if (sender is Button button)
            {
                string value = button.Text;
                Expression += value;
            }
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                string result = new DataTable().Compute(Expression, null).ToString();
                Expression = result;
            } catch (Exception ex)
            {
                Expression = "Error";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            Expression = string.Empty;
        }
    }

}
