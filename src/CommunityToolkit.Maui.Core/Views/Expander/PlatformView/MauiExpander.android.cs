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
			AddView(GetHeader());
		}

		if (IsExpanded)
		{
			AddView(Content);
		}

		if (ExpandDirection == ExpandDirection.Up)
		{
			AddView(GetHeader());
		}
	}

	LinearLayout GetHeader()
	{
		var headerLayout = new LinearLayout(Context);
		headerLayout.Orientation = Orientation.Horizontal;
		headerLayout.Clickable = true;
		headerLayout.SetOnClickListener(new HeaderClickEventListener(this));

		if (Header is not null)
		{
			headerLayout.AddView(Header);			
		}
		
		headerLayout.AddView(new TextView(Context)
		{
			Text = IsExpanded ? 
				ExpandDirection == ExpandDirection.Up ? "V":"^" :
				ExpandDirection == ExpandDirection.Up ? "^":"V"
		});
		return headerLayout;
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