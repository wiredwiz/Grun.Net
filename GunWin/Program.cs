using System;
using System.IO;
using System.Text;
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
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         var grammarName = string.Empty;
         var grammarRule = string.Empty;
         var visualAnalyzer = new VisualAnalyzer();

         Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(o =>
                      {
                         if (!string.IsNullOrEmpty(o.GrammarName))
                           grammarName = o.GrammarName;

                         if (!string.IsNullOrEmpty(o.RuleName))
                            grammarRule = o.RuleName;

                         if (!string.IsNullOrEmpty(o.FileName))
                         {
                            var encodingToUse = !string.IsNullOrEmpty(o.EncodingName) ? Encoding.GetEncoding(o.EncodingName) : Encoding.Default;
                            using (var reader = new StreamReader(o.FileName, encodingToUse))
                               visualAnalyzer.SetSourceCode(reader.ReadToEnd());
                         }

                         if (o.Diagnostics) visualAnalyzer.ParseWithDiagnostics = true;
                         if (o.Trace) visualAnalyzer.ParseWithTracing = true;
                         if (o.Sll) visualAnalyzer.ParseWithSllMode = true;
                      });

         var workingDirectory = Environment.CurrentDirectory;
         var scanner = new Grammar.Scanner();

         if (!string.IsNullOrEmpty(grammarName))
         {
            var grammar = scanner.LocateGrammar(workingDirectory, grammarName);
            if (grammar == null)
            {
               Console.WriteLine(
                                 $"Could not find an assembly that defines grammar \"{grammarName}\" in the current working directory");
               return;
            }

            visualAnalyzer.SetGrammar(grammar);
         }

         if (!string.IsNullOrEmpty(grammarRule))
            visualAnalyzer.SetDefaultParserRule(grammarRule);

         Application.Run(visualAnalyzer);
      }
   }
}
