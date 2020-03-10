#region BSD 3-Clause License
// <copyright file="EditorSettings.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.ANTLR4.Tools.Testing.GrunWin
{
   /// <summary>
   /// Class that represents various code editor settings.
   /// </summary>
   public class EditorSettings
   {
      /// <summary>
      /// Gets or sets the node threshold count for throttling.
      /// </summary>
      /// <value>The node threshold count for throttling.</value>
      public int NodeThresholdCountForThrottling { get; set; }

      /// <summary>
      /// Gets or sets the milliseconds to delay per node when throttling.
      /// </summary>
      /// <value>The milliseconds to delay per node when throttling.</value>
      public int MillisecondsToDelayPerNodeWhenThrottling { get; set; }

      /// <summary>
      /// Gets or sets the maximum render short delay.
      /// </summary>
      /// <value>The maximum render short delay.</value>
      public int MaximumRenderShortDelay { get; set; }

      /// <summary>
      /// Gets or sets the minimum render count to trigger a long delay.
      /// </summary>
      /// <value>The minimum render count to trigger a long delay.</value>
      public int MinimumRenderCountToTriggerLongDelay { get; set; }
   }
}