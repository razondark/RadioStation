using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Radio
{
	public partial class MainForm : Form
	{
		public MainForm(string tableName, int countColumns, bool enableMenuStrip = true)
		{
			InitializeComponent();

			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.MultiSelect = true;
			dataGridView.BackgroundColor = Color.LightGray;
			dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;

			this.BackColor = Color.LightGray;
			this.Text = tableName;
			this.tableName = tableName;
			this.countColumns = countColumns;

			FillTable();

			if (enableMenuStrip == false)
			{
				this.menuStrip1.Visible = false;
			}
		}

		private readonly string tableName;
		private readonly int countColumns;

		private List<List<string>> data;
		private List<string> header;

		private void GetData(string tableName, int countColumns)
		{
			string sqlExpression = $"SELECT * FROM {tableName} ";
			data = new List<List<string>>();
			header = new List<string>();

			using (var connection = new SqlConnection(DataBase.connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sqlExpression, connection);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					var list = new List<string>();

					if (reader.HasRows)
					{
						for (int i = 0; i < countColumns; i++)
						{
							header.Add(reader.GetName(i));
						}

						while (reader.Read())
						{
							for (int i = 0; i < countColumns; i++)
							{
								if (reader.GetValue(i) is DateTime)
								{
									list.Add(reader.GetValue(i).ToString().Split(' ').First());
									continue;
								}

								list.Add(reader.GetValue(i).ToString());
							}

							data.Add(new List<string>(list));
							list.Clear();
						}
					}
					reader.Close();
				}
				connection.Close();
			}
		}

		private void FillTable()
		{
			GetData(tableName, countColumns);

			dataGridView.Rows.Clear();
			dataGridView.Columns.Clear();

			foreach (var item in header)
			{
				dataGridView.Columns.Add($"col{item}", item);
			}

			foreach (var rows in data)
			{
				dataGridView.Rows.Add(rows.ToArray());
			}

			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] columns = new string[dataGridView.Columns.Count];
			for (int i = 0; i < columns.Length; i++)
			{
				columns[i] = dataGridView.Columns[i].HeaderText;
			}

			DialogAdd addForm = new DialogAdd(DataBase.connectionString, tableName, columns);
			var result = addForm.ShowDialog();

			if (result == DialogResult.OK)
			{
				FillTable();
			}
		}

		private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectItem s = new SelectItem(DataBase.connectionString, tableName, false);
			var result = s.ShowDialog();

			if (result == DialogResult.OK)
			{
				FillTable();
			}
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectItem s = new SelectItem(DataBase.connectionString, tableName, true);
			var result = s.ShowDialog();

			if (result == DialogResult.OK)
			{
				FillTable();
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Owner.Show();
		}

		private void GetDataByRequest(string sqlExpression)
		{
			dataGridView.Rows.Clear();
			dataGridView.Columns.Clear();

			using (var connection = new SqlConnection(DataBase.connectionString))
			{
				connection.Open();

				SqlCommand command = new SqlCommand(sqlExpression, connection);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					var list = new List<string>();

					if (reader.HasRows)
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							dataGridView.Columns.Add("col" + reader.GetName(i), reader.GetName(i));
						}

						while (reader.Read())
						{
							for (int i = 0; i < reader.FieldCount; i++)
							{
								if (reader.GetValue(i) is DateTime)
								{
									list.Add(reader.GetValue(i).ToString().Split(' ').First());
									continue;
								}

								list.Add(reader.GetValue(i).ToString());
							}

							dataGridView.Rows.Add(list.ToArray());
							list.Clear();
						}
					}
					reader.Close();
				}
				connection.Close();
			}
		}

		private void среднийВозрастСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Должности.Название, COUNT(Сотрудники.Код) AS [Количество сотрудников], AVG(Сотрудники.Возраст) AS [Средний возраст] " +
								"FROM Должности " +
								"LEFT JOIN Сотрудники ON Должности.Код = Сотрудники.Должность " +
								"GROUP BY Должности.Название ");
		}

		private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FillTable();
		}

		private void полнаяИнформацияОЗаписяхToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Записи.Код, Записи.Наименование, Исполнители.Наименование, Записи.Альбом, Записи.Год, Жанр.Наименование FROM Записи " +
								"JOIN Исполнители ON Исполнители.Код = Записи.[Код исполнителя] " +
								"JOIN Жанр ON Жанр.Код = Записи.[Код жанра] ");
		}

		private void краткаяИнформацияОСотрудникахToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Сотрудники.Код, Сотрудники.ФИО, Должности.Название [Должность], Должности.Оклад FROM Сотрудники " +
							   "JOIN Должности ON Должности.Код = Сотрудники.Должность ");
		}

		private void графикНаТекущийМесяцToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT График.Код, Дата, Сотрудники.ФИО, Записи.Наименование, Время FROM [График работы] График " +
				"JOIN Сотрудники ON Сотрудники.Код = График.Сотрудник " +
				"JOIN Записи ON Записи.Код = График.Запись " +
				"WHERE DATEDIFF(day, Дата, GETDATE()) <= 30 ");
		}

		private void группаИЕеПесняToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Записи.Наименование Группа, Исполнители.Наименование" +
				" FROM Записи " +
				"JOIN Исполнители ON Записи.[Код исполнителя] = Исполнители.Код ");
		}

		private void графикБезПесенToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT гр.Код, гр.Дата, гр.Время, с.ФИО, гр.Время, гр.Запись FROM [График работы] гр " +
				"JOIN Сотрудники с ON гр.Сотрудник = с.Код " +
				" WHERE Запись IS NULL");
		}

		private void должностиБезСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Название, Оклад FROM Должности " +
				"WHERE Код NOT IN(SELECT Должность " +
				"FROM Сотрудники) ");
		}

		private void песниЖанраРокToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GetDataByRequest("SELECT Записи.Код, Исполнители.Наименование, Записи.Наименование, Записи.Альбом, Записи.Год FROM Записи " +
				"JOIN Исполнители ON Исполнители.Код = Записи.[Код исполнителя] " +
				"WHERE[Код жанра] IN(SELECT Код " +
				"FROM Жанр WHERE Наименование LIKE 'рок') ");
		}

		// filter
		private void поискToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var filterForm = new FilterForm(tableName, header);
			filterForm.Owner = this;
			filterForm.ShowDialog();

			var result = filterForm.ReturnedData;

			if (result is null)
			{
				return;
			}

			try
			{
				GetDataByRequest(result);
			}
			catch
			{
			}
		}

		// search
		private void поискToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var searchForm = new FilterForm(tableName, header);
			searchForm.Owner = this;
			searchForm.ShowDialog();

			var result = searchForm.ReturnedData;

			if (result is null)
			{
				return;
			}

			var list = new List<int>();

			try
			{
				using (var connection = new SqlConnection(DataBase.connectionString))
				{
					connection.Open();

					SqlCommand command = new SqlCommand(result, connection);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								list.Add(reader.GetInt32(0) - 1);
							}
						}
						reader.Close();
					}
					connection.Close();
				}

				for (int i = 0; i < list.Count; i++)
				{
					dataGridView.Rows[list[i]].Selected = true;
				}
			}
			catch { }
		}

		private void сбросToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FillTable();
		}

		private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Вы действительно хотите сменить пользователя?", "Смена пользователя", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{
				Application.Restart();
			}
		}
	}
}
