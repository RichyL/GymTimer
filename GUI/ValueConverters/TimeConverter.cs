using System.Globalization;

namespace GUI.ValueConverters
{
	internal class TimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is int) ) { return value; }

			int numberToConvert = (int) value;

			if (numberToConvert == 0) return "00:00:00";

			int hours = numberToConvert / 3600;
			int minutes = (numberToConvert - (hours * 3600)) / 60;
			
			int seconds = numberToConvert - ( (hours * 3600) + ( minutes * 60 ) );

			string textHours = hours.ToString();
			textHours = textHours.PadLeft(2, '0');

			string textMinutes = minutes.ToString();
			textMinutes = textMinutes.PadLeft(2,'0');

			string textSeconds = seconds.ToString();
			textSeconds = textSeconds.PadLeft(2,'0');


			return $"{textHours}:{textMinutes}:{textSeconds}";
			

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
