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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Radio
{
	public partial class FilterForm : Form
	{
		public FilterForm(string tableName, List<string> header)
		{
			InitializeComponent();

			foreach (var item in header)
			{
				comboBoxSearch.Items.Add(item);
			}

			comboBoxSearch.SelectedIndex = 0;
			comboBoxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
			this.tableName = tableName;

			this.BackColor = Color.LightGray;
			this.buttonCancel.BackColor = Color.DarkOrange;
			this.buttonSearch.BackColor = Color.DarkOrange;
		}

		private string tableName;

		public string ReturnedData { get; private set; }


		private void buttonSearch_Click(object sender, EventArgs e)
		{
			ReturnedData = $"SELECT * FROM {tableName} " +
									$"WHERE [{comboBoxSearch.Text}] LIKE '{textBoxSearch.Text}'";

			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
