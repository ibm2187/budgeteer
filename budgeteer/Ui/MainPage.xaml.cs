using budgeteer_maui.Model.Local.Preferences.User;

namespace budgeteer_maui;

public partial class MainPage : ContentPage
{
	UserPreferences userPreferences = new UserPreferences();
	int count = 0;

    public MainPage()
	{
		InitializeComponent();

		CounterBtn.Text = userPreferences.getPreferences()?.FirstName ?? "noting";
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		userPreferences.updatePreferences(user =>
		{
			user.FirstName = count.ToString()
		;
		});

		if (count == 1)
			CounterBtn.Text = $"Clicked {userPreferences.getPreferences().FirstName} time";
		else
			CounterBtn.Text = $"Clicked {userPreferences.getPreferences().FirstName} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


