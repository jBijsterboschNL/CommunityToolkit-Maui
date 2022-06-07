namespace CommunityToolkit.Maui.Core.Views;

public partial class MauiExpander : UIView
{
	public UIView Header { get; set; } = new();
	public UIView Content { get; set; } = new();
	public bool IsExpanded { get; set; }
	public ExpandDirection ExpandDirection { get; set; }

	public void Initialize()
	{
		var container = new UIStackView()
		{
			Axis = UILayoutConstraintAxis.Vertical
		};

		Content.ClipsToBounds = true;

		if (ExpandDirection == ExpandDirection.Down)
		{
			container.AddArrangedSubview(Header);
		}

		container.AddArrangedSubview(Content);
		if (ExpandDirection == ExpandDirection.Up)
		{
			container.AddArrangedSubview(Header);

		}
		AddSubview(container);
	}

	public void CleanUp()
	{
	}
}