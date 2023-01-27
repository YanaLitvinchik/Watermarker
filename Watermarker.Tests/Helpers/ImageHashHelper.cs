using System.Drawing;

namespace Watermarker.Test.Helpers;

public static class ImageHashHelper
{
    public static List<bool> GetHash(Bitmap bmpSource)
    {
        var result = new List<bool>();         
        var bmpMin = new Bitmap(bmpSource, new Size(16, 16));
        for (var j = 0; j < bmpMin.Height; j++)
        {
            for (var i = 0; i < bmpMin.Width; i++)
            {
                //reduce colors to true / false                
                var item = bmpMin.GetPixel(i, j).GetBrightness() < 0.5f;
                result.Add(item);
            }  
        }
        return result;
    }
}