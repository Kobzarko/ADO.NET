using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace Registration_ADO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // строка подключения
        public SqlConnection con;

        public MainWindow()
        {
            InitializeComponent();
            //  , извлечение строки подключения из app.config
            string conStr = ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
            con = new SqlConnection(conStr);

            try
            {
                con.Open();
                // вот тут хорошо создать кнопку подключения
                MessageBox.Show("DB is connecting", "connection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                con.Close();
                return;
            }

            //Console.WriteLine("CONNECTION OK База данных создана");
        }



        // пароли в базу кладем только в преобразованном виде




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // миграционные скрипты
            string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'USERS'";
            var cmd = new SqlCommand(sql, con);
            int n = -1;
            try
            {
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (n == 0)
            {
                // команда для создания таблицы
                cmd.CommandText = @"CREATE TABLE Users(ID INT PRIMARY KEY NOT NULL IDENTITY,
                Login NVARCHAR(50) NOT NULL, 
                RealName NVARCHAR(128) NOT NULL,
                PassHash CHAR(64) ,
                ID Gender INT ,
                Email NVARCHAR(128),
                RegisterDT DATETIME DEFAULT CURRENT_TIMESTAMP,
                )";
            }

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Table Users is created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connection", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }



        #region Buttons
        // кнопка Выход
        private void Esc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("До скорой встречи", "Bye-Bye", MessageBoxButton.OK);

            this.Close(); // закрытие окна

        }


        // кнопка Регистрация
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistration windowRegistration = new WindowRegistration();
            //указываемна нашу строку подключения
            windowRegistration.con = this.con;
            windowRegistration.ShowDialog();

        }
        // кнопка Вход
        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            // заново подключаемся к базе данных
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
            // запрос на существующего пользователя 
            string sql = @"SELECT ID,
                            Login,
                            RealName,  
                            PassHash,  
                            Email,   
                            Phone, 
                            RegisterDT, 
                            ID_Gender 
                            FROM Users WHERE Login=N'" + UserName.Text + "' AND PassHash='" + Crypto.GetSHA_256(Password.Password) + "'";
            var cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = null;
            try
            {
                rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + cmd.CommandText, "Error rdr");
                return;
            }
            // возвращает значение  строк
            if (rdr.HasRows)
            {
                var hello = new WindowHello();
                rdr.Read();
                hello.user = new User()
                {
                    Id = rdr.GetInt32(0),
                    Login = rdr.GetString(1),
                    RealName = rdr.GetString(2),
                    PassHash = rdr.GetString(3),
                    Email = rdr.GetString(4),
                    Phone = rdr.GetString(5),
                    RegisterDT = rdr.GetDateTime(6),
                    ID_Gender = rdr.GetInt32(7)
                };
                //WindowHello windowHello = new WindowHello();
                hello.ShowDialog();
                // вот тут можно прилепить переход на другое окно
            }
            else
            {
                MessageBox.Show("Отказано в доступе");
            }

        }
        // кнопка Забыл пароль
        private void ForgotPass_Click(object sender, RoutedEventArgs e)
        {

            WindowForgot windowForgot = new WindowForgot();
            windowForgot.ShowDialog();
        }
        #endregion
    }
}
