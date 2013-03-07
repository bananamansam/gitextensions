﻿using System;
using System.Reactive.Linq;
using GitUIPluginInterfaces;

namespace BackgroundFetch
{
    public class BackgroundFetchPlugin : GitPluginBase, IGitPluginForRepository
    {
        private IDisposable cancellationToken;
        private IGitUICommands currentGitUiCommands;

        public override string Description
        {
            get { return "Periodic background fetch"; }
        }

        protected override void RegisterSettings()
        {
            base.RegisterSettings();

            Settings.AddSetting("Fetch every (seconds) - set to 0 to disable", "0");
        }

        public override void Register(IGitUICommands gitUiCommands)
        {
            base.Register(gitUiCommands);

            currentGitUiCommands = gitUiCommands;
            currentGitUiCommands.PostSettings += OnPostSettings;

            RecreateObservable();
        }

        private void OnPostSettings(object sender, GitUIPostActionEventArgs e)
        {
            RecreateObservable();
        }

        private void RecreateObservable()
        {
            CancelBackgroundOperation();

            int fetchInterval;
            if (!int.TryParse(Settings.GetSetting("Fetch every (seconds) - set to 0 to disable"), out fetchInterval))
                fetchInterval = 0;

            if (fetchInterval > 0 && currentGitUiCommands.GitModule.IsValidGitWorkingDir(currentGitUiCommands.GitModule.GitWorkingDir))
            {
                cancellationToken =
                    Observable.Timer(TimeSpan.FromSeconds(Math.Max(5, fetchInterval)))
                        .Repeat()
                        .Subscribe(i => currentGitUiCommands.GitCommand("fetch --progress --all"));
            }
        }

        private void CancelBackgroundOperation()
        {
            if (cancellationToken != null)
            {
                cancellationToken.Dispose();
                cancellationToken = null;
            }
        }

        public override void Unregister(IGitUICommands gitUiCommands)
        {
            CancelBackgroundOperation();

            if (currentGitUiCommands != null)
            {
                currentGitUiCommands.PostSettings -= OnPostSettings;
                currentGitUiCommands = null;
            }

            base.Unregister(gitUiCommands);
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            return false;
        }
    }
}
