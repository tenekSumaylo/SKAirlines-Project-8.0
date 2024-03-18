using Microsoft.Maui;
using System.Security.Cryptography.X509Certificates;

namespace SKAirlines_Project.CustomControl;

public partial class entryDesignOne : Grid
{
	public entryDesignOne()
	{
		InitializeComponent();
	}
	

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
	propertyName: nameof( Text ),
	returnType: typeof(string),
	declaringType: typeof(entryDesignOne),
	defaultValue: null,
	defaultBindingMode: BindingMode.TwoWay);

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set { SetValue(TextProperty, value); }
	}

	public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
	propertyName: nameof(Placeholder),
	returnType: typeof( string ),
	declaringType: typeof( entryDesignOne),
	defaultValue: null,
	defaultBindingMode: BindingMode.TwoWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }
}