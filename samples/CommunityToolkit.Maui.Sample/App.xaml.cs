using CommunityToolkit.Maui.Sample.Pages.Views;
using Application = Microsoft.Maui.Controls.Application;

namespace CommunityToolkit.Maui.Sample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();


		// Open the Flyout > Views > Custom Positioning Popups
		MainPage = new AppShell();

		//MainPage = new PopupPositionPage(new ViewModels.Views.PopupPositionViewModel());

		//MainPage = new NavigationPage(new PopupPositionPage(new ViewModels.Views.PopupPositionViewModel()));

	}

	protected override void OnStart()
	{
		base.OnStart();
	}
}