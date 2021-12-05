using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ogm.actor
{
    public class Utility
    {
        public static ImageSource GeometrySourceFromResource(UserControl _control, string _key, Color _color)
        {
            var geometry = _control.FindResource(_key) as Geometry;
            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = geometry;
            aGeometryDrawing.Brush = new SolidColorBrush(_color);
            aGeometryDrawing.Pen = new Pen();
            DrawingImage drawingImage = new DrawingImage(aGeometryDrawing);
            drawingImage.Freeze();
            return drawingImage;
        }

        public static ImageSource ImageFromBytes(byte[] _bytes)
        {
            using (var ms = new System.IO.MemoryStream(_bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    }
}
