using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            List<Vector2u> textureResolutions = new List<Vector2u>();  // List of texture resolutions to use for testing.
            List<uint> sizes = new List<uint>() { 2, 4, 8, 16, 64, 128, 258, 512, 768 };  // List of texture dimensions to use (over x and/or y axis).

            // Generate image sizes
            foreach (uint sizeX in sizes) {
                foreach (uint sizeY in sizes) {
                    textureResolutions.Add(new Vector2u(sizeX, sizeY));
                }
            }

            Console.WriteLine("Image of size (x, y) had # non-zero pixels in it. (Out of # total pixels.)");  // Print format.
            foreach (Vector2u size in textureResolutions) {
                Texture texture = new Texture(size.X, size.Y);  // You'd expect a newly created texture would be empty right?
                Image image = texture.CopyToImage();  // Well, let us check!

                uint nonZeroedPixels = 0;  // Number of pixels found that had a non-zero value.
                for (uint y = 0; y < image.Size.Y; ++y) {
                    for (uint x = 0; x < image.Size.X; ++x) {
                        Color pixel = image.GetPixel(x, y);
                        if (pixel.R != 0 || pixel.G != 0 || pixel.B != 0 || pixel.A != 0) {
                            ++nonZeroedPixels;
                        }
                    }
                }
                Console.WriteLine("({0}, {1})\t\t{2} / {3}", texture.Size.X, texture.Size.Y, nonZeroedPixels, texture.Size.X * texture.Size.Y);
            }
            Console.WriteLine("Done!");

            while (true) {  // When done, don't close the output yet, just dilly-dally untill closed (so the user can read the results).
                Thread.Sleep(1);
            }
        }
    }
}
