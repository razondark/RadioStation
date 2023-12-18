namespace Radio
{
	partial class SearchForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttonCancel = new Button();
			buttonSearch = new Button();
			textBoxSearch = new TextBox();
			comboBoxSearch = new ComboBox();
			SuspendLayout();
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(12, 79);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(100, 46);
			buttonCancel.TabIndex = 7;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// buttonSearch
			// 
			buttonSearch.Location = new Point(118, 79);
			buttonSearch.Name = "buttonSearch";
			buttonSearch.Size = new Size(262, 46);
			buttonSearch.TabIndex = 6;
			buttonSearch.Text = "Поиск";
			buttonSearch.UseVisualStyleBackColor = true;
			buttonSearch.Click += buttonSearch_Click;
			// 
			// textBoxSearch
			// 
			textBoxSearch.Location = new Point(12, 46);
			textBoxSearch.Name = "textBoxSearch";
			textBoxSearch.Size = new Size(368, 27);
			textBoxSearch.TabIndex = 5;
			// 
			// comboBoxSearch
			// 
			comboBoxSearch.FormattingEnabled = true;
			comboBoxSearch.Location = new Point(12, 12);
			comboBoxSearch.Name = "comboBoxSearch";
			comboBoxSearch.Size = new Size(368, 28);
			comboBoxSearch.TabIndex = 4;
			// 
			// SearchForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(388, 134);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSearch);
			Controls.Add(textBoxSearch);
			Controls.Add(comboBoxSearch);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SearchForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Поиск";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonCancel;
		private Button buttonSearch;
		private TextBox textBoxSearch;
		private ComboBox comboBoxSearch;
	}
}