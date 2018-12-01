using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionSAT.CSL.WEB.SystemHelper
{
    public class QR
    {
        public QR() { }

        public static byte[] createBarCode(String Cadena)
        {

            byte[] array = null;
            byte[] array1 = null;


            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {

                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30f, 30f, 30f, 30f);
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms);
                doc.Open();

                var hints = new Dictionary<EncodeHintType, object>();
                hints.Add(EncodeHintType.ERROR_CORRECTION, iTextSharp.text.pdf.qrcode.ErrorCorrectionLevel.H);
                //Creamos el QR
                BarcodeQRCode qrcode = new BarcodeQRCode(Cadena, 1, 1, hints);
                Image qrcodeImage = qrcode.GetImage();
                qrcodeImage.SetAbsolutePosition(50, 500);
                qrcodeImage.ScalePercent(200);
                doc.Add(qrcodeImage);
                doc.Close();
                byte[] result = ms.ToArray();
                array = result;
            }


            try
            {
                System.Diagnostics.Debug.WriteLine("Wait for extracting image from PDF file....");

                // Get a List of Image
                List<System.Drawing.Image> ListImage = ExtractImages(array);

                for (int i = 0; i < ListImage.Count; i++)
                {
                    try
                    {

                        array1 = imageToByteArray(ListImage[i]);
                    }
                    catch (Exception)
                    { }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return array1;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private static List<System.Drawing.Image> ExtractImages(byte[] PDFSourcePath)
        {
            List<System.Drawing.Image> ImgList = new List<System.Drawing.Image>();

            iTextSharp.text.pdf.PdfReader PDFReaderObj = null;
            iTextSharp.text.pdf.PdfObject PDFObj = null;
            iTextSharp.text.pdf.PdfStream PDFStremObj = null;

            try
            {

                PDFReaderObj = new iTextSharp.text.pdf.PdfReader(PDFSourcePath, null);

                for (int i = 0; i <= PDFReaderObj.XrefSize - 1; i++)
                {
                    PDFObj = PDFReaderObj.GetPdfObject(i);

                    if ((PDFObj != null) && PDFObj.IsStream())
                    {
                        PDFStremObj = (iTextSharp.text.pdf.PdfStream)PDFObj;
                        iTextSharp.text.pdf.PdfObject subtype = PDFStremObj.Get(iTextSharp.text.pdf.PdfName.SUBTYPE);

                        if ((subtype != null) && subtype.ToString() == iTextSharp.text.pdf.PdfName.IMAGE.ToString())
                        {
                            try
                            {

                                iTextSharp.text.pdf.parser.PdfImageObject PdfImageObj =
                            new iTextSharp.text.pdf.parser.PdfImageObject((iTextSharp.text.pdf.PRStream)PDFStremObj);

                                System.Drawing.Image ImgPDF = PdfImageObj.GetDrawingImage();


                                ImgList.Add(ImgPDF);

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                PDFReaderObj.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ImgList;
        }
        /***************************/


    }
}
