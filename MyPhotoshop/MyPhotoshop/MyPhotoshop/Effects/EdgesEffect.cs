using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace MyPhotoshop.Effects;

public class EdgesEffect:IPhotoEffect
{
    private readonly string _description = "Muestra los bordes de la foto.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> edgesImage = new Image<Rgb24>(width, height); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int contador = 0;
                int sumaR = 0;
                int sumaG = 0;
                int sumaB = 0;
                for (int deltaX = -1; deltaX < 2; deltaX++)
                {
                    for (int deltaY = -1; deltaY < 2; deltaY++)
                    {
                        if (x + deltaX >= 0 && y + deltaY >= 0 && x + deltaX < width && y + deltaY < height)
                        {
                            contador++;
                            sumaR += originalImage[x + deltaX, y + deltaY].R;
                            sumaG += originalImage[x + deltaX, y + deltaY].G;
                            sumaB += originalImage[x + deltaX, y + deltaY].B;
                        }
                    }
                }
                
                int r = originalImage[x, y].R;
                int g = originalImage[x, y].G;
                int b = originalImage[x, y].B;

                int averageR = contador*r - sumaR;
                int averageG = contador*g - sumaG;
                int averageB = contador*b - sumaB;
                Byte edgesR = (Byte)averageR;
                Byte edgesG = (Byte)averageG;
                Byte edgesB = (Byte)averageB;
                edgesImage[x, y] = new Rgb24(edgesR,edgesG,edgesB);
            }   
        }

        return edgesImage;
    }
}