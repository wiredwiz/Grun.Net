#region BSD 3-Clause License

// <copyright file="IParseTreeGrapher.cs" company="Edgerunner.org">
// Copyright  Thaddeus Ryker
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) , Thaddeus Ryker
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its
//    contributors may be used to endorse or promote products derived from
//    this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Collections.Generic;

using Antlr4.Runtime.Tree;

using Microsoft.Msagl.Drawing;

namespace Org.Edgerunner.ANTLR4.Tools.Graphing
{
   /// <summary>
   /// Interface that represents a parse tree graphing tool
   /// </summary>
   public interface IParseTreeGrapher
   {
      /// <summary>
      ///    Gets the subject parse tree to graph.
      /// </summary>
      /// <value>The subject tree.</value>
      ITree Subject { get; }

      /// <summary>
      /// Gets the parser rules.
      /// </summary>
      /// <value>The parser rules.</value>
      IList<string> ParserRules { get; }

      /// <summary>
      /// Gets or sets the color of the background.
      /// </summary>
      /// <value>The color of the background.</value>
      Color? BackgroundColor { get; set; }

      /// <summary>
      /// Gets or sets the color of the text.
      /// </summary>
      /// <value>The color of the text.</value>
      Color? TextColor { get; set; }

      /// <summary>
      /// Gets or sets the color of the border.
      /// </summary>
      /// <value>The color of the border.</value>
      Color? BorderColor { get; set; }

      /// <summary>
      /// Creates the parse tree graph.
      /// </summary>
      /// <returns>A new <see cref="Graph"/>.</returns>
      Graph CreateGraph();
   }
}