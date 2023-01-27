using System.Drawing;
using System.Drawing.Imaging;
using Watermarker.Interfaces;
using Watermarker.Utils;

namespace Watermarker;

/// <summary>
/// Class <c>ImageWatermark</c> for drawing a watermark image on other image.
/// </summary>
public class ImageWatermark : IDrawingWatermark
{
    /// <summary>
    /// An image to place on the input image.
    /// </summary>
    public Image Watermark { get; }

    /// <summary>
    /// Watermark position on the input image. Default value is a center of image.
    /// </summary>
    public WatermarkPosition Position { get; } = WatermarkPosition.Middle;

    /// <summary>
    /// Watermark scale in percent. Default value is 50%;
    /// </summary>
    public int Scale { get; } = 50;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageWatermark"/> class.
    /// </summary>
    /// <param name="watermark">An image to place on the input image.</param>
    /// <param name="position">A watermark position on the input image.</param>
    /// <param name="scale">A watermark scale.</param>
    /// <exception cref="ArgumentNullException">If there is no watermark.</exception>
    public ImageWatermark(Image watermark, WatermarkPosition position, int scale)
    {
        Watermark = watermark ?? throw new ArgumentNullException(nameof(watermark));
        Position = position;
        Scale = scale;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageWatermark"/> class with default values.
    /// </summary>
    /// <param name="watermark">An image to place on the input image.</param>
    public ImageWatermark(Image watermark)
    {
        Watermark = watermark;
    }

    /// <summary>
    /// Draws a watermark on image from input. 
    /// </summary>
    /// <param name="image">Image to be watermarked.</param>
    /// <returns>Image with watermark.</returns>
    /// <exception cref="ArgumentNullException">If input image is null.</exception>
    public Image Draw(Image image)
    {
        if (image == null) throw new ArgumentNullException(nameof(image));

        var imageWithWatermark = (Image) image.Clone();
        var size = CalculateWatermarkSize(image);

        var rectangle = new Rectangle(GetDestination(imageWithWatermark.Size, size, Position), size);

        using var resultFile = Graphics.FromImage(imageWithWatermark);
        var imageAttributes = new ImageAttributes();

        resultFile.DrawImage(Watermark, rectangle, 0, 0, Watermark.Width, Watermark.Height,
            GraphicsUnit.Pixel, imageAttributes, null, nint.Zero);

        resultFile.Save();

        return imageWithWatermark;
    }

    /// <summary>
    /// Calculate height and width of watermark based on image size and scale.
    /// </summary>
    /// <param name="image">Image to be watermarked.</param>
    /// <returns>Size of watermark.</returns>
    private Size CalculateWatermarkSize(Image image)
    {
        var watermarkHeight = image.Height * Scale / 100;
        var watermarkWidth = image.Width * Scale / 100;

        return new Size(watermarkWidth, watermarkHeight);
    }

    /// <summary>
    /// Method GetDestination calculates a point destination one image on another.
    /// </summary>
    /// <param name="originalSize">The original width and height of the image.</param>
    /// <param name="watermarkSize">The original width and height of the watermark.</param>
    /// <param name="position">A watermark position on original image.</param>
    /// <returns>A watermark coordinates on original image in Point type.</returns>
    private static Point GetDestination(Size originalSize, Size watermarkSize, WatermarkPosition position)
    {
        var destination = new Point();
 
        var originalWidth = originalSize.Width;
        var watermarkWidth = watermarkSize.Width;
        var originalHigth = originalSize.Height;
        var watermarkHeigth = watermarkSize.Height;

        if (position == WatermarkPosition.Middle)
        {
            destination.X = (originalWidth - watermarkWidth) / 2;
            destination.Y = (originalHigth - watermarkHeigth) / 2;
        }
        else if (position == WatermarkPosition.TopRight)
        {
            destination.X = originalWidth - watermarkWidth;
        }
        else if (position == WatermarkPosition.BottomLeft)
        { 
            destination.Y = originalHigth - watermarkHeigth;
        }
        else if (position == WatermarkPosition.BottomRight)
        {
            destination.X = originalWidth - watermarkWidth;
            destination.Y = originalHigth - watermarkHeigth;
        }
        else if (position == WatermarkPosition.TopLeft)
        {
            destination = new Point(0, 0);
        }

        return destination;
    }
}