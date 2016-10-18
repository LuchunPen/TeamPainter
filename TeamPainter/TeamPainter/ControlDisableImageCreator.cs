/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 20.07.2016 0:10:27
*/

using System;
using System.Drawing;

namespace TeamPainter
{
    public static class ControlHelper
    {
        public static Image CreateImage(Image sourceImage)
        {
            if (sourceImage == null) { return null; }

            Bitmap original = new Bitmap(sourceImage);
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = original.GetPixel(i, j);
                    if (originalColor.A > 128)
                    { 
                        //create the color object
                        Color newColor = Color.FromArgb(255, 100, 100, 100);
                        //set the new image's pixel to the grayscale version
                        newBitmap.SetPixel(i, j, newColor);
                    }
                    else { newBitmap.SetPixel(i, j, Color.Transparent); }
                }
            }

            return newBitmap;
        }
    }
}
