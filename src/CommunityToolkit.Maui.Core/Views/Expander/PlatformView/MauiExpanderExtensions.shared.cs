using CommunityToolkit.Maui.Core.Views;
using Microsoft.Maui.Platform;
#if WINDOWS
using MauiExpander = Microsoft.UI.Xaml.Controls.Expander;
#endif
namespace CommunityToolkit.Maui.Core.Extensions;

/// <summary>
/// Extension methods to support <see cref="IExpander"/>
/// </summary>
public static partial class MauiExpanderExtensions
{
#if ANDROID || IOS || MACCATALYST || WINDOWS


	/// <summary>
	/// Set Header
	/// </summary>
	/// <param name="mauiExpander"><see cref="MauiExpander"/></param>
	/// <param name="header">header</param>
	public static void SetHeader(this MauiExpander mauiExpander, IView header, IMauiContext? context)
	{
		ArgumentNullException.ThrowIfNull(context);
		mauiExpander.Header = header.ToPlatform(context);
	}

	/// <summary>
	/// Set Content
	/// </summary>
	/// <param name="mauiExpander"><see cref="MauiExpander"/></param>
	/// <param name="content">Content</param>
	public static void SetContent(this MauiExpander mauiExpander, IView content, IMauiContext? context)
	{
		ArgumentNullException.ThrowIfNull(context);
		mauiExpander.Content = content.ToPlatform(context);
	}

	/// <summary>
	/// Set IsExpanded
	/// </summary>
	/// <param name="mauiExpander"><see cref="MauiExpander"/></param>
	/// <param name="isExpanded">Content</param>
	public static void SetIsExpanded(this MauiExpander mauiExpander, bool isExpanded)
	{
		mauiExpander.IsExpanded = isExpanded;
	}

	/// <summary>
	/// Set Direction
	/// </summary>
	/// <param name="mauiExpander"><see cref="MauiExpander"/></param>
	/// <param name="direction">Content</param>
	public static void SetDirection(this MauiExpander mauiExpander, ExpandDirection direction)
	{
		mauiExpander.ExpandDirection = direction.ToPlatform();
	}
#endif

#if WINDOWS
	static Microsoft.UI.Xaml.Controls.ExpandDirection ToPlatform(this ExpandDirection direction)
	{
		return Enum.Parse<Microsoft.UI.Xaml.Controls.ExpandDirection>(direction.ToString());
	}
#else
	static ExpandDirection ToPlatform(this ExpandDirection direction)
	{
		return direction;
	}
#endif
}