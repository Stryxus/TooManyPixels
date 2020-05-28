using System;
using System.IO;

namespace TooManyPixels
{
    internal struct ProcessorSettings
    {
        public DirectoryInfo SourceDirectory { get; set; }
        public DirectoryInfo DestinationDirector { get; set; }
        public bool IsRecurive { get; set; }
        public bool UseAlphaFormatOnly { get; set; }
        public bool OnlyPassSquareImages { get; set; }
        public bool DownsizeLargerResolutionImages { get; set; }
        public bool CopySkippedFiles { get; set; }
        public int CompressionLevel { get; set; }
        public int TargetImageWidth { get; set; }
        public int TargetImageHeight { get; set; }
        public SupportedNonAlphaFileTypes ConvertToNonAlphaValue { get; set; }
        public SupportedAlphaFileTypes ConvertToAlphaValue { get; set; }
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
