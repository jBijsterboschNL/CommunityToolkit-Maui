using CommunityToolkit.Maui.Core;

namespace CommunityToolkit.Maui.Views;

/// <summary>
/// Allows collapse and expand content.
/// </summary>
public class Expander : View, IExpander
{
	/// <summary>
	/// Initializes a new instance of the <see cref="Expander"/> class.
	/// </summary>
	public Expander()
	{
		Unloaded += OnExpanderUnloaded;
	}

	/// <summary>
	/// Backing BindableProperty for the <see cref="Header"/> property.
	/// </summary>
	public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(IView), typeof(Expander));
	public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(IView), typeof(Expander));
	public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(Expander));
	public static readonly BindableProperty DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(ExpandDirection), typeof(Expander));
	

	/// <summary>
	/// The <see cref="IView"/> that is used to show header of the <see cref="Expander"/>. This is a bindable property.
	/// </summary>
	public IView Header
	{
		get => (IView)GetValue(HeaderProperty);
		set => SetValue(HeaderProperty, value);
	}
	
	public IView Content
	{
		get => (IView)GetValue(ContentProperty);
		set => SetValue(ContentProperty, value);
	}
	
	public bool IsExpanded
	{
		get => (bool)GetValue(IsExpandedProperty);
		set => SetValue(IsExpandedProperty, value);
	}

	public ExpandDirection Direction
	{
		get => (ExpandDirection)GetValue(DirectionProperty);
		set => SetValue(DirectionProperty, value);
	}
	
	void OnExpanderUnloaded(object? sender, EventArgs e)
	{
		Unloaded -= OnExpanderUnloaded;
		Handler?.DisconnectHandler();
	}

	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();
		((View) Header).BindingContext = BindingContext;
		((View) Content).BindingContext = BindingContext;
	}
}
