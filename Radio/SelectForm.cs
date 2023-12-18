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
	public partial class SelectForm : Form
	{
		public SelectForm()
		{
			InitializeComponent();

			this.BackColor = Color.LightGray;
			this.buttonArtists.BackColor = Color.DarkOrange;
			this.buttonEmployees.BackColor = Color.DarkOrange;
			this.buttonGenre.BackColor = Color.DarkOrange;
			this.buttonPosition.BackColor = Color.DarkOrange;
			this.buttonRecords.BackColor = Color.DarkOrange;
			this.buttonShedule.BackColor = Color.DarkOrange;

			this.Visible = false;
			Login loginForm = new Login(DataBase.connectionString);
			loginForm.ShowDialog();

			var result = loginForm.ReturnedData;

			if (result == "user")
			{
				buttonEmployees.Visible = false;
				buttonPosition.Visible = false;
			}
			else if (result == "listener")
			{
				buttonEmployees.Visible = false;
				buttonPosition.Visible = false;
				EnableMenuStrip = false;
			}

			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "logo.png"));
		}

		private readonly bool EnableMenuStrip = true;

		private void buttonArtists_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("Исполнители", 3, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}

		private void buttonGenre_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("Жанр", 3, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}

		private void buttonRecords_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("Записи", 6, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}

		private void buttonEmployees_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("Сотрудники", 7, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}

		private void buttonPosition_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("Должности", 5, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}

		private void buttonShedule_Click(object sender, EventArgs e)
		{
			this.Hide();
			var mainForm = new MainForm("[График работы]", 5, EnableMenuStrip);
			mainForm.Owner = this;
			mainForm.Show();
		}
	}
}
