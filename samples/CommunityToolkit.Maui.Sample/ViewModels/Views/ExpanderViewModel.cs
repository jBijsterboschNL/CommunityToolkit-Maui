using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public partial class ExpanderViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<ContentCreator> contentCreators = new();

	public ExpanderViewModel()
	{
		contentCreators.Add(new ContentCreator("Brandon Minnick", "https://codetraveler.io/"));
		contentCreators.Add(new ContentCreator("Gerald Versluis", "https://blog.verslu.is/"));
		contentCreators.Add(new ContentCreator("Pedro Jesus", "https://github.com/bijington"));
		contentCreators.Add(new ContentCreator("Shaun Lawrence", "https://github.com/bijington"));
		contentCreators.Add(new ContentCreator("Vladislav Antonyuk", "https://vladislavantonyuk.azurewebsites.net"));
	}
}

public record ContentCreator(string Name, string Resource);