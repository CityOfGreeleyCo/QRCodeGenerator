using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QR_Code_Generator.Models;
using ZXing;
using ZXing.Common;

namespace QR_Code_Generator.Controllers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString GenerateQrCode(this HtmlHelper html, string groupName, int height = 250,
            int width = 250, int margin = 0)
        {


            var qrValue = ((Codes) ((html.ViewData).Model)).Url;
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };

            using(var bitmap = barcodeWriter.Write(qrValue))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);

                var img = new TagBuilder("img");
                img.MergeAttribute("alt", "qr code");
                img.MergeAttribute("id", "qrcode");
                img.Attributes.Add("src",
                    String.Format("data:image/png;base64,{0}", Convert.ToBase64String(stream.ToArray())));
                return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
            }
        }
    }
}