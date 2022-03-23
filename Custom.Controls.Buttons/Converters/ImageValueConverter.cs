using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Custom.Controls.Buttons.Converters
{
    public class ImageValueConverter : IMultiValueConverter
    {
        private const int ImageWidth = 24;
        private const int ImageHeight = 24;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ButtonControl.ImageCategory category = (ButtonControl.ImageCategory)values[0];
            var image = (BitmapSource)values[2];
            int col = (int) values[1];

            switch (category)
            {
                case ButtonControl.ImageCategory.NewPatient:
                    return new CroppedBitmap(image, new Int32Rect(0 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.EditPatient:
                    return new CroppedBitmap(image, new Int32Rect(1 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.DeletePatient:
                    return new CroppedBitmap(image, new Int32Rect(2 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.ImportWorkList:
                    return new CroppedBitmap(image, new Int32Rect(3 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Anonymize:
                    return new CroppedBitmap(image, new Int32Rect(4 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.NewStudy:
                    return new CroppedBitmap(image, new Int32Rect(5 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.EditStudy:
                    return new CroppedBitmap(image, new Int32Rect(1 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.DeleteStudy:
                    return new CroppedBitmap(image, new Int32Rect(2 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Reports:
                    return new CroppedBitmap(image, new Int32Rect(6 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Reconstruct:
                    return new CroppedBitmap(image, new Int32Rect(7 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.View:
                    return new CroppedBitmap(image, new Int32Rect(8 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.SaveToCd:
                    return new CroppedBitmap(image, new Int32Rect(9 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.DeleteReport:
                    return new CroppedBitmap(image, new Int32Rect(2 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Archive:
                    return new CroppedBitmap(image, new Int32Rect(10 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.ExportList:
                    return new CroppedBitmap(image, new Int32Rect(11 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Restore:
                    return new CroppedBitmap(image, new Int32Rect(12 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.Applications:
                    return new CroppedBitmap(image, new Int32Rect(13 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                case ButtonControl.ImageCategory.DataQc:
                    return new CroppedBitmap(image, new Int32Rect(14 * ImageWidth, col * ImageHeight, ImageWidth, ImageHeight));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
