namespace CommunityToolkit.Maui.Core;

/// <summary>
/// Allows collapse and expand content.
/// </summary>
public interface IExpander : IView
{
	public IView Header { get; }
	public IView Content { get; }
	public bool IsExpanded { get; }
	public ExpandDirection Direction { get; }
}

public enum ExpandDirection
{
	Down,
	Up
}