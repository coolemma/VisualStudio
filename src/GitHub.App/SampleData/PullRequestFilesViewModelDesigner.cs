﻿using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using GitHub.Models;
using GitHub.Services;
using GitHub.ViewModels.GitHubPane;
using LibGit2Sharp;
using ReactiveUI;

namespace GitHub.SampleData
{
    public class PullRequestFilesViewModelDesigner : PanePageViewModelBase, IPullRequestFilesViewModel
    {
        public PullRequestFilesViewModelDesigner()
        {
            Items = new[]
            {
                new PullRequestDirectoryNode("src")
                {
                    Files =
                    {
                        new PullRequestFileNode("x", "src/File1.cs", "x", PullRequestFileStatus.Added, null),
                        new PullRequestFileNode("x", "src/File2.cs", "x", PullRequestFileStatus.Modified, null),
                        new PullRequestFileNode("x", "src/File3.cs", "x", PullRequestFileStatus.Removed, null),
                        new PullRequestFileNode("x", "src/File4.cs", "x", PullRequestFileStatus.Renamed, "src/Old.cs"),
                    }
                }
            };
        }

        public bool IsBranchCheckedOut { get; set; }
        public IReadOnlyList<IPullRequestChangeNode> Items { get; }
        public ReactiveCommand<Unit> DiffFile { get; }
        public ReactiveCommand<Unit> ViewFile { get; }
        public ReactiveCommand<Unit> DiffFileWithWorkingDirectory { get; }
        public ReactiveCommand<Unit> OpenFileInWorkingDirectory { get; }

        public Task InitializeAsync(
            IPullRequestSession session,
            TreeChanges changes,
            Func<IInlineCommentThreadModel, bool> commentFilter = null)
        {
            return Task.CompletedTask;
        }
    }
}
