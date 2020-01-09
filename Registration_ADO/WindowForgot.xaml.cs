using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Registration_ADO
{
    /// <summary>
    /// Interaction logic for WindowForgot.xaml
    /// </summary>
    public partial class WindowForgot : Window
    {
        public SqlConnection con;

        public WindowForgot()
        {
            InitializeComponent();
        }

        private void Escape_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SendCode_Click(object sender, RoutedEventArgs e)
        {
            // проверка на пустоту--------
            if (YourEmail.Text=="")
            {
                MessageBox.Show("Введите почтовый адрес");
                return;
            }
            if (YourEmail.Text.Length==25)
            {

            }
            //валидация данных------
            var email_regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!email_regex.IsMatch(YourEmail.Text))
            {
                MessageBox.Show("Электронный адрес не корректен");
            }

            // получаем id  по email---------------

            if (con == null)
            {
                string conStr = ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString; // извлечение строки подключения из app.config
                con = new SqlConnection(conStr);

                try
                {

                    con.Open();
                    MessageBox.Show("DB is connect");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }

            //--------------------
            var cmd = new SqlCommand($"SELECT ID FROM Users WHERE Email LIKE N'{YourEmail.Text}'",con);
            int n = -1;
            object res = null;
            try
            {
                res = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Execution", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (res==null || res.Equals(DBNull.Value))
            {
                MessageBox.Show("Invalid Email");
                return;
            }

            try
            {
                n = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // проверка на пустоту

            if (PassTextBox.Password=="")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            int recoveryCode = (new Random()).Next(1000, 10000);

            string newPassHash = Crypto.GetSHA_256(PassTextBox.Password);

            cmd.CommandText = $"UPDATE Users SET RecoveryCode={recoveryCode},PassHash = '{newPassHash}' WHERE ID = { n }";

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Вам отправлен код {recoveryCode}");
            VerifyCode.IsEnabled = true;
            Restore.IsEnabled = true;


        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            // пустота

            if (VerifyCode.Text=="")
            {
                MessageBox.Show("Введите код потверждения");
                return;
            }

            // валидация 

            var verify_regex = new Regex(@"^\d{4}$");
            if (!verify_regex.IsMatch(VerifyCode.Text))
            {
                MessageBox.Show("Электронный адрес не корректен");
            }



            if (con == null)
            {
                string conStr = ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString; // извлечение строки подключения из app.config
                con = new SqlConnection(conStr);

                try
                {

                    con.Open();
                    MessageBox.Show("DB is connect");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }

            //
            var cmd = new SqlCommand($"SELECT ID FROM Users WHERE RecoveryCode = {VerifyCode.Text}", con);
            int n = -1;
            object res = null;
            try
            {
                res = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Execution", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (res == null || res.Equals(DBNull.Value))
            {
                MessageBox.Show("Invalid Code");
                return;
            }

            try
            {
                n = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ "\n"+cmd.CommandText + "Error Connection");
                return;
            }

            cmd.CommandText = $"UPDATE Users SET RecoveryCode=0  WHERE ID = { n }";

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Ваш пароль изменен");
        }
    }
}
