namespace Radio
{
	partial class SelectForm
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
			buttonArtists = new Button();
			buttonGenre = new Button();
			buttonRecords = new Button();
			buttonEmployees = new Button();
			buttonPosition = new Button();
			buttonShedule = new Button();
			pictureBox = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			SuspendLayout();
			// 
			// buttonArtists
			// 
			buttonArtists.Location = new Point(12, 12);
			buttonArtists.Name = "buttonArtists";
			buttonArtists.Size = new Size(241, 53);
			buttonArtists.TabIndex = 0;
			buttonArtists.Text = "Исполнители";
			buttonArtists.UseVisualStyleBackColor = true;
			buttonArtists.Click += buttonArtists_Click;
			// 
			// buttonGenre
			// 
			buttonGenre.Location = new Point(259, 12);
			buttonGenre.Name = "buttonGenre";
			buttonGenre.Size = new Size(241, 53);
			buttonGenre.TabIndex = 3;
			buttonGenre.Text = "Жанр";
			buttonGenre.UseVisualStyleBackColor = true;
			buttonGenre.Click += buttonGenre_Click;
			// 
			// buttonRecords
			// 
			buttonRecords.Location = new Point(506, 12);
			buttonRecords.Name = "buttonRecords";
			buttonRecords.Size = new Size(241, 53);
			buttonRecords.TabIndex = 4;
			buttonRecords.Text = "Записи";
			buttonRecords.UseVisualStyleBackColor = true;
			buttonRecords.Click += buttonRecords_Click;
			// 
			// buttonEmployees
			// 
			buttonEmployees.Location = new Point(12, 267);
			buttonEmployees.Name = "buttonEmployees";
			buttonEmployees.Size = new Size(241, 53);
			buttonEmployees.TabIndex = 5;
			buttonEmployees.Text = "Сотрудники";
			buttonEmployees.UseVisualStyleBackColor = true;
			buttonEmployees.Click += buttonEmployees_Click;
			// 
			// buttonPosition
			// 
			buttonPosition.Location = new Point(506, 267);
			buttonPosition.Name = "buttonPosition";
			buttonPosition.Size = new Size(241, 53);
			buttonPosition.TabIndex = 6;
			buttonPosition.Text = "Должности";
			buttonPosition.UseVisualStyleBackColor = true;
			buttonPosition.Click += buttonPosition_Click;
			// 
			// buttonShedule
			// 
			buttonShedule.Location = new Point(259, 267);
			buttonShedule.Name = "buttonShedule";
			buttonShedule.Size = new Size(241, 53);
			buttonShedule.TabIndex = 7;
			buttonShedule.Text = "График работы";
			buttonShedule.UseVisualStyleBackColor = true;
			buttonShedule.Click += buttonShedule_Click;
			// 
			// pictureBox
			// 
			pictureBox.Location = new Point(259, 71);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(241, 190);
			pictureBox.TabIndex = 8;
			pictureBox.TabStop = false;
			// 
			// SelectForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(754, 328);
			Controls.Add(pictureBox);
			Controls.Add(buttonShedule);
			Controls.Add(buttonPosition);
			Controls.Add(buttonEmployees);
			Controls.Add(buttonRecords);
			Controls.Add(buttonGenre);
			Controls.Add(buttonArtists);
			Name = "SelectForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Радиостанция";
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonArtists;
		private Button buttonGenre;
		private Button buttonRecords;
		private Button buttonEmployees;
		private Button buttonPosition;
		private Button buttonShedule;
		private PictureBox pictureBox;
	}
}