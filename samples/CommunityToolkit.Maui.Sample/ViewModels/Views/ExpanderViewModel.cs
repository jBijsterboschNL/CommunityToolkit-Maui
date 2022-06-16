using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public partial class ExpanderViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<ContentCreator> contentCreators = new();

	public ExpanderViewModel()
	{
		contentCreators.Add(new ContentCreator("Brandon Minnick", "https://codetraveler.io/", "https://avatars.githubusercontent.com/u/13558917"));
		contentCreators.Add(new ContentCreator("Gerald Versluis", "https://blog.verslu.is/", "https://avatars.githubusercontent.com/u/939291"));
		contentCreators.Add(new ContentCreator("Pedro Jesus", "https://github.com/pictos", "https://avatars.githubusercontent.com/u/20712372"));
		contentCreators.Add(new ContentCreator("Shaun Lawrence", "https://github.com/bijington", "https://avatars.githubusercontent.com/u/17139988"));
		contentCreators.Add(new ContentCreator("Vladislav Antonyuk", "https://vladislavantonyuk.azurewebsites.net", "https://avatars.githubusercontent.com/u/33021114"));
	}
}

public record ContentCreator(string Name, string Resource, string Image);