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

        private void bookTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void registerTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void createRoomTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void createBuildingTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void createEventTab_Click(object sender, RoutedEventArgs e)
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
