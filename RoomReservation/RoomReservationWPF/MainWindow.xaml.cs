using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;
using RoomReservation.Models;
using RoomReservationWPF.Common;
using RoomReservationWPF.Models;
using System.Collections.ObjectModel;
//using Xceed.Wpf.Toolkit;

namespace RoomReservationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RoomManager rm;
        public static int EventDuration = 0;
        public static MultimediaType MMDType = (MultimediaType)0;
        public MainWindow()
        {
            InitializeComponent();
            //TestClass.TestXMLSerialization();
            //rm = new RoomManager(@"C:\Users\DerKaiser\Desktop\project GUi\RoomReservation\RoomReservationWPF\RoomData.csv");
            rm = new RoomManager(@"../../RoomData.csv");
            BeginDate.SelectedDate = DateTime.Now;
            Request req = new Request(new DateTime(2016, 7, 23, 10, 0, 0), 30);
            List<Room> l = rm.GetListOfRecommendedRooms(req);
            if (l.Count > 0)
            {
                rm.BookRoom(l[0].RoomID, req.Occupation);
            }
            l = rm.GetListOfRecommendedRooms(req);
            rm.CancelReservation(1, req.Occupation.BeginTime);
            l = rm.GetListOfRecommendedRooms(req);




            GridView gridView = new GridView();

            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("RoomID"),
                    Header = " Id ",
                    Width = double.NaN
                });
            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("RoomTypeProp"),
                    Header = " Type ",
                    Width = double.NaN
                });
            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("CalculatedPrice"),
                    Header = " rent Price",
                    Width = double.NaN
                });
            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("Capacity"),
                    Header = " Capacity ",
                    Width = 150 //double.NaN
                });
            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("CalculatedMedia"),
                    Header = " Media ",
                    Width = double.NaN
                });
            gridView.Columns.Add(
                new GridViewColumn
                {
                    DisplayMemberBinding = new System.Windows.Data.Binding("Score"),
                    Header = " Score ",
                    Width = double.NaN
                });

            listView1.View = gridView;
            listView1.ItemsSource = rm.ListOfRooms;


            // Room r1 = new Room();
            // Trace.WriteLine("-----");


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
        private void CleadListViev()
        {
            if (listView1 != null)
            {
                listView1.ItemsSource = null;
                //listView1.Items.Clear();
            }
        }
        private void Duration_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EventDuration = int.Parse(((ComboBoxItem)Duration.SelectedItem).Tag.ToString());
            CleadListViev();
        }
        private void TypeBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CleadListViev();
        }
        private void PriceRangeBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CleadListViev();
        }
        private void CapacityRangeBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CleadListViev();
        }
        private void MultimediaBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MMDType = ClassGeneral.GetEnumByName<MultimediaType>(((ComboBoxItem)MultimediaBox.SelectedItem).Tag.ToString());
            CleadListViev();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem cbi = (ComboBoxItem)TimeRangeBox.SelectedItem;

            //TextBlock1.Text = cbi.ToString() + ";" + TimeRangeBox.Text;
            DateTime beginDate = (DateTime)BeginDate.SelectedDate;
            string beginTime = ((ComboBoxItem)BeginTime.SelectedItem).Tag.ToString();
            string duration = ((ComboBoxItem)Duration.SelectedItem).Tag.ToString();
            string typeBox = ((ComboBoxItem)TypeBox.SelectedItem).Tag.ToString();
            string priceRangeBox = ((ComboBoxItem)PriceRangeBox.SelectedItem).Tag.ToString();
            string capacityRangeBox = ((ComboBoxItem)CapacityRangeBox.SelectedItem).Tag.ToString();
            string multimediaBox = ((ComboBoxItem)MultimediaBox.SelectedItem).Tag.ToString();
            //Validate ????
            int roomTypePriority = int.Parse(((ComboBoxItem)typePriority.SelectedItem).Tag.ToString());
            int rentPriceRangePriority = int.Parse(((ComboBoxItem)pricePriority.SelectedItem).Tag.ToString());
            int capacityRangePriority = int.Parse(((ComboBoxItem)capacityPriority.SelectedItem).Tag.ToString());
            int multimediaTypePriority = int.Parse(((ComboBoxItem)multimediaPriority.SelectedItem).Tag.ToString());

            DateTime beginDateTime = new DateTime(beginDate.Year, beginDate.Month, beginDate.Day, int.Parse(beginTime.Split(':')[0]), int.Parse(beginTime.Split(':')[1]), 0);

            Request req = new Request(beginDateTime, int.Parse(duration),
               ClassGeneral.GetEnumByName<RoomType>(typeBox),
               ClassGeneral.GetEnumByName<RentPriceRangeType>(priceRangeBox),
               ClassGeneral.GetEnumByName<CapacityRangeType>(capacityRangeBox),
               ClassGeneral.GetEnumByName<MultimediaType>(multimediaBox),
               roomTypePriority, rentPriceRangePriority, capacityRangePriority, multimediaTypePriority
               );
            List<Room> recommendedRooms = rm.GetListOfRecommendedRooms(req);

            recommendedRooms = recommendedRooms.OrderBy(r => -r.ScoreCompatible(req)).ToList();
            listView1.ItemsSource = recommendedRooms;

            //System.Windows.Forms.MessageBox.Show(String.Format("Selected: {0}", value)); 
            //TestClass.WriteToBinaryFile<Room>(l[0], "../../Test.bin");
            //Room ll = TestClass.ReadFromBinaryFile<Room>( "../../Test.bin");
            //Employee employee = new Employee("Name1", "Title1", null,"Team1");
            //TestClass.WriteToBinaryFile<Employee>(employee, "../../Test.bin");
            //Employee employee1 = TestClass.ReadFromBinaryFile<Employee>("../../Test.bin");


        }
        private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show(String.Format("Selected: {0}", e.AddedItems[0]));
            //Debug.WriteLine("Selected: {0}", e.AddedItems[0]);
        }
        private void createRoom_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
