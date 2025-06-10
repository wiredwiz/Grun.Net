# Grun.Net

![.Net Framework CI](https://github.com/wiredwiz/Grun.Net/workflows/.Net%20Framework%20CI/badge.svg)
[![License](https://img.shields.io/badge/license-BSD-blue.svg)](https://raw.githubusercontent.com/wiredwiz/Grun.Net/master/LICENSE)
[![GitHub release](https://img.shields.io/github/release/wiredwiz/Grun.Net.svg)](https://github.com/wiredwiz/Grun.Net/releases/)

[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/wiredwiz/Grun.Net/graphs/commit-activity)
[![GitHub issues open](https://img.shields.io/github/issues/wiredwiz/Grun.Net.svg?maxAge=60)](https://github.com/wiredwiz/Grun.Net/issues)
[![GitHub issues-closed](https://img.shields.io/github/issues-closed/wiredwiz/Grun.Net.svg)](https://GitHub.com/wiredwiz/Grun.Net/issues?q=is%3Aissue+is%3Aclosed)
[![Average time to resolve an issue](http://isitmaintained.com/badge/resolution/wiredwiz/Grun.Net.svg)](http://isitmaintained.com/project/wiredwiz/Grun.Net "Average time to resolve an issue")

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/wiredwiz/Grun.Net.svg)](https://GitHub.com/wiredwiz/Grun.Net/pulls/)

[![Twitter URL](https://img.shields.io/twitter/url/http/shields.io.svg?label=Tweet%20me&style=social)](https://twitter.com/intent/tweet?screen_name=wiredwiz)

A set of tools written in C# for testing Antlr4 generated C# grammar assemblies. 
These tools are meant to supplement the need to continually test with the Antlr java TestRig assembly.
If you want support for the Antlr4.Runtime assembly, install version 1.3.23320.0.  If you want support for the Antlr4.Runtime.Standard assembly, then install 2.0.23321.1 instead.
You may install both versions together if needed, the 2.x runtime standard versions will install alongside the original without issues.
In the future I will work on a version that supports both dynamically, but the current design of the app makes this impossible.

It is important to note that Grun.Net expects .Net Standard targeted assemblies for inspection and testing.  If you are building C# ANTLR parsers using .Net (core), then I suggest simply creating a second project that targets standard and sharing your .g4 grammar files between the two projects.  That way you can easily compile and test the grammar using the tool while also building the .Net assemblies that you ultimately wish to deploy.  I personally use Visual Studio for my development and don't really have any experience doing all the dev in VSCode, so I don't have much input there (perhaps someone more familiar can help there).  I know that in studio it is trivial to create your grammar files at a solution level, then create links to them in each project so you only ever need to edit one set of source files.

Please create issues for any bug fixes or feature requests.  I want to make this tool better and help improve C# ANTLR development.

Grun.Net is primarily composed of two testing tools: Grun.exe and GrunWin.exe.
Grun.exe is a command line testing tool similar to the existing Antlr TestRig.
GrunWin.exe is a graphical testing tool with a host of testing features.

Further information on the features and usage of each tool may be found 
[in the wiki](https://github.com/wiredwiz/Grun.Net/wiki).

Below is a demonstration video showing how to use these tools.
[![Demonstration Video](http://img.youtube.com/vi/fFBz6Fey6Pk/0.jpg)](https://www.youtube.com/watch?v=fFBz6Fey6Pk)

![Editor Sample](https://github.com/wiredwiz/Grun.Net/blob/assets/Assets/GrunWinExample.GIF?raw=true)
