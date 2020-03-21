#region BSD 3-Clause License
// <copyright file="ConsoleWrapperText.cs" company="Edgerunner.org">
// Copyright 2020 
// </copyright>
// 
// BSD 3-Clause License
// 
// Copyright (c) 2020, 
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

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Grun.SyntaxHighlighting
{
   /// <summary>
   /// Class that represents a console wrapper class for achieving syntax highlighting.
   /// </summary>
   public static partial class SyntaxHighlightingConsole
   {
      public static int BufferHeight
      {
         get => Colorful.Console.BufferHeight;
         set => Colorful.Console.BufferHeight = value;
      }

      public static int BufferWidth
      {
         get => Colorful.Console.BufferWidth;
         set => Colorful.Console.BufferWidth = value;
      }

      public static int CursorLeft
      {
         get => Colorful.Console.CursorLeft;
         set => Colorful.Console.CursorLeft = value;
      }

      public static int CursorSize
      {
         get => Colorful.Console.CursorSize;
         set => Colorful.Console.CursorSize = value;
      }

      public static int CursorTop
      {
         get => Colorful.Console.CursorTop;
         set => Colorful.Console.CursorTop = value;
      }

      public static int WindowHeight
      {
         get => Colorful.Console.WindowHeight;
         set => Colorful.Console.WindowHeight = value;
      }

      public static int WindowLeft
      {
         get => Colorful.Console.WindowLeft;
         set => Colorful.Console.WindowLeft = value;
      }

      public static int WindowTop
      {
         get => Colorful.Console.WindowTop;
         set => Colorful.Console.WindowTop = value;
      }

      public static int WindowWidth
      {
         get => Colorful.Console.WindowWidth;
         set => Colorful.Console.WindowWidth = value;
      }

      private static void AdvanceBuffer()
      {
         if (CursorTop == (BufferHeight - 1))
            _ScrollFadeCount++;
      }

      public static void SetCursorPosition(int left, int top)
      {
         Colorful.Console.SetCursorPosition(left, top);
      }

      public static void Write(string value)
      {
         if (value.EndsWith("\r\n") || value.EndsWith("\n"))
            AdvanceBuffer();

         Colorful.Console.Write(value);
      }

      public static void WriteLine()
      {
         AdvanceBuffer();
         Colorful.Console.WriteLine();
      }

      public static void WriteLine(string value)
      {
         AdvanceBuffer();
         Colorful.Console.WriteLine(value);
      }
   }
}