using System.Drawing;

namespace Watermarker.Test;

[TestClass]
public class TextWatermarkTest
{
    private const string DefaultImagePath = "./data/test.jpg";
    private const string Watermark = "DRAFT DRAFT DRAFT";
    private const string DefaultFont = "Arial";
    private const float DefaultFontSize = 20;

    [DataTestMethod]
    [DataRow(FontStyle.Bold)]  
    [DataRow(FontStyle.Italic)] 
    public void ShouldDrawWatermarkOnImageByFontStyle(FontStyle expectedFontStyle)
    {
        var styleNameForPath = expectedFontStyle.ToString().ToLower();
        var imageToComparePath = $"./data/results_text_watermarker/font_styles/{styleNameForPath}.jpg";
        
        var originalImage = Image.FromFile(DefaultImagePath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new TextWatermark(Watermark, DefaultFont, DefaultFontSize, expectedFontStyle)
            .Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
    
    [DataTestMethod]
    [DataRow(30)]  
    [DataRow(50)] 
    public void ShouldDrawWatermarkOnImageByFontSize(float expectedFontSize)
    {
        var imageToComparePath = $"./data/results_text_watermarker/font_sizes/size_{expectedFontSize}.jpg";
        
        var originalImage = Image.FromFile(DefaultImagePath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new TextWatermark(Watermark, DefaultFont, expectedFontSize, FontStyle.Bold)
            .Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
    
    [DataTestMethod]
    [DataRow("Consolas")]  
    [DataRow("Times New Roman")] 
    public void ShouldDrawWatermarkOnImageByFont(string expectedFont)
    {
        var fontForPath = expectedFont.Replace(" ", "_").ToLower();
        var imageToComparePath = $"./data/results_text_watermarker/fonts/{fontForPath}.jpg";
        
        var originalImage = Image.FromFile(DefaultImagePath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        var imageWithWatermark = new TextWatermark(Watermark, expectedFont, DefaultFontSize, FontStyle.Bold)
            .Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
    
    [TestMethod]  
    public void DrawTextOnImageWithInputCustomParameters()
    {
        const string imageToComparePath = "./data/results_text_watermarker/custom.jpg";
        
        var originalImage = Image.FromFile(DefaultImagePath);
        var imageToCompare = Image.FromFile(imageToComparePath);

        const string watermark = "DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT";
        const string font = "Times New Roman";
        const float fontSize = 70f;
        const FontStyle style = FontStyle.Bold;
        
        var imageWithWatermark = new TextWatermark(watermark, font, fontSize, style).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
    
    [TestMethod]  
    public void DrawTextOnImageWithDefaultParameters()
    {
        const string imageToComparePath = "./data/results_text_watermarker/default.jpg";
        
        var originalImage = Image.FromFile(DefaultImagePath);
        var imageToCompare = Image.FromFile(imageToComparePath);
        
        var imageWithWatermark = new TextWatermark(Watermark).Draw(originalImage);

        ImageAssert.AreEqual(imageToCompare, imageWithWatermark);
    }
}