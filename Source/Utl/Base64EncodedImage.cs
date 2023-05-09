using System;
using System.IO;

namespace BioBooker.Utl
{
    public class Base64EncodedImage
    {
        // Helper method to generate image data from a file
        // Generates the byte array of image data from the specified image file path.
        public byte[] GenerateImageData(string imagePath)
        {
            byte[] imageData = File.ReadAllBytes(imagePath);
            return imageData;
        }
    }
}
