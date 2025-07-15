using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EncryptionManager.Views.Converters;

[ValueConversion(typeof(bool), typeof(SolidColorBrush))]
internal class BoolToColorConverter : BaseValueConverter<BoolToColorConverter>
{
	public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		=> System.Convert.ToBoolean(value) ? Brushes.ForestGreen : Brushes.IndianRed;

	public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}