﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiscordRichPresencePresets
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly List<Presence> _presences = new List<Presence>
		{
			new Presence
			{
				Title = "Test presence",
				Data1 = "Test Data 1",
				Data2 = "Test Data 2"
			},
			new Presence
			{
				Title = "Here's another",
				Data1 = "Data 1 again",
				Data2 = "Data 2 again"
			}
		};

		public MainWindow()
		{
			InitializeComponent();
			UpdatePresenceDisplay();
		}

		private void UpdatePresenceDisplay()
		{
			foreach (var presence in _presences)
			{
				var titleText = new TextBlock
				{
					Text              = presence.Title,
					FontSize          = 18,
					Margin            = new Thickness(5, 0, 0, 0),
					VerticalAlignment = VerticalAlignment.Center
				};
				var data1Text = new TextBlock
				{
					Text              = presence.Data1,
					FontSize          = 18,
					Margin            = new Thickness(5, 0, 0, 0),
					VerticalAlignment = VerticalAlignment.Center
				};
				var data2Text = new TextBlock
				{
					Text              = presence.Data2,
					FontSize          = 18,
					Margin            = new Thickness(5, 0, 0, 0),
					VerticalAlignment = VerticalAlignment.Center
				};

				Grid.SetRow(data1Text, 1);
				Grid.SetRow(data2Text, 2);

				var activeButton = new Button
				{
					Content = "Make Active",
					Margin  = new Thickness(5)
				};
				var editButton = new Button
				{
					Content = "Edit",
					Margin  = new Thickness(5)
				};
				var deleteButton = new Button
				{
					Content = "Delete",
					Margin  = new Thickness(5)
				};

				Grid.SetColumn(activeButton, 1);
				Grid.SetColumn(editButton,   1);
				Grid.SetColumn(deleteButton, 1);
				Grid.SetRow(editButton,   1);
				Grid.SetRow(deleteButton, 2);

				var uiElement = new Border
				{
					BorderBrush     = Brushes.LightGray,
					BorderThickness = new Thickness(2),
					Margin          = new Thickness(5),
					Height          = 100,
					Width           = 400,
					Child = new Grid
					{
						ColumnDefinitions =
						{
							new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
							new ColumnDefinition {Width = GridLength.Auto}
						},
						RowDefinitions =
						{
							new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
							new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
							new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
						},
						Children =
						{
							titleText,
							data1Text,
							data2Text,
							activeButton,
							editButton,
							deleteButton
						}
					}
				};
				PanelPresenceList.Children.Add(uiElement);
			}
		}
	}

	public class Presence
	{
		public string Title;
		public string Data1;
		public string Data2;
	}
}