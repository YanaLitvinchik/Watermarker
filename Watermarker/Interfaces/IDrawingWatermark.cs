using System.Drawing;

namespace Watermarker.Interfaces;

/// <summary>
/// Interface for classes capable of drawing images on other images.
/// </summary>
public interface IDrawingWatermark
{
    /// <summary>
    /// Draws an image on input image.
    /// </summary>
    /// <param name="image">Image to be watermarked.</param>
    /// <returns>Image with watermark.</returns>
    Image Draw(Image image);
}