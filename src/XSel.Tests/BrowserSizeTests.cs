using NUnit.Framework;
using System;
using FluentAssertions;

namespace XSel.Tests
{
    public class BrowserSizeTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void BrowserSize_Parse_thorws_ArgumentNullException(string param)
        {
            Action act = () =>
            {
                BrowserSize.Parse(param);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [TestCase("max")]
        [TestCase("Max")]
        [TestCase("MAX")]
        [TestCase("Maximal")]
        public void BrowserSize_Parse_Returns_BrowserSizeMaximized(string param)
        {
            var result = BrowserSize.Parse(param);

            result.Should().BeOfType<BrowserSizeMaximized>();
        }

        [TestCase("10x10", 10, 10)]
        [TestCase("1028x768", 1028, 768)]
        public void BrowserSize_Parse_Returns_Resolution(string param, int x, int y)
        {
            var result = BrowserSize.Parse(param);

            result.X.Should().Be(x);
            result.Y.Should().Be(y);
        }

        [TestCase("10,5x70,8")]
        [TestCase("10.5x70.8")]
        public void BrowserSize_Parse_thorws_FormatException(string param)
        {
            Action act = () =>
            {
                BrowserSize.Parse(param);
            };

            act.Should().Throw<FormatException>();
        }

        [TestCase("5x5x70")]
        [TestCase("lala")]
        [TestCase("Strange10XText10")]
        public void BrowserSize_Parse_thorws_InvalidOperationException(string param)
        {
            Action act = () =>
            {
                BrowserSize.Parse(param);
            };

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void BrowserSize_DefaultValues()
        {
            var sut = new BrowserSize();
            sut.X.Should().Be(1920);
            sut.Y.Should().Be(1080);
        }

        [Test]
        public void BrowserSize_ToSize_Retunrs_Size()
        {
            var sut = new BrowserSize { X = 99, Y = 88 };

            var result = sut.ToSize();

            result.Should().BeOfType<System.Drawing.Size>();
            result.Height.Should().Be(sut.Y);
            result.Width.Should().Be(sut.X);
        }
    }
}
