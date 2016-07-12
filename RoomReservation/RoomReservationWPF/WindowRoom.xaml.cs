using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RoomReservationWPF.Models;
using RoomReservationWPF.Common;

namespace RoomReservationWPF
{
    /// <summary>
    /// Interaction logic for WindowRoom.xaml
    /// </summary>
    public partial class WindowRoom : Window
    {
        private Room room;
        private bool[] isBooked;
        public WindowRoom()
        {
            InitializeComponent();
        }
        public WindowRoom(Room room, bool[] isBooked)
            : this()
        {
            this.room = room;
            this.isBooked = isBooked;
            lblCapacity.Content = room.Capacity.ToString();
            lblFloor.Content = room.Floor.ToString();
            lblType.Content = ClassGeneral.GetNameByEnum<RoomType>(room.RoomTypeProp);
            lblPrice.Content = room.RentPricePerHour.ToString();
            string s = "None";
            if (room.ListMultimedia != null)
            {
                s = string.Join(",",room.ListMultimedia.Select(
                    m => ClassGeneral.GetNameByEnum<MultimediaType>(m.MType)
                    ).ToArray());
            }
            lblMultimedia.Content = s;
            if (!string.IsNullOrEmpty(room.PicturePath))
            {
                var uri = new Uri(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\..\..\Pictures\" + room.PicturePath);
                var bitmap = new BitmapImage(uri);
                img.Source = bitmap;
            }
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            isBooked[0] = false;
            this.Close();
        }
        private void ButtonBook_Click(object sender, RoutedEventArgs e)
        {
            isBooked[0] = true;
            this.Close();
        }
    }
}
