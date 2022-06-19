using Android.Content;
using Android.Views;
using CommunityToolkit.Maui.Core.Extensions;

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
	/// Initialize a new instance of <see cref="MauiExpander" />.
	/// </summary>
	public MauiExpander(Context context) : base(context)
	{
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
			UpdateContentVisibility(value);
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

		Orientation = Orientation.Vertical;
		RemoveAllViews();
		
		ConfigureHeader();
		if (ExpandDirection == ExpandDirection.Down)
		{
			AddView(Header);
		}

		AddView(Content);
		UpdateContentVisibility(IsExpanded);

		if (ExpandDirection == ExpandDirection.Up)
		{
			AddView(Header);
		}
	}

	void UpdateContentVisibility(bool isVisible)
	{
		if (Content is not null)
		{
			Content.Visibility = isVisible ? ViewStates.Visible : ViewStates.Gone;
		}
	}
	
	void ConfigureHeader()
	{
		if (Header is null)
		{
			return;
		}

		Header.Clickable = true;
		Header.SetOnClickListener(new HeaderClickEventListener(this));
	}

	class HeaderClickEventListener : Java.Lang.Object, IOnClickListener
	{
		readonly MauiExpander expander;

		public HeaderClickEventListener(MauiExpander expander)
		{
			this.expander = expander;
		}

		public void OnClick(Android.Views.View? v)
		{
			expander.SetIsExpanded(!expander.IsExpanded);
		}
	}
}