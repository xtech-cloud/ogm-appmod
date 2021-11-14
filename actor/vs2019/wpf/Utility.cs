using System.Windows.Controls;
using System.Windows.Media;

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
    }
}
