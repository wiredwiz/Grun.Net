# Grun.Net

A set of tools written in C# for testing ANTLR generated C# grammar assemblies. 
These tools are meant to supplement the need to continually build java classes to test with the java TestRig assembly.

![.Net Framework CI](https://github.com/wiredwiz/Grun.Net/workflows/.Net%20Framework%20CI/badge.svg)
[![License](https://img.shields.io/badge/license-BSD-blue.svg)](https://raw.githubusercontent.com/antlr/antlr4/master/LICENSE.txt)

### Grun.exe

A breakdown of option statuses follows
- --tokens [**Full Suport**]
- --gui [**Partial Support**]
- --diagnostics [**Full Support**]
- --trace [**Full Support**]
- --encoding [**Full Support**]
- --SLL [**Full Support**]
- --ps [**Not Supported Yet**]
- --tree [**Full Support**]

The gui flag simply opens the GrunWin tool.  Eventually this tool will be able to be run
separately with it's own command line flags.  

### GrunWin.exe
GrunWin is more than just a graphical parse tree viewer.  It also displays a tab with
the grid view of tokens and a robust editor window.  As code is changed in the editor,
GrunWin continues to re-parse for tokens and rebuild the graphical parse tree.  I eventually
plan to add syntax highlighting to the editor window as well as a list of parser errors in
a grid view.
By default it will attempt to intelligently figure out some colors for different tokens.
However, it will also support dynamic loading of helper classes to give it concrete highlighting guides.
I have not worked out the interface for this guide yet, but it can be included in the grammar assembly
or any other assembly in the same folder as the grammar assembly.
GrunWin will also look for syntax guides in a special folder within the location of the GrunWin executable as well.
