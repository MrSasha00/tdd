using System.Drawing;
#pragma warning disable CA1416

namespace TagsCloudVisualization;

public static class CloudVisualiser
{
	public static void DrawAndSaveCloud(IEnumerable<Rectangle> rectangles, string path, string fileName, int imageWidth)
	{
		using var bitmap = new Bitmap(imageWidth, imageWidth);
		using var graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.White);

		var random = new Random();
		foreach (var rectangle in rectangles)
		{
			var color = Color.FromArgb(random.Next(100, 256), random.Next(100, 256), random.Next(100, 256));
			using var brush = new SolidBrush(color);
			graphics.FillRectangle(brush, rectangle);
			graphics.DrawRectangle(Pens.Black, rectangle);
		}

		bitmap.Save(Path.Combine(path, fileName + ".png"), System.Drawing.Imaging.ImageFormat.Png);
	}
}

#pragma warning restore CA1416