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
    public partial class DialogAdd : Form
    {
        private string connectionString;
        private string table;
        private string[] fields;

        public DialogAdd(string connectionString, string table, string[] fields)
        {
            InitializeComponent();

            this.connectionString = connectionString;
            this.table = table;
            this.fields = fields;
			this.BackColor = Color.LightGray;

			CreateForm();
        }

        private void CreateForm()
        {
            int labelTop = 10;
            int textBoxTop = 35;

            for (int i = 0; i < fields.Length; i++)
            {
                var label = new Label();
                label.Text = fields[i];
                label.AutoSize = true;
                label.Location = new Point(10, labelTop);
                label.Name = "label" + fields[i];
                this.Controls.Add(label);

                var textBox = new TextBox();
                textBox.AutoSize = true;
                textBox.Location = new Point(10, textBoxTop);
                textBox.Width = 300;
                textBox.Name = "textBox" + fields[i];
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

            Button addButton = new Button();
            addButton.Text = "Добавить";
            addButton.Height = 35;
            addButton.Width = 200;
            addButton.Location = new Point(115, textBoxTop - 15);
            addButton.Click += AddButton_Click;
			addButton.BackColor = Color.DarkOrange;
			this.Controls.Add(addButton);

            this.Size = new Size(this.Size.Width + 5, this.Size.Height + 5);
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object? sender, EventArgs e)
        { 
            try
            {
                string sqlExpression = $"INSERT INTO {table} VALUES ";
                StringBuilder tmp = new StringBuilder("(");

                for (int i = 0; i < fields.Length; i++)
                {
                    tmp.Append($"'{Controls[$"textBox{fields[i]}"].Text}', ");
                }
                tmp.Remove(tmp.Length - 2, 2);
                tmp.Append(')');

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
