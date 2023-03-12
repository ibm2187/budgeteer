using System;
namespace budgeteer_maui.Model.Local.Preferences
{
	public interface IPreferences<T>
	{
		void setPreferences(T preferences);

		#nullable enable
		T? getPreferences();

		void updatePreferences(Action<T> predicate);
		
	}
}

