using System.Drawing;
using System.Drawing.Imaging;
using Xunit;
using BetterStepsRecorder;

namespace BetterStepsRecorder.Tests
{
    public class ImageConversionTests
    {
        [Fact]
        public void Image_RoundTrip_Base64_Should_Preserve_Dimensions()
        {
            using var bmp = new Bitmap(8, 6);
            string base64 = Program.ImageToBase64(bmp, ImageFormat.Png);
            using var result = Program.Base64ToImage(base64);
            Assert.Equal(bmp.Width, result.Width);
            Assert.Equal(bmp.Height, result.Height);
        }

        [Fact]
        public void Base64ToImage_Should_NotThrow_For_Valid_Base64()
        {
            using var bmp = new Bitmap(2, 2);
            string base64 = Program.ImageToBase64(bmp, ImageFormat.Png);
            var exception = Record.Exception(() => Program.Base64ToImage(base64).Dispose());
            Assert.Null(exception);
        }
    }
}
