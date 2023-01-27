using System.Drawing;
using Watermarker.Utils;

namespace Watermarker.Test;

[TestClass]
public class ImageWatermarkTest
{
    private const string WatermarkPath = "./data/watermark.jpg";
    private const int Scale = 50;
    private const string DefaultImagePath = "./data/test.jpg";

    [DataTestMethod]
    [DataRow("jpg")]
    [DataRow("png")]
    [DataRow("tiff")]
    public void ShouldDrawWatermarkOnImage(string expectedExtention)
    {
        var pathImage = $"./data/test.{expectedExtention}";
        var pathReadyImage =
            $"./data/results_image_watermarker/extensions/res_extension_{expectedExtention}.{expectedExtention}";

        var originalImage = Image.FromFile(pathImage);
        var watermark = Image.FromFile(WatermarkPath);
        var resultImage = Image.FromFile(pathReadyImage);

        var imageWithWatermark = new ImageWatermark(watermark).Draw(originalImage);

        ImageAssert.AreEqual(imageWithWatermark, resultImage);
    }

    [DataTestMethod]
    [DataRow(20)]
    [DataRow(50)]
    [DataRow(80)]
    public void ShouldDrawWatermarkOnImageByScale(int expectedScale)
    {
        var imageToComparePath = $"./data/results_image_watermarker/scales/scale_{expectedScale}.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, WatermarkPosition.Middle, expectedScale)
            .Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void ShouldDrawWatermarkInImageCenter()
    {
        var expectedPosition = WatermarkPosition.Middle;
        const string imageToComparePath = "./data/results_image_watermarker/positions/pos_middle.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, expectedPosition, Scale).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void ShouldDrawWatermarkInBottomLeftCornerOfImage()
    {
        var expectedPosition = WatermarkPosition.BottomLeft;
        const string imageToComparePath = "./data/results_image_watermarker/positions/pos_bottom_left.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, expectedPosition, Scale).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void ShouldDrawWatermarkInTopLeftCornerOfImage()
    {
        var expectedPosition = WatermarkPosition.TopLeft;
        const string imageToComparePath = "./data/results_image_watermarker/positions/pos_top_left.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, expectedPosition, Scale).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void ShouldDrawWatermarkInTopRightCornerOfImage()
    {
        var expectedPosition = WatermarkPosition.TopRight;
        const string imageToComparePath = "./data/results_image_watermarker/positions/pos_top_rigth.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, expectedPosition, Scale).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void ShouldDrawWatermarkInBottomRigthCornerOfImage()
    {
        var expectedPosition = WatermarkPosition.BottomRight;
        const string imageToComparePath = "./data/results_image_watermarker/positions/pos_bottom_rigth.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark, expectedPosition, Scale).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }

    [TestMethod]
    public void DrawWatermarkOnImageWithDefaultParameters()
    {
        const string imageToComparePath = "./data/results_image_watermarker/default.jpg";

        var originalImage = Image.FromFile(DefaultImagePath);
        var watermark = Image.FromFile(WatermarkPath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new ImageWatermark(watermark).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
}