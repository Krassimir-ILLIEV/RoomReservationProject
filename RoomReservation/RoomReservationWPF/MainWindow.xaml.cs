namespace RoomReservationWPF
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;

    using RoomReservation.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Room r1 = new Room();
            Trace.WriteLine("-----");
        }

        private void BookTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RegisterTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateRoomTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateBuildingTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateEventTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
