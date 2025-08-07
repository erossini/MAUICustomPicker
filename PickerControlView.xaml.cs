using CommunityToolkit.Maui.Views;
using System.Collections;

namespace LanguageInUse.Components.CustomPicker;

public partial class PickerControlView : Popup
{
	public PickerControlView()
	{
		InitializeComponent();
	}

    public PickerControlView(IEnumerable itemSource, DataTemplate itemTemplate, double pickerControlHeight = 200, string title = "")
    {
        InitializeComponent();

        clPickerView.ItemsSource = itemSource;
        clPickerView.ItemTemplate = itemTemplate;
        grv.HeightRequest = pickerControlHeight;

        if(!string.IsNullOrEmpty(title))
            labelTitle.Text = title;
    }

    private void clPickerView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentItem = e.CurrentSelection.FirstOrDefault();
        this.Close(currentItem);
    }
}