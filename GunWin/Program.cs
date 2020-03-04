using System;
using System.Windows.Forms;

using CommandLine;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
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
         var grammarName = string.Empty;
         var grammarRule = string.Empty;
         var encoding = string.Empty;
         var visualAnalyzer = new VisualAnalyzer();

         Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                      {
                         grammarName = o.GrammarName;

                         if (!string.IsNullOrEmpty(o.RuleName))
                            grammarRule = o.RuleName;

                         if (!string.IsNullOrEmpty(o.EncodingName))
                            encoding = o.EncodingName;

                         if (o.Diagnostics) visualAnalyzer.ParseWithDiagnostics = true;
                         if (o.Trace) visualAnalyzer.ParseWithTracing = true;
                         if (o.Sll) visualAnalyzer.ParseWithSllMode = true;

                         grammarName = o.GrammarName;
                         grammarRule = o.RuleName;
                      });



         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(visualAnalyzer);
      }
   }
}
