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
    public partial class SelectItem : Form
    {
        private bool form;
        private string table;
        private string connectionString;

        public SelectItem(string connectionString, string table, bool form) // 0 - update; 1 - delete
        {
            InitializeComponent();

            this.form = form;
            this.connectionString = connectionString;
            this.table = table;

            this.BackColor = Color.LightGray;

            if (form == false) // update
            {
                var label = new Label();
                label.Text = "Введите код для обновления записи";
                label.AutoSize = true;
                label.Location = new Point(10, 10);
                label.Name = "labelUpdate";
                this.Controls.Add(label);

                var textBox = new TextBox();
                textBox.AutoSize = true;
                textBox.Location = new Point(10, 35);
                textBox.Width = 300;
                textBox.Name = "textBoxUpdate";
                this.Controls.Add(textBox);

                Button cancelButton = new Button();
                cancelButton.Text = "Отмена";
                cancelButton.Height = 35;
                cancelButton.Width = 100;
                cancelButton.Location = new Point(10, 70);
                cancelButton.Click += CancelButton_Click;
                cancelButton.BackColor = Color.DarkOrange;
                this.Controls.Add(cancelButton);

                Button updateButton = new Button();
                updateButton.Text = "Изменить";
                updateButton.Height = 35;
                updateButton.Width = 200;
                updateButton.Location = new Point(110, 70);
                updateButton.Click += UpdateButton_Click;
				updateButton.BackColor = Color.DarkOrange;
				this.Controls.Add(updateButton);
            }
            else // delete
            {
                var label = new Label();
                label.Text = "Введите код для удаления записи";
                label.AutoSize = true;
                label.Location = new Point(10, 10);
                label.Name = "labelDelete";
                this.Controls.Add(label);

                var textBox = new TextBox();
                textBox.AutoSize = true;
                textBox.Location = new Point(10, 35);
                textBox.Width = 300;
                textBox.Name = "textBoxDelete";
                this.Controls.Add(textBox);

                Button cancelButton = new Button();
                cancelButton.Text = "Отмена";
                cancelButton.Height = 35;
                cancelButton.Width = 100;
                cancelButton.Location = new Point(10, 70);
                cancelButton.Click += CancelButton_Click;
				cancelButton.BackColor = Color.DarkOrange;
				this.Controls.Add(cancelButton);

                Button updateButton = new Button();
                updateButton.Text = "Удалить";
                updateButton.Height = 35;
                updateButton.Width = 200;
                updateButton.Location = new Point(110, 70);
                updateButton.Click += UpdateButton_Click;
				updateButton.BackColor = Color.DarkOrange;
				this.Controls.Add(updateButton);
            }

            this.AutoSize = true;
            this.Size = new Size(this.Size.Width + 5, this.Size.Height + 5);
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (form == false) // update
                {
                    string sqlExpression = $"SELECT * FROM {table} " +
                                           $"WHERE Код = {Controls[$"textBoxUpdate"].Text}";

                    Tuple<string[], string[]> tuple;

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
                                    var fields = new string[reader.FieldCount];
                                    var data = new string[reader.FieldCount];

                                    for (int i = 0; i < data.Length; i++)
                                    {
                                        data[i] = reader.GetValue(i).ToString();
                                    }

                                    for (int i = 0; i < fields.Length; i++)
                                    {
                                        fields[i] = reader.GetName(i);
                                    }

                                    tuple = new Tuple<string[], string[]>(fields, data);
                                    DialogResult = DialogResult.OK;
                                    this.Close();

                                    var updateForm = new DialogUpdate(connectionString, table, tuple);
                                    updateForm.ShowDialog();
                                }
                            }
                            reader.Close();
                        }
                        connection.Close();
                    }
                }
                else // delete
                {
                    DialogResult result = MessageBox.Show($"Вы действительно хотите удалить запись с кодом [{Controls[$"textBoxDelete"].Text}]?", "Удаление", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    string sqlExpression = $"DELETE FROM {table} " +
                                           $"WHERE Код = {Controls[$"textBoxDelete"].Text}";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();

                            reader.Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля корректными данными", "Ошибка");
            }
        }
    }
}
