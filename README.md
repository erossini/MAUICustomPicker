# MAUI Custom Dropdown/Picker

This code is working with `.NET 8 MAUI` and the `CommunityToolkit.Maui` version 9.0.3. The component works for iOS, Android and Windows. The component appears 

## Usage

In a `ContentPage` or `ContentView`, you can add 

```xml
<ContentPage
    xmlns:ldd="clr-namespace:LanguageInUse.Components.LanguageCustomPicker"
```

and then use the dropdown like this

```xml

<ddl:DropDownButton
	x:Name="ddbGender"
	Margin="0,0,0,15"
	DisplayMember="Text"
	IsDisplayPickerControl="{Binding IsGenderDisplayPicker}"
	IsLoading="{Binding IsGenderLoadingPicker}"
	ItemSource="{Binding GenderList}"
	OpenPickerCommand="{Binding OpenGenderPickerCommand}"
	PickerHeightRequest="300"
	Placeholder="{lang:Translate WordGenderPlaceholder}"
	SelectedItem="{Binding SelectedGender}"
	Text="{Binding WordGenderSelectedText}"
	TextSize="{OnIdiom Default='18',
						Desktop='24'}">
	<ddl:DropDownButton.Triggers>
		<MultiTrigger TargetType="ddl:DropDownButton">
			<MultiTrigger.Conditions>
				<BindingCondition Binding="{Binding WordGenderTextChangedAction}" Value="1" />
			</MultiTrigger.Conditions>
			<Setter Property="TextColor" Value="{StaticResource Gray400}" />
		</MultiTrigger>
	</ddl:DropDownButton.Triggers>
	<ddl:DropDownButton.ItemTemplate>
		<DataTemplate x:DataType="md:GenderValueText">
			<HorizontalStackLayout
				Margin="5,5,5,5"
				HorizontalOptions="FillAndExpand"
				VerticalOptions="FillAndExpand">
				<Border
					Margin="0,0,5,0"
					BackgroundColor="{Binding GenderColor}"
					HeightRequest="{OnIdiom Default=30,
											Tablet=40}"
					HorizontalOptions="Center"
					StrokeShape="RoundRectangle 8"
					VerticalOptions="Center"
					WidthRequest="35" />
				<Label
					FontSize="{OnIdiom Default='18',
										Desktop='24'}"
					HorizontalOptions="StartAndExpand"
					Text="{Binding Text}"
					TextColor="Black"
					VerticalOptions="CenterAndExpand"
					VerticalTextAlignment="Center" />
			</HorizontalStackLayout>
		</DataTemplate>
	</ddl:DropDownButton.ItemTemplate>
</ddl:DropDownButton>
```

## Example result

![typeword](https://github.com/user-attachments/assets/6fccf74c-1402-4930-8b2f-84bd3671ab58)

![languages](https://github.com/user-attachments/assets/271d63fe-884c-48f1-951e-10fc2b8f6b6b)
