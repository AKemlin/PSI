using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "chemin/vers/image/source.bmp";
        string outputPath = "chemin/vers/image/destination.bmp";

        // Lire l'image
        using (Bitmap originalBitmap = new Bitmap(inputPath))
        {
            // Conversion en nuances de gris
            Bitmap grayScaleBitmap = ConvertToGrayscale(originalBitmap);

            // Sauvegarde de l'image modifiée
            grayScaleBitmap.Save(outputPath);
        }
    }

    static Bitmap ConvertToGrayscale(Bitmap originalBitmap)
    {
        Bitmap grayScaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

        for (int i = 0; i < originalBitmap.Width; i++)
        {
            for (int j = 0; j < originalBitmap.Height; j++)
            {
                Color originalColor = originalBitmap.GetPixel(i, j);

                // Calcul de la luminance
                int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));
                Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);

                grayScaleBitmap.SetPixel(i, j, grayColor);
            }
        }

        return grayScaleBitmap;
    }
}

