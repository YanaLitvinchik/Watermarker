using System.Drawing;
using Watermarker.Interfaces;

namespace Watermarker;

/// <summary>
/// Class <c>TextWatermark</c> for drawing text on other image.
/// </summary>
public class TextWatermark : IDrawingWatermark
{
    /// <summary>
    /// Text to place on the input image.
    /// </summary>
    public string Watermark { get; }

    /// <summary>
    /// Font name of watermark text. Default value is Arial.
    /// </summary>
    public string Font { get; } = "Arial";

    /// <summary>
    /// Font size of watermark text. Default value is 20.
    /// </summary>
    public float FontSize { get; } = 20;

    /// <summary>
    /// Font style of watermark text. Default value is Regular.
    /// </summary>
    public FontStyle FontStyle { get; } = FontStyle.Regular;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextWatermark"/> class.
    /// </summary>
    /// <param name="watermark">Text to place on the input image.</param>
    /// <param name="font">Font name of watermark text.</param>
    /// <param name="fontSize">Font size of watermark text.</param>
    /// <param name="fontStyle">Font style of watermark text.</param>
    /// <exception cref="ArgumentNullException">If there is no watermark.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If font size less then zero.</exception>
    public TextWatermark(string watermark, string font, float fontSize, FontStyle fontStyle)
    {
        Watermark = string.IsNullOrEmpty(watermark) ? throw new ArgumentNullException(nameof(watermark)) : watermark;
        Font = string.IsNullOrEmpty(font) ? Font : font;
        FontSize = fontSize > 0
            ? fontSize
            : throw new ArgumentOutOfRangeException(nameof(fontSize), "font size must be greater then zero");
        FontStyle = fontStyle;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TextWatermark"/> class with default values.
    /// </summary>
    public TextWatermark(string watermark)
    {
        Watermark = watermark;
    }

    /// <summary>
    /// Draws a watermark on image from input. 
    /// </summary>
    /// <param name="image">Image to be watermarked.</param>
    /// <returns>Image with text watermark.</returns>
    /// <exception cref="ArgumentNullException">If input image is null.</exception>
    public Image Draw(Image image)
    {
        if (image == null) throw new ArgumentNullException(nameof(image));

        var imageWithWatermark = (Image)image.Clone();

        var graphics = Graphics.FromImage(imageWithWatermark);
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        var font = new Font(Font, FontSize, FontStyle);
        var strFormat = new StringFormat();
        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Center;

        var layoutRectangle = new RectangleF(0, 0, imageWithWatermark.Width, imageWithWatermark.Height);
        graphics.DrawString(Watermark, font, Brushes.Black, layoutRectangle, strFormat);

        return imageWithWatermark;
    }
}