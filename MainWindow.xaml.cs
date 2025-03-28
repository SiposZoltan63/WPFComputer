﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace feladat0321
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";

        private void ListComputers()
        {
            try
            {

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = $"SELECT * FROM comp";
                    using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                        da.Fill(dt);
                        DataGrid1.DataContext = dt;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListOs()
        {
            try
            {

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = $"SELECT * FROM osystem";
                    using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                        da.Fill(dt);
                        DataGrid1.DataContext = dt;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Computer_Click(object sender, RoutedEventArgs e)
        {
            ListComputers();
        }

        private void Ops_Click(object sender, RoutedEventArgs e)
        {
            ListOs();
        }
    }
}