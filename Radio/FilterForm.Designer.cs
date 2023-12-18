namespace Radio
{
	partial class FilterForm
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
			comboBoxSearch = new ComboBox();
			textBoxSearch = new TextBox();
			buttonSearch = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// comboBoxSearch
			// 
			comboBoxSearch.FormattingEnabled = true;
			comboBoxSearch.Location = new Point(12, 12);
			comboBoxSearch.Name = "comboBoxSearch";
			comboBoxSearch.Size = new Size(368, 28);
			comboBoxSearch.TabIndex = 0;
			// 
			// textBoxSearch
			// 
			textBoxSearch.Location = new Point(12, 46);
			textBoxSearch.Name = "textBoxSearch";
			textBoxSearch.Size = new Size(368, 27);
			textBoxSearch.TabIndex = 1;
			// 
			// buttonSearch
			// 
			buttonSearch.Location = new Point(118, 79);
			buttonSearch.Name = "buttonSearch";
			buttonSearch.Size = new Size(262, 46);
			buttonSearch.TabIndex = 2;
			buttonSearch.Text = "Фильтр";
			buttonSearch.UseVisualStyleBackColor = true;
			buttonSearch.Click += buttonSearch_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(12, 79);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(100, 46);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// FilterForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(389, 135);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSearch);
			Controls.Add(textBoxSearch);
			Controls.Add(comboBoxSearch);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FilterForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Фильтр";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox comboBoxSearch;
		private TextBox textBoxSearch;
		private Button buttonSearch;
		private Button buttonCancel;
	}
}