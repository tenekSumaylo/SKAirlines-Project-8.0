namespace SKAirlines_Project.CustomControl;

public partial class NounderlineEntry : Grid
{
	public NounderlineEntry()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text),
		returnType: typeof(string),
		declaringType: typeof(NounderlineEntry),
		defaultValue: null,
		defaultBindingMode: BindingMode.TwoWay);


	public string Text
	{
		get => (string)GetValue( TextProperty );
		set { SetValue(TextProperty, value); }
	}

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
    propertyName: nameof(Placeholder),
    returnType: typeof(string),
    declaringType: typeof(NounderlineEntry),
    defaultValue: null,
    defaultBindingMode: BindingMode.OneWay);


    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }


}