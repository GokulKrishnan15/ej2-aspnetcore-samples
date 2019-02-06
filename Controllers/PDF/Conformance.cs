#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /Conformance/

        public ActionResult Conformance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Conformance(string InsideBrowser)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Create a new PDF document
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);

            //Add a page
            PdfPage page = document.Pages.Add();

            //Create font
            FileStream fontFileStream = new FileStream(dataPath + "arial.ttf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            PdfFont font = new PdfTrueTypeFont(fontFileStream, 14);

            //Text to draw
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfPen pen = new PdfPen(new PdfColor(0, 0, 0));
            RectangleF rect = new RectangleF(0, 0, page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height);

            //Set the property text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
            format.ParagraphIndent = 35f;

            //Draw text.
            page.Graphics.DrawString(text, font, brush, rect, format);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close();
            stream.Position = 0;
            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "PDF_A1b.pdf";
            return fileStreamResult;
        }

    }
}
