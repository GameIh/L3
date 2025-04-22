
namespace L3
{
	/// <summary>
	/// Интерфейс контроллера БД для регистрации врачей.
	/// </summary>
	public interface IDatabaseController
	{
		bool tryConnectDB();
		bool tryCreateAccount(string login, string password);
		DoctorEntry getNewDoctorEntry();
		bool login(string login, string password);
	}

}
