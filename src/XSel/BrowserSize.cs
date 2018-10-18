using System;
using System.Collections.Generic;
using System.Text;

namespace XSel
{
    public class BrowserSize
    {
        public static BrowserSize Parse(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentNullException("format");

            var invariantFormat = format.ToLowerInvariant();

            if (invariantFormat.Contains("max"))
            {
                return new BrowserSizeMaximized();
            }
            else
            {
                var sizeAbsAsString = invariantFormat.Split('x');

                if (sizeAbsAsString.Length != 2)
                    throw new InvalidOperationException("BrowserSize must be in format '1024x648'.");

                int x = int.Parse(sizeAbsAsString[0]);
                int y = int.Parse(sizeAbsAsString[1]);

                return new BrowserSize { X = x, Y = y };
            }
        }

        public int X { get; set; } = 1920;

        public int Y { get; set; } = 1080;

        public System.Drawing.Size ToSize()
        {
            return new System.Drawing.Size(X, Y);
        }
    }

    public class BrowserSizeMaximized : BrowserSize { }
}
