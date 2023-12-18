namespace Radio
{
	partial class Login
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
			label1 = new Label();
			textBoxLogin = new TextBox();
			label2 = new Label();
			label3 = new Label();
			textBoxPassword = new TextBox();
			buttonLogin = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(288, 60);
			label1.TabIndex = 0;
			label1.Text = "Авторизация";
			// 
			// textBoxLogin
			// 
			textBoxLogin.Location = new Point(12, 92);
			textBoxLogin.Name = "textBoxLogin";
			textBoxLogin.Size = new Size(288, 27);
			textBoxLogin.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 69);
			label2.Name = "label2";
			label2.Size = new Size(52, 20);
			label2.TabIndex = 2;
			label2.Text = "Логин";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 130);
			label3.Name = "label3";
			label3.Size = new Size(62, 20);
			label3.TabIndex = 4;
			label3.Text = "Пароль";
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(12, 153);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(288, 27);
			textBoxPassword.TabIndex = 3;
			// 
			// buttonLogin
			// 
			buttonLogin.Location = new Point(12, 186);
			buttonLogin.Name = "buttonLogin";
			buttonLogin.Size = new Size(288, 47);
			buttonLogin.TabIndex = 5;
			buttonLogin.Text = "Вход";
			buttonLogin.UseVisualStyleBackColor = true;
			buttonLogin.Click += buttonLogin_Click;
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(309, 246);
			ControlBox = false;
			Controls.Add(buttonLogin);
			Controls.Add(label3);
			Controls.Add(textBoxPassword);
			Controls.Add(label2);
			Controls.Add(textBoxLogin);
			Controls.Add(label1);
			Name = "Login";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Авторизация";
			FormClosed += Login_FormClosed;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox textBoxLogin;
		private Label label2;
		private Label label3;
		private TextBox textBoxPassword;
		private Button buttonLogin;
	}
}