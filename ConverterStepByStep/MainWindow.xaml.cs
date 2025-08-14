using System.Windows;
using System.Windows.Input;

namespace ConverterStepByStep;

public partial class MainWindow : Window
{
	private readonly bool _catchErrors = true;

	public MainWindow()
		=> InitializeComponent();

	private void OnBtnConvertClick(object sender, RoutedEventArgs e)
		=> ConvertNumber();

	private void Window_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			ConvertNumber();
		}
	}

	private void ConvertNumber()
	{
		try
		{
			int number = int.Parse(BaseNumber.Text);
			TxtBinSteps.Text = TxtOctSteps.Text = TxtHexSteps.Text = string.Empty;
			ConvertToBin(number);
			ConvertToOct(number);
			ConvertToHex(number);
		}
		catch (Exception ex) when (_catchErrors)
		{
			BaseNumber.Text = "ERRORRRRRRR!!!";
			_ = MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

	private void ConvertToBin(int number)
	{
		string result = string.Empty;
		int counter = 0;
		do
		{
			TxtBinSteps.Text += $"{number} / 2 = ";
			int remainder = number % 2;
			result = remainder.ToString() + result;
			number /= 2;
			TxtBinSteps.Text += $"{number} reszta {remainder}\n";
			counter++;
			if (counter % 4 == 0)
			{
				result = " " + result;
			}
		} while (number > 0);
		BinNumber.Text = result;
	}

	private void ConvertToOct(int number)
	{
		string result = string.Empty;
		int counter = 0;
		do
		{
			TxtOctSteps.Text += $"{number} / 8 = ";
			int remainder = number % 8;
			result = remainder.ToString() + result;
			number /= 8;
			TxtOctSteps.Text += $"{number} reszta {remainder}\n";
			counter++;
			if (counter % 3 == 0)
			{
				result = " " + result;
			}
		} while (number > 0);
		OctNumber.Text = result;
	}

	private void ConvertToHex(int number)
	{
		string result = string.Empty;
		int counter = 0;
		do
		{
			TxtHexSteps.Text += $"{number} / 16 = ";
			int remainder = number % 16;
			number /= 16;
			TxtHexSteps.Text += $"{number} reszta {remainder}";

			if (remainder > 9)
			{
				string letter = remainder switch
				{
					10 => "A",
					11 => "B",
					12 => "C",
					13 => "D",
					14 => "E",
					15 => "F",
					_ => string.Empty
				};

				result = letter + result;
				TxtHexSteps.Text += $" ({letter})\n";
			}
			else
			{
				result = remainder.ToString() + result;
				TxtHexSteps.Text += Environment.NewLine;
			}
			counter++;
			if (counter % 4 == 0)
			{
				result = " " + result;
			}
		} while (number > 0);
		HexNumber.Text = result;
	}
}