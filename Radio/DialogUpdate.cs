using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radio
{
    public partial class DialogUpdate : Form
    {
        private string connectionString;
        private string table;
        Tuple<string[], string[]> fieldsAndData;

        public DialogUpdate(string connectionString, string table, Tuple<string[], string[]> fieldsAndData)
        {
            InitializeComponent();

            this.connectionString = connectionString;
            this.table = table;
            this.fieldsAndData = fieldsAndData;
			this.BackColor = Color.LightGray;

			int labelTop = 10;
            int textBoxTop = 35;

            for (int i = 0; i < fieldsAndData.Item1.Length; i++)
            {
                var label = new Label();
                label.Text = fieldsAndData.Item1[i];
                label.AutoSize = true;
                label.Location = new Point(10, labelTop);
                label.Name = "label" + fieldsAndData.Item1[i];
                this.Controls.Add(label);

                var textBox = new TextBox();
                textBox.AutoSize = true;
                textBox.Location = new Point(10, textBoxTop);
                textBox.Width = 300;
                textBox.Name = "textBox" + fieldsAndData.Item1[i];
                textBox.Text = fieldsAndData.Item2[i];
                this.Controls.Add(textBox);

                labelTop += 55;
                textBoxTop += 55;
            }

            Button cancelButton = new Button();
            cancelButton.Text = "Отмена";
            cancelButton.Height = 35;
            cancelButton.Width = 100;
            cancelButton.Location = new Point(10, textBoxTop - 15);
            cancelButton.Click += CancelButton_Click;
            cancelButton.BackColor = Color.DarkOrange;
            this.Controls.Add(cancelButton);

            Button updateButton = new Button();
            updateButton.Text = "Изменить";
            updateButton.Height = 35;
            updateButton.Width = 200;
            updateButton.Location = new Point(115, textBoxTop - 15);
            updateButton.Click += UpdateButton_Click;
            updateButton.BackColor = Color.DarkOrange;
            this.Controls.Add(updateButton);

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
                string sqlExpression = $"UPDATE {table} SET ";
                StringBuilder tmp = new StringBuilder("");

                for (int i = 0; i < fieldsAndData.Item2.Length; i++)
                {
                    tmp.Append($"{fieldsAndData.Item1[i]} = '{Controls[$"textBox{fieldsAndData.Item1[i]}"].Text}', ");
                }
                tmp.Remove(tmp.Length - 2, 2);
                tmp.Append($" WHERE {fieldsAndData.Item1[0]} = '{fieldsAndData.Item2[0]}'"); // по коду

                sqlExpression += tmp.ToString();

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Close();
                    }
                    connection.Close();
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Заполните все поля корректными данными", "Ошибка");
            }
        }
    }
}
