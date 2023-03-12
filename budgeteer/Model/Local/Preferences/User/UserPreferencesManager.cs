using budgeteer_maui.Model.Local.Preferences.User;
using Microsoft.Maui.Storage;
using System;
using System.Text.Json;

namespace budgeteer_maui.Model.Local.Preferences.User
{
    public class UserPreferences : IPreferences<LocalUser>
    {
        private static string storage_name = "user_preferences";
        public UserPreferences()
        {

        }

#nullable enable
        public LocalUser? getPreferences()
        {
            var json = Microsoft.Maui.Storage.Preferences.Get(storage_name, null);

            if (json == null)
                return null;

            return JsonSerializer.Deserialize<LocalUser>(json);
        }

        public void setPreferences(LocalUser preference)
        {
            var json = JsonSerializer.Serialize(preference);
            Microsoft.Maui.Storage.Preferences.Set(storage_name, json);
        }

        public void updatePreferences(Action<LocalUser> predicate)
        {
            var oldPreferences = getPreferences();

            if (oldPreferences == null)
            {
                oldPreferences = new LocalUser();
            }


             predicate.Invoke(oldPreferences);

            var pref = oldPreferences;

            var json = JsonSerializer.Serialize(pref);



            Microsoft.Maui.Storage.Preferences.Set(storage_name, json);

        }
    }
}

