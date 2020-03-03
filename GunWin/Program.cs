using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommandLine;

using Org.Edgerunner.ANTLR.Tools.Testing;

namespace GunWin
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      /// <param name="args">The arguments.</param>
      [STAThread]
      static void Main(string[] args)
      {
         var encoding = string.Empty;
         var runWithDiagnostics = false;

         Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                      {
                         if (!string.IsNullOrEmpty(o.EncodingName))
                            encoding = o.EncodingName;
                         if (o.Diagnostics) ;
                      });
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new VisualAnalyzer());
      }
   }
}
