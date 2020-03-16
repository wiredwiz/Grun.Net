#region BSD 3-Clause License
// <copyright file="EditorGuideMonitor.cs" company="Edgerunner.org">
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

using System;
using System.IO;
using System.Threading;

using JetBrains.Annotations;

using Org.Edgerunner.ANTLR4.Tools.Testing.Grammar;

namespace Org.Edgerunner.ANTLR4.Tools.Testing.Monitors
{
   public class EditorGuideMonitor
   {
      private readonly SynchronizationContext _SynchronizationContext;

      // ReSharper disable once NotAccessedField.Local
      private readonly FileSystemWatcher _Watcher;

      private DateTime _LastWriteTime;

      #region Constructors And Finalizers

      /// <summary>
      ///    Initializes a new instance of the <see cref="EditorGuideMonitor" /> class.
      /// </summary>
      /// <param name="guide">The editor guide.</param>
      /// <param name="synchronizationContext">The synchronization context.</param>
      /// <exception cref="ArgumentNullException">
      ///    guide
      ///    or
      ///    synchronizationContext are <see langword="null" />
      /// </exception>
      /// <exception cref="T:System.Security.SecurityException">
      ///    The caller does not have the required permission to access the
      ///    guide assembly.
      /// </exception>
      /// <exception cref="T:System.UnauthorizedAccessException">Access to the guide assembly is denied.</exception>
      public EditorGuideMonitor([NotNull] EditorGuideReference guide, [NotNull] SynchronizationContext synchronizationContext)
      {
         Guide = guide ?? throw new ArgumentNullException(nameof(guide));
         _SynchronizationContext = synchronizationContext ?? throw new ArgumentNullException(nameof(synchronizationContext));

         _Watcher = CreateAssemblyWatcher(new FileInfo(guide.AssemblyPath));
      }

      #endregion

      /// <summary>
      /// Gets the editor guide reference.
      /// </summary>
      /// <value>The editor guide reference.</value>
      public EditorGuideReference Guide { get; }

      /// <summary>
      ///    Occurs when the editor guide is changed.
      /// </summary>
      public event EventHandler<EditorGuideReference> GuideChanged;

      private FileSystemWatcher CreateAssemblyWatcher(FileInfo assembly)
      {
         if (string.IsNullOrEmpty(assembly.DirectoryName))
            throw new InvalidOperationException("Guide assembly has no directory, How is that possible?");

         var watcher = new FileSystemWatcher(assembly.DirectoryName)
         {
            EnableRaisingEvents = true,
            Filter = Path.GetFileName(assembly.FullName),
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size
         };
         watcher.Changed += Guide_Changed;

         return watcher;
      }

      private void Guide_Changed(object sender, FileSystemEventArgs e)
      {
         if (!File.Exists(e.FullPath))
            return;

         var info = new FileInfo(e.FullPath);
         if (info.LastWriteTime <= _LastWriteTime)
            return;

         _LastWriteTime = info.LastWriteTime;

         // Delay for a second to increase odds that the file has been released by the writer
         Thread.Sleep(1000);

         OnGuideChanged();
      }

      /// <summary>
      ///    Called when the editor guide has been changed to fire the GuideChanged event.
      /// </summary>
      private void OnGuideChanged()
      {
         _SynchronizationContext.Post(PostGuideChangedEvent, Guide);
      }

      private void PostGuideChangedEvent(object state)
      {
         GuideChanged?.Invoke(this, state as EditorGuideReference);
      }
   }
}