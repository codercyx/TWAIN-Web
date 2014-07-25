﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace TwainWeb.Standalone.App
{
    public class ScanForm
    {
        public string FileName { get; set; }
        public string FileCounter { get; set; }
        public float DPI { get; set; }
        public CompressionFormat CompressionFormat { get; set; }
        public int ColorMode { get; set; }
        public int Source { get; set; }
        public string IsPackage { get; set; }
        public int SaveAs { get; set; }
        public FormatPage Format { get; set; }
    }

    public class CompressionFormat
    {
        private int _defaultCompression = 0;
        private ImageFormat _defaultImgFormat = ImageFormat.Jpeg;

        public CompressionFormat(string str)
        {
            if (str != null)
            {
                var indexSeparator = str.IndexOf("*");
                if (indexSeparator != -1)
                {
                    var keyImgFormat = str.Substring(indexSeparator+1);
                    int.TryParse(str.Substring(0, indexSeparator), out this._defaultCompression);
                    _defaultImgFormat = GlobalDictionaries.ImgFormats.ContainsKey(keyImgFormat) ? 
                        GlobalDictionaries.ImgFormats[keyImgFormat] : ImageFormat.Jpeg;
                }
            }
        }

        public int compression 
        {
            get
            {
                return this._defaultCompression;
            }
        }

        public ImageFormat ImgFormat
        {
            get
            {
                return this._defaultImgFormat;
            }
        }
    }
}
