using L3;

namespace UnitTestProject
{
	public class Tests
	{

		private RegisterForm form;
		private MockDB dbMock;

		[SetUp]
		public void Setup()
		{
			form = new RegisterForm();
			dbMock = new MockDB();
			form.controller = dbMock;
		}

		[TearDown]
		public void TearDown()
		{
			form.Dispose();
		}

		// 001: Базовый поток проверки данных
		[Test]
		public void T_001_CheckDoctorData_BaseFlow()
		{
			Assert.DoesNotThrow(() =>
				Assert.IsTrue(RegisterForm.checkDoctorData(
					"myname_doctor", "doctorSuperBest123!", "doctorSuperBest123!")));
		}

		// 002: Пустой логин
		[Test]
		public void T_002_CheckDoctorData_EmptyLogin()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("", "doctorSuperBest123!", "doctorSuperBest123!"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.EmptyLogin, ex.Message);
		}

		// 003: Пустой первый пароль
		[Test]
		public void T_003_CheckDoctorData_EmptyPassword1()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "", "doctorSuperBest123!"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.EmptyPassword1, ex.Message);
		}

		// 004: Пустой второй пароль
		[Test]
		public void T_004_CheckDoctorData_EmptyPassword2()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "doctorSuperBest123!", ""));
			Assert.AreEqual(RegisterForm.ExceptionStrings.EmptyPassword2, ex.Message);
		}

		// 005: Несовпадение паролей
		[Test]
		public void T_005_CheckDoctorData_DifferentPasswords()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "passA123!", "passB123!"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.DifferentPasswords, ex.Message);
		}

		// 006: Логин и пароль совпадают
		[Test]
		public void T_006_CheckDoctorData_SameLoginPassword()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("sameValue", "sameValue", "sameValue"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.SameLoginPassword, ex.Message);
		}

		// 007: Пароль менее 10 символов
		[Test]
		public void T_007_CheckDoctorData_PasswordLess10Chars()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "Short1!A", "Short1!A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.PasswordLess10Chars, ex.Message);
		}

		// 008: Пароль без цифр
		[Test]
		public void T_008_CheckDoctorData_PasswordNoNumber()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "NoNumber!A", "NoNumber!A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.PasswordNoNumber, ex.Message);
		}

		// 009: Пароль без спецсимволов
		[Test]
		public void T_009_CheckDoctorData_PasswordNoExtraChar()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "NoExtra123A", "NoExtra123A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.PasswordNoExtraChar, ex.Message);
		}

		// 010: Пароль без заглавной буквы
		[Test]
		public void T_010_CheckDoctorData_PasswordNoUpperChar()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("myname_doctor", "lowercase123!", "lowercase123!"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.PasswordNoUpperChar, ex.Message);
		}

		// 011: Запрещенный формат логина
		[Test]
		public void T_011_CheckDoctorData_LoginForbidden()
		{
			var ex = Assert.Throws<Exception>(() =>
				RegisterForm.checkDoctorData("bad!login", "Valid123!A", "Valid123!A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.LoginForbidden, ex.Message);
		}

		// 012: onRegisterClick - успех
		[Test]
		public void T_012_onRegisterClick_Success()
		{
			dbMock.CanConnect = true;
			dbMock.CanCreate = true;
			dbMock.NewEntry = new DoctorEntry { id = 42, login = "user1", passwordHash = "Passw0rd!A" };

			DoctorEntry result = null;
			Assert.DoesNotThrow(() => result = form.onRegisterClick("user1", "Passw0rd!A", "Passw0rd!A"));
			Assert.IsNotNull(result);
			Assert.AreEqual(42, result.id);
			Assert.AreEqual("user1", result.login);
		}

		// 013: onRegisterClick - нет подключения
		[Test]
		public void T_013_onRegisterClick_NoConnectionDB()
		{
			dbMock.CanConnect = false;
			var ex = Assert.Throws<Exception>(() => form.onRegisterClick("user1", "Passw0rd!A", "Passw0rd!A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.NoConnectionDB, ex.Message);
		}

		// 014: onRegisterClick - логин занят
		[Test]
		public void T_014_onRegisterClick_LoginAlreadyExists()
		{
			dbMock.CanConnect = true;
			dbMock.CanCreate = false;
			var ex = Assert.Throws<Exception>(() => form.onRegisterClick("user1", "Passw0rd!A", "Passw0rd!A"));
			Assert.AreEqual(RegisterForm.ExceptionStrings.LoginAlreadyExists, ex.Message);
		}

		// Мок контроллера
		private class MockDB : IDatabaseController
		{
			public bool CanConnect = true;
			public bool CanCreate = true;
			public DoctorEntry NewEntry = new DoctorEntry { id = 1, login = "mock", passwordHash = "mock" };

			public bool tryConnectDB() => CanConnect;
			public bool tryCreateAccount(string login, string password) => CanCreate;
			public DoctorEntry getNewDoctorEntry() => NewEntry;
			public bool login(string login, string password) => true;
		}
	}
}