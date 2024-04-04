using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace MyPhotoshop.Effects;

public class RotateEffect:IPhotoEffect
{
    private readonly string _description = "Rota la foto 90° a la derecha.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        
        var centroImagen = new List<int> { width / 2, height / 2 };
        
        Image<Rgb24> rotatedImage = new Image<Rgb24>(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Rgb24 pixelColor = originalImage[x, y];
                
                int deltaX = x - centroImagen[0];
                int deltaY = y - centroImagen[1];
                
                List<int> nuevaPosicion = new List<int> { -deltaY + centroImagen[0], deltaX + centroImagen[1] };
                
                if (nuevaPosicion[0] >= 0 && nuevaPosicion[0] < width && nuevaPosicion[1] >= 0 && nuevaPosicion[1] < height)
                {
                    rotatedImage[nuevaPosicion[0], nuevaPosicion[1]] = pixelColor;
                }
            }
        }

        return rotatedImage;
    }
}