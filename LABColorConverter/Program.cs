using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABColorConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Red L*ab value is: ");
            ConvertRGBToLAB(255, 0, 0);
            Console.WriteLine("Green L*ab value is: ");
            ConvertRGBToLAB(0, 128, 0);
            Console.WriteLine("Yellow L*ab value is: ");
            ConvertRGBToLAB(255, 255, 0);
            Console.WriteLine("Blue L*ab value is: ");
            ConvertRGBToLAB(0, 0, 255);
            Console.WriteLine("Orange L*ab value is: ");
            ConvertRGBToLAB(255, 165, 0);
            Console.WriteLine("Pink L*ab value is: ");
            ConvertRGBToLAB(255, 192, 203);
            Console.WriteLine("Teal L*ab value is: ");
            ConvertRGBToLAB(0, 128, 128);
            Console.WriteLine("Purple L*ab value is: ");
            ConvertRGBToLAB(128, 0, 128);
            Console.ReadKey();
            Console.WriteLine("Brown L*ab value is: ");
            ConvertRGBToLAB(165, 42, 42);
            Console.WriteLine("Yellow L*ab value is: ");
            ConvertRGBToLAB(128, 128, 128);
            Console.WriteLine("Black L*ab value is: ");
            ConvertRGBToLAB(0, 0, 0);
            Console.WriteLine("White L*ab value is: ");
            ConvertRGBToLAB(255, 255, 255);
        }

        private static void ConvertRGBToLAB(double red, double green, double blue)
        {
            red /= 255;
            green /= 255;
            blue /= 255;

            //making the RGB values linear and in the nominal range b/t 0.0 and 1.0
            if (red > 0.04045)
                red = Math.Pow(((red + 0.055) / 1.055), 2.4);
            else
                red = red / 12.92;

            if (green > 0.04045)
                green = Math.Pow(((green + 0.055) / 1.055), 2.4);
            else
                green = green / 12.92;

            if (blue > 0.04045)
                blue = Math.Pow(((blue + 0.055) / 1.055), 2.4);
            else
                blue = blue / 12.92;

            red *= 100;
            green *= 100;
            blue *= 100;

            //converting to XYZ color space
            double x, y, z;
            x = red * 0.4124 + green * 0.3576 + blue * 0.1805;
            y = red * 0.2126 + green * 0.7152 + blue * 0.0722;
            z = red * 0.0193 + green * 0.1192 + blue * 0.9505;

            //finally, converting XYZ color space to CIE-L*ab color space
            x /= 95.047;
            y /= 100;
            z /= 108.883;

            if (x > 0.008856)
                x = Math.Pow(x, (.3333333333));
            else
                x = (7.787 * x) + (16 / 116);

            if (y > 0.008856)
                y = Math.Pow(y, (.3333333333));
            else
                y = (7.787 * y) + (16 / 116);

            if (z > 0.008856)
                z = Math.Pow(z, (.3333333333));
            else
                z = (7.787 * z) + (16 / 116);

            //last step
            double L, a, b;
            L = (116 * y) - 16;
            a = 500 * (x - y);
            b = 200 * (y - z);

            Console.WriteLine("L: " + L + "\r\na: " + a + "\r\nb: " + b);
        }
    }
}
