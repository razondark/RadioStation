using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radio
{
	public partial class Login : Form
	{
		public Login(string connectionString)
		{
			InitializeComponent();

			this.connectionString = connectionString;
		}

		private string connectionString;
		public string ReturnedData { get; private set; }
		private bool IsEnter = false;

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			var login = textBoxLogin.Text;
			var password = textBoxPassword.Text;

			string sqlExpression = $"SELECT * FROM Пользователи " +
								   $"WHERE Логин = '{login}' AND Пароль = '{password}'";

			bool result = false;
			string status = "listener";

			try
			{
				using (var connection = new SqlConnection(connectionString))
				{
					connection.Open();

					SqlCommand command = new SqlCommand(sqlExpression, connection);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								result = true;
								status = reader.GetString(3);
							}
						}
						reader.Close();
					}
					connection.Close();
				}
			}
			catch
			{
				MessageBox.Show("Ошибка соединения с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (result == true)
			{
				MessageBox.Show($"Вы вошли как [{status}]", "Авторизация");
				ReturnedData = status;
				IsEnter = true;

				this.Close();
			}
			else
			{
				MessageBox.Show($"Некорректный логин или пароль", "Авторизация");
			}
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (IsEnter == false)
			{
				Application.Exit();
			}
		}
	}
}
