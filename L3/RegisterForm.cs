
namespace L3
{
	public partial class RegisterForm : Form
	{
		public IDatabaseController controller { get; set; } = null;

		public RegisterForm()
		{
			InitializeComponent();
			checkDoctorData("myname_doctor", "doctorSuperBest123!", "doctorSuperBest123!");
		}

		/// <summary>Строки исключений для модуля регистрации.</summary>
		public static class ExceptionStrings
		{
			public const string EmptyLogin = "Логин не может быть пустым.";
			public const string EmptyPassword1 = "Пропущено поле первого ввода пароля.";
			public const string EmptyPassword2 = "Пропущено поле второго ввода пароля.";
			public const string DifferentPasswords = "Пароли не совпадают!";
			public const string SameLoginPassword = "Логин и пароль не могут совпадать.";
			public const string PasswordLess10Chars = "Пароль не может быть менее 10 символов.";
			public const string PasswordNoNumber = "Пароль должен содержать хотя бы один символ цифры.";
			public const string PasswordNoExtraChar = "Пароль должен содержать хотя бы один символ из @#$%^&*! .";
			public const string PasswordNoUpperChar = "Пароль должен содержать хотя бы один символ в верхнем регистре.";
			public const string LoginForbidden = "Логин должен состоять только из цифр, букв и символа _.";
			public const string NoConnectionDB = "Нет доступа к базе данных, проверьте подключение.";
			public const string LoginAlreadyExists = "Уже существует пользователь с данным логином.";
		}

		/// <summary>Проверка корректности данных регистрации.</summary>
		public static bool checkDoctorData(string login, string password, string repPassword)
		{
			if (string.IsNullOrWhiteSpace(login))
				throw new Exception(ExceptionStrings.EmptyLogin);
			if (string.IsNullOrWhiteSpace(password))
				throw new Exception(ExceptionStrings.EmptyPassword1);
			if (string.IsNullOrWhiteSpace(repPassword))
				throw new Exception(ExceptionStrings.EmptyPassword2);
			if (password != repPassword)
				throw new Exception(ExceptionStrings.DifferentPasswords);
			if (login == password)
				throw new Exception(ExceptionStrings.SameLoginPassword);
			if (password.Length < 10)
				throw new Exception(ExceptionStrings.PasswordLess10Chars);

			var regex = new System.Text.RegularExpressions.Regex("[0-9]");
			if (!regex.IsMatch(password))
				throw new Exception(ExceptionStrings.PasswordNoNumber);

			regex = new System.Text.RegularExpressions.Regex("[@#$%^&*!]");
			if (!regex.IsMatch(password))
				throw new Exception(ExceptionStrings.PasswordNoExtraChar);

			regex = new System.Text.RegularExpressions.Regex("[A-ZА-Я]");
			if (!regex.IsMatch(password))
				throw new Exception(ExceptionStrings.PasswordNoUpperChar);

			regex = new System.Text.RegularExpressions.Regex("^[0-9A-Za-zА-Яа-я_]+$");
			if (!regex.IsMatch(login))
				throw new Exception(ExceptionStrings.LoginForbidden);

			return true;
		}

		/// <summary>Обработчик кнопки "Зарегистрироваться".</summary>
		private void buttonRegister_Click(object sender, EventArgs e)
		{
			try
			{
				var doctor = onRegisterClick(textBoxLogin.Text, textBoxPassword.Text, textBoxRepPassword.Text);
				MessageBox.Show($"Регистрация успешна. ID={doctor.id}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				labelError.Text = ex.Message;
				labelError.Visible = true;
			}
		}

		/// <summary>Основная логика регистрации.</summary>
		public DoctorEntry onRegisterClick(string login, string password, string repPassword)
		{
			checkDoctorData(login, password, repPassword);
			if (!controller.tryConnectDB())
				throw new Exception(ExceptionStrings.NoConnectionDB);
			if (!controller.tryCreateAccount(login, password))
				throw new Exception(ExceptionStrings.LoginAlreadyExists);
			return controller.getNewDoctorEntry();
		}
	}
}
