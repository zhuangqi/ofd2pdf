using Spire.Pdf;
using Spire.Pdf.Conversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofd2Pdf
{
    public enum ConvertResult
    {
        Successful,
        Failed
    }
    public class Converter
    {
        public ConvertResult ConvertToPdf(string Input, string OutPut)
        {
            Console.WriteLine(Input + " " + OutPut);
            if (Input == null || OutPut == null)
            {
                return ConvertResult.Failed;
            }

            if (!File.Exists(Input))
            {
                return ConvertResult.Failed;
            }

            try
            {
                OfdConverter converter = new OfdConverter(Input);
                converter.ToPdf(OutPut);
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(OutPut);
                PdfPageBase page = pdf.Pages.Add();
                pdf.Pages.Remove(page);
                pdf.SaveToFile(OutPut);
                pdf.Close();

                return ConvertResult.Successful;
            }
            catch (Exception)
            {
                return ConvertResult.Failed;
            }
        }

        public ConvertResult ConvertToOfd(string Input, string OutPut)
        {
            Console.WriteLine(Input + " " + OutPut);
            if (Input == null || OutPut == null)
            {
                return ConvertResult.Failed;
            }

            if (!File.Exists(Input))
            {
                return ConvertResult.Failed;
            }

            try
            {
                // 尝试使用 Spire.Pdf 进行 PDF -> OFD 转换。若当前版本不支持，将会抛出异常。
                var pdf = new Spire.Pdf.PdfDocument();
                pdf.LoadFromFile(Input);
                PdfPageBase page = pdf.Pages.Add();
                pdf.Pages.Remove(page);
                pdf.SaveToFile(OutPut, Spire.Pdf.FileFormat.OFD);
                pdf.Close();
                return ConvertResult.Successful;
            }
            catch (Exception)
            {
                return ConvertResult.Failed;
            }
        }
    }
}
