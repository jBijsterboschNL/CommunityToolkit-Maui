using Android.Content;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;

namespace CommunityToolkit.Maui.Core.Views;

/// <summary>
/// 
/// </summary>
public partial class MauiExpander : LinearLayout
{
	View? content;
	View? header;
	bool isExpanded;
	ExpandDirection expandDirection;

	/// <summary>
	/// Initialize a new instance of <see cref="MauiDrawingView" />.
	/// </summary>
	public MauiExpander(Context context) : base(context)
	{
		Orientation = Orientation.Vertical;
	}

	/// <summary>
	/// 
	/// </summary>
	public View? Header
	{
		get => header;
		set
		{
			header = value;
			Draw();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public View? Content
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
		
		RemoveAllViews();

		if (ExpandDirection == ExpandDirection.Down)
		{
			AddView(Header);
		}

		if (IsExpanded)
		{
			AddView(Content);
		}

		if (ExpandDirection == ExpandDirection.Up)
		{
			AddView(Header);
		}
	}
}