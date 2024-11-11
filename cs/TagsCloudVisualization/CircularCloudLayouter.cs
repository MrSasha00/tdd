using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter(Point center) : ICircularCloudLayouter
{
	private double angle;
	private const double SpiralStep = 0.2;

	public Rectangle PutNextRectangle(Size rectangleSize, ICollection<Rectangle> rectangles)
	{
		Rectangle newRectangle;
		if (rectangles.Count == 0)
		{
			var rectangle = new Rectangle(center, rectangleSize);
			rectangles.Add(rectangle);
			return rectangle;
		}

		do
		{
			var location = GetLocation(rectangleSize);
			newRectangle = new Rectangle(location, rectangleSize);
		}
		while (IsIntersecting(newRectangle, rectangles));

		rectangles.Add(newRectangle);

		return newRectangle;
	}

	private Point GetLocation(Size rectangleSize)
	{
		var radius = SpiralStep * angle;
		var x = (int)(center.X + radius * Math.Cos(angle) - rectangleSize.Width / 2);
		var y = (int)(center.Y + radius * Math.Sin(angle) - rectangleSize.Height / 2);
		angle += 0.01;

		return new Point(x, y);
	}

	private bool IsIntersecting(Rectangle rectangle, ICollection<Rectangle> rectangles)
		=> rectangles.Any(existingRectangle => existingRectangle.IntersectsWith(rectangle));
}