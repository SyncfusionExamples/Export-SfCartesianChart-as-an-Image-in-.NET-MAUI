namespace CartesianChartSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_JPEG(object sender, EventArgs e)
        {
            chart.SaveAsImage("CartesianChart1.jpeg");
        }

        private void Button_Clicked_PNG(object sender, EventArgs e)
        {
            chart.SaveAsImage("CartesianChart2.png");
        }
    }

}
