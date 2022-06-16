namespace CommunityToolkit.Maui.Core.Views;

public partial class MauiExpander : UIView
{
	private UIView? header;
	private UIView? content;
	bool isExpanded;
	ExpandDirection expandDirection;

	public UIView? Header
	{
		get => header;
		set
		{
			header = value;
			Draw();
		}
	}

	public UIView? Content
	{
		get => content;
		set
		{
			content = value;
			Draw();
		}
	}



	/// <summary>
	/// 
	/// </summary>
	public bool IsExpanded
	{
		get => isExpanded;
		set
		{
			isExpanded = value;
			Draw();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public ExpandDirection ExpandDirection
	{
		get => expandDirection;
		set
		{
			expandDirection = value;
			Draw();
		}
	}

	public void Draw()
	{
		if (Header is null || Content is null)
		{
			return;
		}

		var container = new UIStackView()
		{
			Axis = UILayoutConstraintAxis.Vertical
		};

		Content.ClipsToBounds = true;

		if (ExpandDirection == ExpandDirection.Down)
		{
			container.AddArrangedSubview(Header);
		}

		if (IsExpanded)
		{
			container.AddArrangedSubview(Content);
		}

		if (ExpandDirection == ExpandDirection.Up)
		{
			container.AddArrangedSubview(Header);

		}
		AddSubview(container);
	}
}