using System.Drawing;
using Watermarker.Test.Helpers;

namespace Watermarker.Test;

[TestClass]  
public class ImageAssert  
{  
    //Compares two images pixel by pixel.
    public static void AreEqual(Image original, Image modified)
    {
        var originalImageHash = ImageHashHelper.GetHash(new Bitmap(original));
        var modifiedImageHash = ImageHashHelper.GetHash(new Bitmap(modified));

        //determine the number of equal pixel (x of 256)
        var equalElements = originalImageHash.Zip(modifiedImageHash, (i, j) => i == j).Count(eq => eq);

        const int pixels = 256;
        
        Assert.AreEqual(equalElements, pixels);  
    }
}