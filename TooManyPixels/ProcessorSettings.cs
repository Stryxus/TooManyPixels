using System;
using System.IO;

namespace TooManyPixels
{
    internal class ProcessorSettings
    {
        public DirectoryInfo SourceDirectory { get; set; } = null;
        public DirectoryInfo DestinationDirectory { get; set; } = null;
        public bool IsRecurive { get; set; } = false;
        public bool UseAlphaFormatOnly { get; set; } = false;
        public bool OnlyPassSquareImages { get; set; } = false;
        public bool DownsizeLargerResolutionImages { get; set; } = false;
        public bool CopySkippedFiles { get; set; } = false;
        public int CompressionLevel { get; set; } = 0;
        public int TargetImageWidth { get; set; } = 0;
        public int TargetImageHeight { get; set; } = 0;
        public SupportedNonAlphaFileTypes ConvertToNonAlphaValue { get; set; } = 0;
        public SupportedAlphaFileTypes ConvertToAlphaValue { get; set; } = 0;
    }

    internal enum SupportedNonAlphaFileTypes
    {
        JPG, BMP
    }

    internal enum SupportedAlphaFileTypes
    {
        PNG, GIF
    }
}
