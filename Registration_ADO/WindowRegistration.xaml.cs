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
using System.Windows.Shapes;
using System.Configuration;
using System.Text.RegularExpressions; // регулярные выражения
using System.Data.SqlClient;



namespace Registration_ADO
{
    /// <summary>
    /// Interaction logic for WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {

        public SqlConnection con;

        public WindowRegistration()
        {
            InitializeComponent();

        }
        // кнопка Свободен в онке регистрации
        private void FreeName(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Логин пуст");
                return;
            }


            /* \d - digit
             * \s - space
             * ]S - non space
             * \w - word symbol
             * \W - non-word symbol
             * \D - non didgit
             */
            Regex r1 = new Regex(@"\W"); // не ворд символ \w   
            if (r1.IsMatch(UserName.Text))
            {
                MessageBox.Show("Логин содержит недопустимый символ вариант один");
                return;
            }

            Regex r2 = new Regex(@"[^a-z]", RegexOptions.IgnoreCase); // не ворд символ \w   
            if (r2.IsMatch(UserName.Text))
            {
                MessageBox.Show("Логин содержит недопустимый символ вариант второй");
                return;
            }

            if (con == null)
            {
                string conStr = ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString; // извлечение строки подключения из app.config
                con = new SqlConnection(conStr);
                try
                {
                    con.Open();
                    //MessageBox.Show("DB is connect");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            string sql = String.Format("SELECT COUNT(*) FROM Users WHERE Login=N'{0}'", UserName.Text);
            var cmd = new SqlCommand(sql, con);
            int n = -1;
            try
            {
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sql Exeption:\n" + ex.Message + "\n" + cmd.CommandText);
                return;
                //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Convert Error:\n" + ex.Message);
                return;
            }
            if (n == 0) MessageBox.Show("Логин свободен");
            if (n > 0) MessageBox.Show("Логин занят");

        }

        /*------------------------------------------------------------------------------------------------------*/

        // кнопка Регистрация в окне регистрации
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text.Equals(String.Empty))
            {
               MessageBox.Show("Необходимо ввести имя");
                return; // прервать дальнейшую работу
            }
            if (Password.Equals(String.Empty))
            {
                MessageBox.Show("Необходимо ввести пароль");
                return; // прервать дальнейшую работу
            }
            if (!Password.Equals(Password))
            {
                MessageBox.Show("Пароли совпадают");
            }
            if (CheckRights.IsChecked==false)
            {
                MessageBox.Show("Вы не прочитали что-то");
                return;
            }
            // Валидация данных------------------------------------------------
            var login_regex = new Regex(@"\W");
            if (login_regex.IsMatch(UserName.Text))
            {
                MessageBox.Show("Логин содержит недопустимые символы");
                return;

            }
            // проверка почты на недпустимые символы-----------------------------------------
            var email_regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!email_regex.IsMatch(Email.Text))
            {
                MessageBox.Show("Электронный адрес не корректен");
                return;
            }
            // проверка телефона 
            var phone_regex = new Regex(@"\D");
            if(phone_regex.IsMatch(Phone.Text))
            {
                MessageBox.Show("Телефонный номер не корректен");
            }

            // Логин свободен-------------------------------------------------------------------
            if (con==null)
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
            //  проверка свободен ли логин  запрос в базу 
            var cmd = new SqlCommand("SELECT COUNT(ID) FROM Users WHERE Login=N'"+UserName.Text+"'",con);
            int n = -1;
            try
            {
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Execution", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            if (n>0)
            {
                MessageBox.Show("Логин занят");
                return;
            }
            // запрос на заполнение таблицы пользователей
            int G_ID = 3;
            if (RadioMale.IsChecked==true)
            {
                G_ID = 2;
            }
            if (RadioFemale.IsChecked==true)
            {
                G_ID = 1;
            }
            if (RadioNoneMale.IsChecked == true)
            {
                G_ID = 3;
            }

            cmd.CommandText = String.Format(
                "Insert into Users(Login,  RealName,  PassHash,  Email,   Phone, RegisterDT, ID_Gender) " +
                "VALUES(          N'{0}',  N'{1}',     '{2}',  N'{3}'  , N'{4}', current_timestamp,    {5}   )  ",
                UserName.Text, RealName.Text, Crypto.GetSHA_256(Password.Password), Email.Text, Phone.Text, G_ID);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Регистрация прошла успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\n"+ cmd.CommandText);
                return;
            }




        }
        // кнопка Отмена в окне регистрации
        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
