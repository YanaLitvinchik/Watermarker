namespace Watermarker.Utils;

/// <summary>
/// Class <c>WatermarkPosition</c> describes watermark position on image.
/// </summary>
public class WatermarkPosition
{
    /// <summary>
    /// Top left corner of image.
    /// </summary>
    public static readonly WatermarkPosition TopLeft = new("TopLeft");
    /// <summary>
    /// Top rigth corner of image.
    /// </summary>
    public static readonly WatermarkPosition TopRight = new("TopRight");
    /// <summary>
    /// Bottom left corner of image.
    /// </summary>
    public static readonly WatermarkPosition BottomLeft = new("BottomLeft");
    /// <summary>
    /// Bottom rigth corner of image.
    /// </summary>
    public static readonly WatermarkPosition BottomRight = new("BottomRight");
    /// <summary>
    /// Center of image.
    /// </summary>
    public static readonly WatermarkPosition Middle = new("Middle");

    private string Position { get; }

    private WatermarkPosition(string position)
    {
        Position = position;
    }
}