using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace MyPhotoshop.Effects;

public class LightenImage:IPhotoEffect
{
    private readonly string _description = "Aclara la foto.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> darkImage = new Image<Rgb24>(width, height); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int r = originalImage[x, y].R;
                int g = originalImage[x, y].G;
                int b = originalImage[x, y].B;
                Byte darkerR = (Byte)Math.Min((r + 20), 255);
                Byte darkerG = (Byte)Math.Min((g + 20), 255);
                Byte darkerB= (Byte)Math.Min((b + 20), 255);
                darkImage[x, y] = new Rgb24(darkerR,darkerG,darkerB);
            }   
        }

        return darkImage;
    }
}