namespace L3
{
	partial class RegisterForm
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
			labelError = new Label();
			labelLogin = new Label();
			textBoxLogin = new TextBox();
			textBoxPassword = new TextBox();
			labelPassword = new Label();
			labelRepPassword = new Label();
			textBoxRepPassword = new TextBox();
			buttonRegister = new Button();
			SuspendLayout();
			// 
			// labelError
			// 
			labelError.AutoSize = true;
			labelError.ImageAlign = ContentAlignment.MiddleLeft;
			labelError.Location = new Point(12, 123);
			labelError.MinimumSize = new Size(300, 0);
			labelError.Name = "labelError";
			labelError.Size = new Size(300, 15);
			labelError.TabIndex = 0;
			labelError.Text = "LabelError";
			labelError.TextAlign = ContentAlignment.MiddleCenter;
			labelError.Visible = false;
			// 
			// labelLogin
			// 
			labelLogin.AutoSize = true;
			labelLogin.Location = new Point(10, 15);
			labelLogin.Name = "labelLogin";
			labelLogin.Size = new Size(44, 15);
			labelLogin.TabIndex = 1;
			labelLogin.Text = "Логин:";
			// 
			// textBoxLogin
			// 
			textBoxLogin.Location = new Point(130, 12);
			textBoxLogin.Name = "textBoxLogin";
			textBoxLogin.Size = new Size(178, 23);
			textBoxLogin.TabIndex = 2;
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(131, 41);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(177, 23);
			textBoxPassword.TabIndex = 3;
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(10, 44);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(52, 15);
			labelPassword.TabIndex = 4;
			labelPassword.Text = "Пароль:";
			// 
			// labelRepPassword
			// 
			labelRepPassword.AutoSize = true;
			labelRepPassword.Location = new Point(10, 71);
			labelRepPassword.Name = "labelRepPassword";
			labelRepPassword.Size = new Size(123, 15);
			labelRepPassword.TabIndex = 5;
			labelRepPassword.Text = "Подтвердите пароль:";
			// 
			// textBoxRepPassword
			// 
			textBoxRepPassword.Location = new Point(132, 68);
			textBoxRepPassword.Name = "textBoxRepPassword";
			textBoxRepPassword.Size = new Size(176, 23);
			textBoxRepPassword.TabIndex = 6;
			// 
			// buttonRegister
			// 
			buttonRegister.Location = new Point(91, 97);
			buttonRegister.Name = "buttonRegister";
			buttonRegister.Size = new Size(128, 23);
			buttonRegister.TabIndex = 7;
			buttonRegister.Text = "Зарегистрироваться";
			buttonRegister.UseVisualStyleBackColor = true;
			buttonRegister.Click += buttonRegister_Click;
			// 
			// RegisterForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(318, 146);
			Controls.Add(buttonRegister);
			Controls.Add(textBoxRepPassword);
			Controls.Add(labelRepPassword);
			Controls.Add(labelPassword);
			Controls.Add(textBoxPassword);
			Controls.Add(textBoxLogin);
			Controls.Add(labelLogin);
			Controls.Add(labelError);
			Name = "RegisterForm";
			Text = "RegisterForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelError;
		private Label labelLogin;
		private TextBox textBoxLogin;
		private TextBox textBoxPassword;
		private Label labelPassword;
		private Label labelRepPassword;
		private TextBox textBoxRepPassword;
		private Button buttonRegister;
	}
}