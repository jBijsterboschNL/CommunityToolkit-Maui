using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Core.Views;
using Microsoft.Maui.Handlers;

#if WINDOWS
using MauiExpander = Microsoft.UI.Xaml.Controls.Expander;
#endif

namespace CommunityToolkit.Maui.Core.Handlers;

/// <summary>
/// Expander handler
/// </summary>
public partial class ExpanderHandler
{
	/// <summary>
	/// <see cref ="PropertyMapper"/> for Expander Control.
	/// </summary>
	public static readonly IPropertyMapper<IExpander, ExpanderHandler> ExpanderMapper = new PropertyMapper<IExpander, ExpanderHandler>(ViewMapper)
	{
		
		[nameof(IExpander.Header)] = MapHeader,
		[nameof(IExpander.Content)] = MapContent,
		[nameof(IExpander.IsExpanded)] = MapIsExpanded,
		[nameof(IExpander.Direction)] = MapDirection,
	};

	/// <summary>
	/// <see cref ="CommandMapper"/> for Expander Control.
	/// </summary>
	public static readonly CommandMapper<IExpander, ExpanderHandler> ExpanderCommandMapper = new(ViewCommandMapper);

	/// <summary>
	/// Initialize new instance of <see cref="ExpanderHandler"/>.
	/// </summary>
	/// <param name="mapper">Custom instance of <see cref="PropertyMapper"/>, if it's null the <see cref="ExpanderMapper"/> will be used</param>
	/// <param name="commandMapper">Custom instance of <see cref="CommandMapper"/></param>
	public ExpanderHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
		: base(mapper ?? ExpanderMapper, commandMapper ?? ExpanderCommandMapper)
	{

	}

	/// <summary>
	/// Initialize new instance of <see cref="ExpanderHandler"/>.
	/// </summary>
	public ExpanderHandler() : this(ExpanderMapper, ExpanderCommandMapper)
	{
	}
}

#if ANDROID || IOS || MACCATALYST || WINDOWS
public partial class ExpanderHandler : ViewHandler<IExpander, MauiExpander>
{
	protected override void DisconnectHandler(MauiExpander platformView)
	{
#if !WINDOWS
		platformView.CleanUp();
#endif
		base.DisconnectHandler(platformView);
	}

	/// <inheritdoc />
#if ANDROID
	protected override MauiExpander CreatePlatformView() => new(Context);
#else
	protected override MauiExpander CreatePlatformView() => new();
#endif

	public static void MapHeader(ExpanderHandler handler, IExpander view)
	{
		handler.PlatformView.SetHeader(view.Header, handler.MauiContext);
	}

	public static void MapContent(ExpanderHandler handler, IExpander view)
	{
		handler.PlatformView.SetContent(view.Content, handler.MauiContext);
	}

	public static void MapIsExpanded(ExpanderHandler handler, IExpander view)
	{
		handler.PlatformView.SetIsExpanded(view.IsExpanded);
	}

	public static void MapDirection(ExpanderHandler handler, IExpander view)
	{
		handler.PlatformView.SetDirection(view.Direction);
	}
}
#else
public partial class ExpanderHandler : ViewHandler<IExpander, object>
{
	/// <inheritdoc />
	protected override object CreatePlatformView() => throw new NotSupportedException();
	
	public static void MapHeader(ExpanderHandler handler, IExpander view)
	{
	}
	
	public static void MapContent(ExpanderHandler handler, IExpander view)
	{
	}

	public static void MapIsExpanded(ExpanderHandler handler, IExpander view)
	{
	}

	public static void MapDirection(ExpanderHandler handler, IExpander view)
	{
	}
}
#endif