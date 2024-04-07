using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;


namespace MyPhotoshop.Effects;

public class BlurEffect :IPhotoEffect
{
    private readonly string _description = "Difumina la foto.";
    
    public string Description
    {
        get { return _description; }
    }
    
    public Image<Rgb24> Apply(Image<Rgb24> originalImage)
    {
        int width = originalImage.Width;
        int height = originalImage.Height;
        Image<Rgb24> bluredImage = new Image<Rgb24>(width, height); 
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

                int averageR = sumaR / contador;
                int averageG = sumaG / contador;
                int averageB = sumaB / contador;
                Byte bluredR = (Byte)averageR;
                Byte bluredG = (Byte)averageG;
                Byte bluredB = (Byte)averageB;
                bluredImage[x, y] = new Rgb24(bluredR,bluredG,bluredB);
            }   
        }

        return bluredImage;
    }
}