﻿using RoomReservation.Models;
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

namespace RoomReservationWPF
{
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
