using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkit.Maui.Sample.ViewModels.Views;

public partial class ExpanderViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isExpanded = true;
}