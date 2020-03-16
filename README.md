# Grun.Net (BETA)

A set of tools written in C# for testing Antlr4 generated C# grammar assemblies. 
These tools are meant to supplement the need to continually test with the Antlr java TestRig assembly.

![.Net Framework CI](https://github.com/wiredwiz/Grun.Net/workflows/.Net%20Framework%20CI/badge.svg)
[![License](https://img.shields.io/badge/license-BSD-blue.svg)](https://raw.githubusercontent.com/antlr/antlr4/master/LICENSE.txt)
![version](https://img.shields.io/badge/version-1.0.20073-blue)
<!---
[![GitHub release](https://img.shields.io/github/release/wiredwiz/Grun.Net.svg)](https://github.com/wiredwiz/Grun.Net/releases/)
--->

[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/wiredwiz/Grun.Net/graphs/commit-activity)
[![GitHub issues open](https://img.shields.io/github/issues/wiredwiz/Grun.Net.svg?maxAge=2592000)](https://github.com/wiredwiz/Grun.Net/issues)
[![Percentage of issues still open](http://isitmaintained.com/badge/open/wiredwiz/Grun.Net.svg)](http://isitmaintained.com/project/wiredwiz/Grun.Net "Percentage of issues still open")
[![Average time to resolve an issue](http://isitmaintained.com/badge/resolution/wiredwiz/Grun.Net.svg)](http://isitmaintained.com/project/wiredwiz/Grun.Net "Average time to resolve an issue")

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/wiredwiz/Grun.Net.svg)](https://GitHub.com/wiredwiz/Grun.Net/pulls/)

### Grun.exe

Grun.exe is meant to be a mostly faithful port of existing functionality provided by the standard
grun batch file that in turn invokes the ANTLR test rig.  All options except the 'ps' flag are
supported. The option flags are slightly different in format due to the command line option
parser that is being used (you'll notice you need to use '--' and not '-').  The parameters and option flags are detailed below

**Grun.exe \<Grammar Name> \<Rule Name> [\<Input Filename>] [options]**

  Grammar Name (pos. 0)
   : Required. ANTLR grammar to load  

  Rule Name (pos. 1)
   : Required. ANTLR grammar rule to use  

  Input Filename (pos. 2)
   : File name to parse (if an encoding is supplied it will be used when reading this file)

  | Option Name       | Description  |
  |---                |---       |
  |--tokens           |         Display list of grammar tokens. |  
  |--tree             |         Display a Lisp-style parse tree.|
  |--trace            |         Trace grammar parsing.          |
  |--gui              |         Opens GrunWin.exe gui tool.     |
  |--svg \<file name> |         Outputs parse tree graph to a scalable vector graphics file.|
  |--SLL              |         Parse using SLL prediction mode.|
  |--diagnostics      |         Parse with diagnostics.         |
  |--encoding \<name> |         Encoding type to use.           |
  |--help             |         Display this help screen.       |
  |--version          |         Display version information.    |

The gui flag simply opens the GrunWin tool (which can also be executed stand-alone).  

### GrunWin.exe
GrunWin is a replacement for the gui parse tree viewer that the standard test rig displays.
GrunWin Features
- Can be run as a stand-alone application
- Features a robust code editor window to use for grammar testing.
- Features a heuristic syntax highlighter.
- Features a graphical parse tree viewer.
- Features a trace event window.
- Features a parser message window that displays parser errors.
- Features a token viewer that displays detailed information about lexer tokens.

The parse tree graph, token display and parser error messages all update in real-time
as you enter text into the code editor.  You can load a new grammar at any while GrunWin
is running.  GrunWin also supports a handful of optional command line parameters.

**GrunWin.exe [options]**

  | Option Name       | Description  |
  |---                |---       |
  |--grammar \<name>  |         Attempts to load the specified grammar.   |
  |--rule \<name>     |         Attempts to load the specified rule name. |  
  |--file \<file name>|         Attempts to load the specified file name into the editor window.|
  |--trace            |         Trace grammar parsing.          |
  |--SLL              |         Parse using SLL prediction mode.|
  |--diagnostics      |         Parse with diagnostics.         |
  |--encoding \<name> |         Encoding type to use.           |

![Editor Sample](https://github.com/wiredwiz/Grun.Net/blob/assets/Assets/GrunWinExample.GIF?raw=true)

I eventually plan to add syntax highlighting to the editor window.  The tool will attempt
to build a color pallet heuristically, but an ISyntaxGuide can be implemented to help
GrunWin highlight the text more to your liking.
