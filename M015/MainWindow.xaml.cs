using System;
using System.Windows;
using System.Windows.Controls;

namespace M015
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CB.ItemsSource = new string[] { "Item1", "Item2", "Item3" };
			LB.ItemsSource = new string[] { "Item1", "Item2", "Item3" };
		}

		private void EinButtonClicked(object sender, RoutedEventArgs e)
		{
			MessageBoxResult res = MessageBox.Show("Der Button wurde geklickt", "Button gedrückt", MessageBoxButton.OK, MessageBoxImage.Information);
			if (res == MessageBoxResult.OK)
			{
				Test t = new Test();
				//t.Show();
				if (t.ShowDialog() == true)
				{
					Close();
				}
				else
				{

				}
			}
		}

		private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			TB.Text = cb.SelectedValue.ToString();
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			TB.Text = "Checkbox checked";
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			TB.Text = "Checkbox unchecked";
		}
	}
}
