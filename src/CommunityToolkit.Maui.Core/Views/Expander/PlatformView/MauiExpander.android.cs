using Android.Content;
using Android.Views;
using AndroidX.ConstraintLayout.Widget;

namespace CommunityToolkit.Maui.Core.Views;

public partial class MauiExpander : ConstraintLayout
{
	readonly Context context;

	/// <summary>
	/// Initialize a new instance of <see cref="MauiDrawingView" />.
	/// </summary>
	public MauiExpander(Context context) : base(context)
	{
		this.context = context;
	}

	public View? Header { get; set; }
	public View? Content { get; set; }

	public bool IsExpanded { get; set; }
	public ExpandDirection ExpandDirection { get; set; }
	public void Initialize()
	{
		if (ExpandDirection == ExpandDirection.Down)
		{
			AddView(Header, 0);
		}

		AddView(Content, 1);
		if (ExpandDirection == ExpandDirection.Up)
		{
			AddView(Header);

		}
	}

	public void CleanUp()
	{
	}
}