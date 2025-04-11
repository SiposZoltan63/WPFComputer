using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            ListComputers();
        }
        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Password=;SslMode=None";
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=computer;Uid=root;Password=;SslMode=None");
        private void ListComputers()
        {
            try
            {

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    string sql = $"SELECT * FROM `comp`";
                    connection.Open();
                    using (var da = new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DataGrid1.ItemsSource = dt.DefaultView;
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
                    string sql = $"SELECT * FROM `osystem`";
                    connection.Open();
                    using (var da = new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DataGrid1.ItemsSource = dt.DefaultView;
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
        //04.11
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            var Brand = txtBrand.Text;
            var Type = txtType.Text;
            var Display = txtDisplay.Text;
            var Memory = txtMemory.Text;
            var OsId = txtOsId.Text;
            var sql = $"INSERT INTO `comp`(`Brand`, `Type`, `Display`, `Memory`,`OsId`) VALUES ('{txtBrand.Text}','{txtType.Text}','{txtDisplay.Text}','{txtMemory.Text}','{txtOsId.Text}')";
            var beszuras = new MySqlCommand(sql, connection).ExecuteNonQuery();
            connection.Close();
            if (beszuras == 1)
            {
                DataGrid1.Items.Clear();
                ListComputers();
            }
            txtBrand.Text = "";
            txtType.Text = "";
            txtDisplay.Text = "";
            txtMemory.Text = "";
            txtOsId.Text = "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            var Name = txtName.Text;
            var sql = $"INSERT INTO `osystem`(`Name`) VALUES ('{txtName.Text}')";
            var beszuras = new MySqlCommand(sql, connection).ExecuteNonQuery();
            connection.Close();
            if (beszuras == 1)
            {
                DataGrid1.Items.Clear();
                ListComputers();
            }
            txtName.Text = "";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            var Brand = txtBrand.Text;
            var Type = txtType.Text;
            var Display = txtDisplay.Text;
            var Memory = txtMemory.Text;
            var OsId = txtOsId.Text;
            var sql = $"DELETE FROM `comp` WHERE `Id` = ";
            var beszuras = new MySqlCommand(sql, connection).ExecuteNonQuery();
            connection.Close();
            if (beszuras == 1)
            {
                DataGrid1.Items.Clear();
                ListComputers();
            }
            txtBrand.Text = "";
            txtType.Text = "";
            txtDisplay.Text = "";
            txtMemory.Text = "";
            txtOsId.Text = "";
        }
    }
    
}