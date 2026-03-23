using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ofd2Pdf
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                Converter converter = new Converter();
                bool hasFailed = false;

                string cmd = args[0].ToLowerInvariant();
                if (cmd == "ofd2pdf" || cmd == "pdf2ofd")
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        string input = args[i];
                        string output;
                        ConvertResult result;

                        if (cmd == "ofd2pdf")
                        {
                            output = Path.ChangeExtension(input, ".pdf");
                            result = converter.ConvertToPdf(input, output);
                        }
                        else
                        {
                            output = Path.ChangeExtension(input, ".ofd");
                            result = converter.ConvertToOfd(input, output);
                        }

                        if (result == ConvertResult.Failed)
                        {
                            Console.WriteLine($"[Failed] {cmd}: {input}");
                            hasFailed = true;
                        }
                        else
                        {
                            Console.WriteLine($"[Success] {cmd}: {input} -> {output}");
                        }
                    }
                }
                else
                {
                    // 保留旧版兼容性：默认处理 OFD -> PDF
                    for (int i = 0; i < args.Length; i++)
                    {
                        string input = args[i];
                        string output = Path.ChangeExtension(input, ".pdf");
                        var result = converter.ConvertToPdf(input, output);

                        if (result == ConvertResult.Failed)
                        {
                            Console.WriteLine("[Failed]: " + input);
                            hasFailed = true;
                        }
                        else
                        {
                            Console.WriteLine("[Success]: " + input);
                        }
                    }
                }

                Environment.Exit(hasFailed ? 1 : 0);
            }
        }
    }
}
