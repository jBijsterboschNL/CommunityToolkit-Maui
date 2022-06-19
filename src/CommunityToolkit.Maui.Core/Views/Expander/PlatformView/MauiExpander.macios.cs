namespace CommunityToolkit.Maui.Core.Views;

public partial class MauiExpander : UIStackView
{
	UIView? header;
	UIView? content;
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

	void Draw()
	{
		if (Header is null || Content is null)
		{
			return;
		}

		Axis = UILayoutConstraintAxis.Vertical;
		foreach (var subView in ArrangedSubviews)
		{
			//RemoveArrangedSubview(subView);
		}
		
		ConfigureHeader();
		if (ExpandDirection == ExpandDirection.Down)
		{
			AddArrangedSubview(Header);
		}

		if (IsExpanded)
		{
			Content.ClipsToBounds = true;
			AddArrangedSubview(Content);
		}

		if (ExpandDirection == ExpandDirection.Up)
		{
			AddArrangedSubview(Header);
		}
	}
	
	void ConfigureHeader()
	{
		
	if (Header is null)
    		{
    			return;
    		}
		
		var expanderGesture = new UITapGestureRecognizer();
		expanderGesture.AddTarget(() => IsExpanded = !IsExpanded);
		Header.GestureRecognizers = new UIGestureRecognizer[]
		{
			expanderGesture
		};
	}
}