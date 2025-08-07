using CommunityToolkit.Maui.Views;
using LanguageInUse.Components.LanguageCustomPicker;
using LanguageInUse.EventsArgs;
using System.Collections;
using System.Windows.Input;

namespace LanguageInUse.Components.CustomPicker;

public partial class DropDownButton : Border
{
    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        defaultValue: Color.FromArgb("#dcdcdc"),
        propertyName: nameof(BorderColor),
        returnType: typeof(Color),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty IsDisplayPickerControlProperty = BindableProperty.Create(
        propertyName: nameof(IsDisplayPickerControl),
        returnType: typeof(bool),
        declaringType: typeof(DropDownButton),
        propertyChanged: IsDisplayPickerControlPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
       propertyName: nameof(IsLoading),
       returnType: typeof(bool),
       declaringType: typeof(DropDownButton),
       defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
        propertyName: nameof(ItemSource),
        returnType: typeof(IEnumerable),
        declaringType: typeof(DropDownButton),
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty OpenPickerCommandProperty = BindableProperty.Create(
       propertyName: nameof(OpenPickerCommand),
       returnType: typeof(ICommand),
       declaringType: typeof(DropDownButton),
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(DropDownButton),
        propertyChanged: PlaceholderPropertyChanged,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
        defaultValue: Color.FromArgb("#dcdcdc"),
        propertyName: nameof(PlaceholderColor),
        returnType: typeof(Color),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        propertyName: nameof(SelectedItem),
        returnType: typeof(object),
        declaringType: typeof(DropDownButton),
        propertyChanged: SelectedItemPropertyChanged,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(DropDownButton),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextAttributesProperty = BindableProperty.Create(
        propertyName: nameof(TextAttributes),
        returnType: typeof(FontAttributes),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        defaultValue: Color.FromArgb("#dcdcdc"),
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextFontFamilyProperty = BindableProperty.Create(
        propertyName: nameof(TextFontFamily),
        returnType: typeof(string),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty TextSizeProperty = BindableProperty.Create(
        defaultValue: 14.0,
        propertyName: nameof(TextSize),
        returnType: typeof(double),
        declaringType: typeof(LanguageDropdown),
        defaultBindingMode: BindingMode.OneWay);

    public DropDownButton()
    {
        InitializeComponent();
    }

    public event EventHandler<EventArgs> OpenPickerEvent;

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public object SelectedItem
    {
        get => (object)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public string DisplayMember { get; set; }

    public string ImageDisplayMember { get; set; }

    public bool IsDisplayPickerControl
    {
        get => (bool)GetValue(IsDisplayPickerControlProperty);
        set => SetValue(IsDisplayPickerControlProperty, value);
    }

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public IEnumerable ItemSource
    {
        get => (IEnumerable)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);
    }

    public DataTemplate ItemTemplate { get; set; }

    public ICommand OpenPickerCommand
    {
        get => (ICommand)GetValue(OpenPickerCommandProperty);
        set => SetValue(OpenPickerCommandProperty, value);
    }

    public double PickerHeightRequest { get; set; }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty);
        set => SetValue(PlaceholderColorProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public FontAttributes TextAttributes
    {
        get => (FontAttributes)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string TextFontFamily
    {
        get => (string)GetValue(TextFontFamilyProperty);
        set => SetValue(TextFontFamilyProperty, value);
    }

    public double TextSize
    {
        get => (double)GetValue(TextSizeProperty);
        set => SetValue(TextSizeProperty, value);
    }

    private static void SelectedItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;

        if (newValue != null)
        {
            if (!string.IsNullOrWhiteSpace(controls.DisplayMember))
            {
                controls.lblDropDown.Text = newValue.GetType().GetProperty(controls.DisplayMember).GetValue(newValue, null).ToString();
                controls.Text = controls.lblDropDown.Text;
            }
            if (!string.IsNullOrWhiteSpace(controls.ImageDisplayMember))
                controls.imgDropDown.Source = newValue.GetType().GetProperty(controls.ImageDisplayMember).GetValue(newValue, null).ToString();
        }
    }

    private static async void IsDisplayPickerControlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;

        if (newValue != null)
        {
            if ((bool)newValue)
            {
                var pickerControlView = new PickerControlView(controls.ItemSource, controls.ItemTemplate, controls.PickerHeightRequest, controls.Placeholder);
                var response = await Application.Current.MainPage.ShowPopupAsync(pickerControlView, new CancellationToken());
                if (response != null)
                    controls.SelectedItem = response;

                controls.IsDisplayPickerControl = false;
            }
        }
    }

    private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;

        if (controls.SelectedItem == null)
        {
            if (newValue != null)
            {
                controls.lblDropDown.Text = newValue.ToString();
                controls.Text = newValue.ToString();
            }
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        OpenPickerCommand?.Execute(null);
        OpenPickerEvent?.Invoke(sender, e);
    }
}