# Grun.Net

A set of tools written in C# for testing ANTLR generated C# grammar assemblies. 
These tools are meant to supplement the need to continually build java classes to test with the java TestRig assembly.

![.Net Framework CI](https://github.com/wiredwiz/Grun.Net/workflows/.Net%20Framework%20CI/badge.svg)
[![License](https://img.shields.io/badge/license-BSD-blue.svg)](https://raw.githubusercontent.com/antlr/antlr4/master/LICENSE.txt)

### Grun.exe

Grun.exe is meant to be a mostly faithful port of existing functionality provided by the standard
grun batch file that in turn invokes the ANTLR test rig.  All but one of the same options are
supported. The option flags are slightly different in format due to the command line option
parser that is being used.  The parameters and option flags are detailed below

**Grun.exe \<Grammar Name> \<Rule Name> [\<Input Filename>] [options]**

  Grammar Name (pos. 0)
   : Required. ANTLR grammar to load  

  Rule Name (pos. 1)
   : Required. ANTLR grammar rule to use  

  Input Filename (pos. 2)
   : File name to parse

  | Option Name      | Description  |
  |---               |---       |
  |--tokens          |         Display list of grammar tokens. |  
  |--tree            |         Display a Lisp-style parse tree.|
  |--trace           |         Trace grammar parsing.          |
  |--gui             |         Opens GrunWin.exe gui tool.     |
  |--SLL             |         Parse using SLL prediction mode.|
  |--diagnostics     |         Parse with diagnostics.         |
  |--encoding        |         Encoding type to use.           |
  |--help            |         Display this help screen.       |
  |--version         |         Display version information.    |

The gui flag simply opens the GrunWin tool (which can also be executed stand-alone).  

### GrunWin.exe
GrunWin is a replacement for the gui parse tree viewer that the standard test rig displays.
GrunWin Features
- Can be run as a stand-alone application
- Features a robust code editor window to use for grammar testing.
- Features a graphical parse tree viewer.
- Features a parser message window that displays parser errors.
- Features a token viewer that displays detailed information about lexer tokens.

The parse tree graph, token display and parser error messages all update in real-time
as you enter text into the code editor.  You can load a new grammar at any while GrunWin
is running.  GrunWin also supports a handful of optional command line parameters.

**GrunWin.exe [options]**

  | Option Name      | Description  |
  |---               |---       |
  |--grammar         |         Attempts to load the specified grammar.   |
  |--rule            |         Attempts to load the specified rule name. |  
  |--trace           |         Trace grammar parsing.          |
  |--SLL             |         Parse using SLL prediction mode.|
  |--diagnostics     |         Parse with diagnostics.         |
  |--encoding        |         Encoding type to use.           |

![Editor Sample](https://github.com/wiredwiz/Grun.Net/blob/master/Images/GrunWinExample.GIF?raw=true)

I eventually plan to add syntax highlighting to the editor window.  The tool will attempt
to build a color pallet heuristically, but an ISyntaxGuide can be implemented to help
GrunWin highlight the text more to your liking.
