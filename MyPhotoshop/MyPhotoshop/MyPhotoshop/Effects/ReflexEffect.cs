using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace MyPhotoshop.Effects;

public class ReflexEffect:IPhotoEffect
{
    private readonly string _description = "Refleja la imagen en torno al eje Y.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        
        Image<Rgb24> rotatedImage = new Image<Rgb24>(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Rgb24 pixelColor = originalImage[x, y];
                
                List<int> nuevaPosicion = new List<int> { -(x - width/2) + width/2, y };
                
                if (nuevaPosicion[0] >= 0 && nuevaPosicion[0] < width && nuevaPosicion[1] >= 0 && nuevaPosicion[1] < height)
                {
                    rotatedImage[nuevaPosicion[0], nuevaPosicion[1]] = pixelColor;
                }
            }
        }

        return rotatedImage;
    }
}