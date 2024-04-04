using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;


namespace MyPhotoshop.Effects;

public class DarkenEffect:IPhotoEffect
{
    private readonly string _description = "Oscurece la foto.";
    
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
                Byte darkerR = (Byte)Math.Max((r - 20), 0);
                Byte darkerG = (Byte)Math.Max((g - 20), 0);
                Byte darkerB= (Byte)Math.Max((b - 20), 0);
                darkImage[x, y] = new Rgb24(darkerR,darkerG,darkerB);
            }   
        }

        return darkImage;
    }
}