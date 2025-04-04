using MySql.Data.MySqlClient;
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
        //04.04
        private bool Beleptet(string username, string password)
        {

            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = $"SELECT `Id` FROM `user` WHERE UserName = @username AND Password = @password";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    bool van = dr.Read();

                    if (van)
                    {
                        UserId.Id = dr.GetInt32(0);
                    }

                    connection.Close();


                    return van;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Beleptet(textbox1.Text, textbox2.Text) == true)

                {
                    MessageBox.Show("Regisztrált tag");
                    Window2 windows2  = new Window2();
                    windows2.ShowDialog();
                }
                else
                {
                    Window1 windows1 = new Window1();
                    windows1.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
    public static class UserId
    {

        public static int Id { get; set; }
    }
}