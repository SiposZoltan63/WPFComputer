using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Connect conn = new Connect();
        public static int userId = 0;
        private bool beleptet(string FirstName, string LastName, string pass)
        {
            try
            {
                conn.Connection.Open();

                string sql = $"SELECT `Id` FROM `data` WHERE `FirstName` = '{FirstName}' and `LastName` = '{LastName}' AND `Password` = '{pass}'";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                MySqlDataReader dr = cmd.ExecuteReader();

                bool van = dr.Read();

                conn.Connection.Close();
                return van;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void update(string Brand, string LastName, string Password)
        {
            try
            {
                conn.Connection.Open();

                string sql = $"UPDATE 'data' SET `Brand`= '{Brand}',`LastName`='{LastName}',`Password`='{Password}' WHERE `Id`= '{id}' ;";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                var result = cmd.ExecuteNonQuery();

                conn.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
