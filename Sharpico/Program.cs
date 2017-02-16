using System;
using System.Collections.Generic;
using FreeImageAPI;

namespace Sharpico
{
    internal class Program
    {
        private static readonly int[] Sizes =
        {
            256, // since Win7, largest allowed size as per wikipedia
            128, // probably gets used somewhere...
            64, // high DPI desktop displays
            48, // Windows XP standard, and most common size
            32, // initial icon size (since Windows 1.0)
            16 // smallest proper size, but valid sizes can go down to 1x1
        };

        public static void Main(string[] args)
        {
            var icoFile = args[1];
            var fiBitmap = new FreeImageBitmap(args[0]);

            var first = true;

            foreach (var size in Sizes)
            {
                if (fiBitmap.Width < size || fiBitmap.Height < size) continue;

                fiBitmap.Rescale(size, size, FREE_IMAGE_FILTER.FILTER_BICUBIC);
                if (first)
                {
                    first = false;
                    fiBitmap.Save(icoFile);
                }
                else
                {
                    fiBitmap.SaveAdd(icoFile);
                }
            }
        }
    }
}