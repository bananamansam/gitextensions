﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GitCommands.Logging;
using GitCommands.Repository;
using System.Threading;

namespace GitCommands
{
    public static class Settings
    {
        public static string GitExtensionsVersionString = "2.05";
        public static int GitExtensionsVersionInt = 205;
        private static string _gitBinDir = "";
        private static string _workingdir;
        private static bool _commitInfoShowContainedInBranchesRemote = false;
        private static bool _commitInfoShowContainedInBranchesRemoteIfNoLocal = false;
        public static char PathSeparator = '\\';
        public static char PathSeparatorWrong = '/';

        static Settings()
        {
            //Marked wich can be used to check if all settings that are loaded async
            //are loaded.
            AllSettingsLoaded = false;

            if (!RunningOnWindows())
            {
                PathSeparator = '/';
                PathSeparatorWrong = '\\';
            }

            BranchBorders = true;
            StripedBranchChange = true;
            MulticolorBranches = true;
            DiffAddedExtraColor = Color.FromArgb(135, 255, 135);
            DiffAddedColor = Color.FromArgb(200, 255, 200);
            DiffRemovedExtraColor = Color.FromArgb(255, 150, 150);
            DiffRemovedColor = Color.FromArgb(255, 200, 200);
            DiffSectionColor = Color.FromArgb(230, 230, 230);
            RemoteBranchColor = Color.Green;
            BranchColor = Color.DarkRed;
            GraphColor = Color.Red;
            TagColor = Color.DarkBlue;
            OtherTagColor = Color.Gray;
            AutoStartPageant = true;
            Pageant = "";
            Puttygen = "";
            Plink = "";
            GitLog = new CommandLogger();
            MaxCommits = 2000;
            GitCommand = "git.cmd";
            ShowRevisionGraph = true;
            UseFastChecks = true;
            RelativeDate = true;
            Dictionary = "en-US";
            OrderRevisionByDate = true;
            Smtp = "";
            PullMerge = "merge";
            Encoding = Encoding.Default;
            RevisionGraphThickness = 1F;
            RevisionGraphWidth = 6;
            FollowRenamesInFileHistory = true;
            ShowAuthorGravatar = true;
            AuthorImageCacheDays = 5;
            AuthorImageSize = 80;
            IconColor = "default";
            CustomHomeDir = "";
            Translation = "";
            CommitInfoShowContainedInBranchesLocal = true;
            CommitInfoShowContainedInBranchesRemote = false;
            CommitInfoShowContainedInBranchesRemoteIfNoLocal = false;
            CommitInfoShowContainedInTags = true;
            RevisionGridQuickSearchTimeout = 700;
            ApplicationDataPath = Application.UserAppDataPath + Settings.PathSeparator.ToString();
            ShowGitStatusInBrowseToolbar = false;
            LastCommitMessage = "";
            ShowErrorsWhenStagingFiles = true;
            RevisionGraphDrawNonRelativesGray = true;
            RevisionGraphShowWorkingDirChanges = false;
            LastFormatPatchDir = "";
        }


        public static void WaitUntilAllSettingsLoaded()
        {
            while (!AllSettingsLoaded)
            {
                Thread.Sleep(50);
            }
        }

        //Marked wich can be used to check if all settings that are loaded async
        //are loaded.
        public static bool AllSettingsLoaded { get; set; }

        public static bool ShowErrorsWhenStagingFiles { get; set; }

        public static string LastCommitMessage { get; set; }

        public static bool ShowGitStatusInBrowseToolbar { get; set; }

        public static bool CommitInfoShowContainedInBranches
        {
            get
            {
                return CommitInfoShowContainedInBranchesLocal ||
                    CommitInfoShowContainedInBranchesRemote ||
                    CommitInfoShowContainedInBranchesRemoteIfNoLocal;
            }
        }

        public static bool CommitInfoShowContainedInBranchesLocal { get; set; }

        public static bool CommitInfoShowContainedInBranchesRemote {
            get
            {
                return _commitInfoShowContainedInBranchesRemote;
            }
            set
            {
                _commitInfoShowContainedInBranchesRemote = value;
                if (value)
                    CommitInfoShowContainedInBranchesRemoteIfNoLocal = false;
            }
        }

        public static bool CommitInfoShowContainedInBranchesRemoteIfNoLocal {
            get
            {
                return _commitInfoShowContainedInBranchesRemoteIfNoLocal;
            }
            set
            {
                _commitInfoShowContainedInBranchesRemoteIfNoLocal = value;
                if (value)
                    CommitInfoShowContainedInBranchesRemote = false;
            }
        }

        public static bool CommitInfoShowContainedInTags { get; set; }

        public static string ApplicationDataPath { get; set; }

        public static string Translation { get; set; }

        public static bool UserProfileHomeDir { get; set; }

        public static string CustomHomeDir { get; set; }

        public static string IconColor { get; set; }

        public static int AuthorImageSize { get; set; }

        public static int AuthorImageCacheDays { get; set; }

        public static bool ShowAuthorGravatar { get; set; }

        public static bool CloseCommitDialogAfterCommit { get; set; }

        public static bool FollowRenamesInFileHistory { get; set; }

        public static bool RevisionGraphShowWorkingDirChanges { get; set; }

        public static bool RevisionGraphDrawNonRelativesGray { get; set; }

        public static int RevisionGraphWidth { get; set; }

        public static float RevisionGraphThickness { get; set; }

        public static Encoding Encoding { get; set; }

        public static string PullMerge { get; set; }

        public static string Smtp { get; set; }

        public static bool AutoStash { get; set; }

        public static bool OrderRevisionByDate { get; set; }

        public static string Dictionary { get; set; }

        public static bool ShowGitCommandLine { get; set; }

        public static bool RelativeDate { get; set; }

        public static bool UseFastChecks { get; set; }

        public static bool ShowRevisionGraph { get; set; }

        public static bool ShowAuthorDate { get; set; }

        public static bool CloseProcessDialog { get; set; }

        public static bool ShowCurrentBranchOnly { get; set; }

        public static bool BranchFilterEnabled { get; set; }

        public static int RevisionGridQuickSearchTimeout { get; set; }

        public static string GitCommand { get; set; }

        public static string GitBinDir
        {
            get { return _gitBinDir; }
            set
            {
                _gitBinDir = value;
                if (_gitBinDir.Length > 0 && _gitBinDir[_gitBinDir.Length - 1] != PathSeparator)
                    _gitBinDir += PathSeparator;

                if (string.IsNullOrEmpty(_gitBinDir))
                    return;

                var path =
                    Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process) + ";" +
                    _gitBinDir;
                Environment.SetEnvironmentVariable("path", path, EnvironmentVariableTarget.Process);
            }
        }

        public static int MaxCommits { get; set; }

        public delegate void WorkingDirChangedEventHandler(string oldDir, string newDir);
        public static event WorkingDirChangedEventHandler WorkingDirChanged;

        public static string WorkingDir
        {
            get 
            { 
                return _workingdir; 
            }
            set 
            {
                string old = _workingdir;
                _workingdir = GitCommandHelpers.FindGitWorkingDir(value.Trim());
                if (WorkingDirChanged != null)
                {
                    WorkingDirChanged(old, _workingdir);
                }
            }
        }

        public static CommandLogger GitLog { get; private set; }

        public static string Plink { get; set; }

        public static string Puttygen { get; set; }

        public static string Pageant { get; set; }

        public static bool AutoStartPageant { get; set; }

        public static bool MarkIllFormedLinesInCommitMsg { get; set; }

        #region Colors

        public static Color OtherTagColor { get; set; }

        public static Color TagColor { get; set; }

        public static Color GraphColor { get; set; }

        public static Color BranchColor { get; set; }

        public static Color RemoteBranchColor { get; set; }

        public static Color DiffSectionColor { get; set; }

        public static Color DiffRemovedColor { get; set; }

        public static Color DiffRemovedExtraColor { get; set; }

        public static Color DiffAddedColor { get; set; }

        public static Color DiffAddedExtraColor { get; set; }

        public static bool MulticolorBranches { get; set; }

        public static bool StripedBranchChange { get; set; }

        public static bool BranchBorders { get; set; }

        public static string LastFormatPatchDir { get; set; }

        #endregion

        public static string GetDictionaryDir()
        {
            var result = "";
            SafeSetString("InstallDir", x => result = x + "\\Dictionaries\\");
            return result;
        }


        public static string GetInstallDir()
        {
            var result = "";
            SafeSetString("InstallDir", x => result = x);
            return result;
        }

        public static void SetInstallDir(string dir)
        {
            if (Application.UserAppDataRegistry != null)
                Application.UserAppDataRegistry.SetValue("InstallDir", dir);
        }

        public static bool ValidWorkingDir()
        {
            return ValidWorkingDir(WorkingDir);
        }

        public static bool ValidWorkingDir(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                return false;

            if (Directory.Exists(dir + PathSeparator + ".git"))
                return true;

            return !dir.Contains(".git") &&
                   Directory.Exists(dir + PathSeparator + "info") &&
                   Directory.Exists(dir + PathSeparator + "objects") &&
                   Directory.Exists(dir + PathSeparator + "refs");
        }

        public static bool IsBareRepository()
        {
            return !Directory.Exists(WorkingDir + PathSeparator + ".git");
        }

        public static string WorkingDirGitDir()
        {
            var workingDir = WorkingDir;

            if (Directory.Exists(workingDir + ".git"))
                return workingDir + ".git";

            if (Directory.Exists(workingDir + PathSeparator + ".git"))
                return workingDir + PathSeparator + ".git";

            return WorkingDir;
        }

        public static bool RunningOnWindows()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    return true;
                default:
                    return false;
            }
        }

        public static bool RunningOnUnix()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return true;
                default:
                    return false;
            }
        }

        public static bool RunningOnMacOSX()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                    return true;
                default:
                    return false;
            }
        }

        public static void SaveSettings()
        {
            try
            {

                if (Application.UserAppDataRegistry == null)
                    throw new Exception("Application.UserAppDataRegistry is not available");

                var appData = Application.UserAppDataRegistry;

                appData.SetValue("gitdir", GitCommand);
                appData.SetValue("gitbindir", GitBinDir);

                SetEncoding();

                appData.SetValue("history", Repositories.SerializeHistoryIntoXml());
                appData.SetValue("repositories", Repositories.SerializeRepositories());
                appData.SetValue("showauthorgravatar", ShowAuthorGravatar);
                appData.SetValue("userprofilehomedir", UserProfileHomeDir);
                appData.SetValue("customhomedir", CustomHomeDir);
                appData.SetValue("closeCommitDialogAfterCommit", CloseCommitDialogAfterCommit);
                appData.SetValue("markIllFormedLinesInCommitMsg", MarkIllFormedLinesInCommitMsg);
                appData.SetValue("diffaddedcolor", ColorTranslator.ToHtml(DiffAddedColor));
                appData.SetValue("diffremovedcolor", ColorTranslator.ToHtml(DiffRemovedColor));
                appData.SetValue("diffaddedextracolor", ColorTranslator.ToHtml(DiffAddedExtraColor));
                appData.SetValue("diffremovedextracolor", ColorTranslator.ToHtml(DiffRemovedExtraColor));
                appData.SetValue("diffsectioncolor", ColorTranslator.ToHtml(DiffSectionColor));
                appData.SetValue("multicolorbranches", MulticolorBranches);
                appData.SetValue("branchborders", BranchBorders);
                appData.SetValue("stripedbanchchange", StripedBranchChange);
                appData.SetValue("tagcolor", ColorTranslator.ToHtml(TagColor));
                appData.SetValue("graphcolor", ColorTranslator.ToHtml(GraphColor));
                appData.SetValue("branchcolor", ColorTranslator.ToHtml(BranchColor));
                appData.SetValue("remotebranchcolor", ColorTranslator.ToHtml(RemoteBranchColor));
                appData.SetValue("othertagcolor", ColorTranslator.ToHtml(OtherTagColor));
                appData.SetValue("iconcolor", IconColor);
                appData.SetValue("translation", Translation);
                appData.SetValue("authorImageCacheDays", AuthorImageCacheDays);
                appData.SetValue("authorimagesize", AuthorImageSize);
                appData.SetValue("maxcommits", MaxCommits);
                appData.SetValue("showallbranches", ShowCurrentBranchOnly);
                appData.SetValue("branchfilterenabled", BranchFilterEnabled);
                appData.SetValue("closeprocessdialog", CloseProcessDialog);
                appData.SetValue("showrevisiongraph", ShowRevisionGraph);
                appData.SetValue("showauthordate", ShowAuthorDate);
                appData.SetValue("orderrevisiongraphbydate", OrderRevisionByDate);
                appData.SetValue("showgitcommandline", ShowGitCommandLine);
                appData.SetValue("usefastchecks", UseFastChecks);
                appData.SetValue("relativedate", RelativeDate);
                appData.SetValue("gitssh", GitCommandHelpers.GetSsh());
                appData.SetValue("pullmerge", PullMerge);
                appData.SetValue("autostash", AutoStash);
                appData.SetValue("followrenamesinfilehistory", FollowRenamesInFileHistory);
                appData.SetValue("plink", Plink);
                appData.SetValue("puttygen", Puttygen);
                appData.SetValue("pageant", Pageant);
                appData.SetValue("smtp", Smtp);
                appData.SetValue("dictionary", Dictionary);
                appData.SetValue("commitinfoshowcontainedinbrancheslocal", CommitInfoShowContainedInBranchesLocal);
                appData.SetValue("commitinfoshowcontainedinbranchesremote", CommitInfoShowContainedInBranchesRemote);
                appData.SetValue("commitinfoshowcontainedinbranchesremoteifnolocal", CommitInfoShowContainedInBranchesRemoteIfNoLocal);
                appData.SetValue("commitinfoshowcontainedintags", CommitInfoShowContainedInTags);
                appData.SetValue("revisionGridQuickSearchTimeout", RevisionGridQuickSearchTimeout);
                appData.SetValue("showgitstatusinbrowsetoolbar", ShowGitStatusInBrowseToolbar);
                appData.SetValue("lastcommitmessage", LastCommitMessage);
                appData.SetValue("showerrorswhenstagingfiles", ShowErrorsWhenStagingFiles);
                appData.SetValue("revisiongraphdrawnonrelativesgray", RevisionGraphDrawNonRelativesGray);
                appData.SetValue("revisiongraphshowworkingdirchanges", RevisionGraphShowWorkingDirChanges);
                appData.SetValue("lastformatpatchdir", LastFormatPatchDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save settings.\n\n" + ex.Message);
            }
        }

        private static void SetEncoding()
        {
            if (Application.UserAppDataRegistry == null)
                return;

            if (Encoding.EncodingName == Encoding.ASCII.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "ASCII");
            else if (Encoding.EncodingName == Encoding.Unicode.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "Unicode");
            else if (Encoding.EncodingName == Encoding.UTF7.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "UTF7");
            else if (Encoding.EncodingName == Encoding.UTF8.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "UTF8");
            else if (Encoding.EncodingName == Encoding.UTF32.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "UTF32");
            else if (Encoding.EncodingName == Encoding.Default.EncodingName)
                Application.UserAppDataRegistry.SetValue("encoding", "Default");
        }


        public static void LoadSettings()
        {
            AllSettingsLoaded = false;

            //First load the 'important' settings, then load other settings async
            SafeSetString("gitdir", x => GitCommand = x);
            SafeSetString("gitbindir", x => GitBinDir = x);
            SafeSetBool("userprofilehomedir", x => UserProfileHomeDir = x);
            SafeSetString("customhomedir", x => CustomHomeDir = x);

            //We need this BEFORE the first form is started, otherwise it will be pointless
            SafeSetString("iconcolor", x => IconColor = x);
            SafeSetString("translation", x => Translation = x);

            GetEncoding();

            LoadSettingsAsync();
        }

        private static void LoadSettingsAsync()
        {
            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            Thread oThread = new Thread(new ThreadStart(DoLoadSettings));

            // Start the thread
            oThread.Start();

        }

        private static void DoLoadSettings()
        {
            try
            {
                //IMPORTANT: most important settings must be loaded first, since
                //these settings are loading async.
                SafeSetBool("showrevisiongraph", x => ShowRevisionGraph = x);

                SafeSetInt("maxcommits", x => MaxCommits = x);

                try
                {
                    SafeSetHtmlColor("diffaddedcolor", x => DiffAddedColor = x);
                    SafeSetHtmlColor("diffremovedcolor", x => DiffRemovedColor = x);
                    SafeSetHtmlColor("diffaddedextracolor", x => DiffAddedExtraColor = x);
                    SafeSetHtmlColor("diffremovedextracolor", x => DiffRemovedExtraColor = x);
                    SafeSetHtmlColor("diffsectioncolor", x => DiffSectionColor = x);
                    SafeSetHtmlColor("tagcolor", x => TagColor = x);
                    SafeSetHtmlColor("graphcolor", x => GraphColor = x);
                    SafeSetHtmlColor("branchcolor", x => BranchColor = x);
                    SafeSetHtmlColor("remotebranchcolor", x => RemoteBranchColor = x);
                    SafeSetHtmlColor("othertagcolor", x => OtherTagColor = x);
                    SafeSetBool("multicolorbranches", x => MulticolorBranches = x);
                    SafeSetBool("branchborders", x => BranchBorders = x);
                    SafeSetBool("stripedbanchchange", x => StripedBranchChange = x);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }

                SafeSetBool("showauthordate", x => ShowAuthorDate = x);
                SafeSetBool("revisiongraphdrawnonrelativesgray", x => RevisionGraphDrawNonRelativesGray = x);
                SafeSetBool("revisiongraphshowworkingdirchanges", x => RevisionGraphShowWorkingDirChanges = x);

                SafeSetBool("orderrevisiongraphbydate", x => OrderRevisionByDate = x);
                SafeSetBool("relativedate", x => RelativeDate = x);

                SafeSetBool("showauthorgravatar", x => ShowAuthorGravatar = x);
                SafeSetInt("authorImageCacheDays", x => AuthorImageCacheDays = x);
                SafeSetInt("authorimagesize", x => AuthorImageSize = x);

                //Not needed before any dialog is started
                SafeSetString("pullmerge", x => PullMerge = x);
                SafeSetBool("autostash", x => AutoStash = x);

                SafeSetString("gitssh", GitCommandHelpers.SetSsh);
                SafeSetString("plink", x => Plink = x);
                SafeSetString("puttygen", x => Puttygen = x);
                SafeSetString("pageant", x => Pageant = x);
                SafeSetString("dictionary", x => Dictionary = x);
                SafeSetString("smtp", x => Smtp = x);

                SafeSetBool("closeCommitDialogAfterCommit", x => CloseCommitDialogAfterCommit = x);
                SafeSetBool("markIllFormedLinesInCommitMsg", x => MarkIllFormedLinesInCommitMsg = x);
                SafeSetBool("followrenamesinfilehistory", x => FollowRenamesInFileHistory = x);
                SafeSetBool("showgitcommandline", x => ShowGitCommandLine = x);
                SafeSetBool("closeprocessdialog", x => CloseProcessDialog = x);
                SafeSetBool("showallbranches", x => ShowCurrentBranchOnly = !x);
                SafeSetBool("branchfilterenabled", x => BranchFilterEnabled = x);
                SafeSetBool("commitinfoshowcontainedinbranches", x => CommitInfoShowContainedInBranchesLocal = x);
                SafeSetBool("commitinfoshowcontainedinbrancheslocal", x => CommitInfoShowContainedInBranchesLocal = x);
                SafeSetBool("commitinfoshowcontainedinbranchesremote", x => CommitInfoShowContainedInBranchesRemote = x);
                SafeSetBool("commitinfoshowcontainedinbranchesremoteifnolocal", x => CommitInfoShowContainedInBranchesRemoteIfNoLocal = x);
                SafeSetBool("commitinfoshowcontainedintags", x => CommitInfoShowContainedInTags = x);
                SafeSetInt("revisionGridQuickSearchTimeout", x => RevisionGridQuickSearchTimeout = x);
                SafeSetBool("showgitstatusinbrowsetoolbar", x => ShowGitStatusInBrowseToolbar = x);
                SafeSetString("lastcommitmessage", x => LastCommitMessage = x);
                SafeSetBool("showerrorswhenstagingfiles", x => ShowErrorsWhenStagingFiles = x);
                SafeSetString("lastformatpatchdir", x => LastFormatPatchDir = x);

                SafeSetString("history", Repositories.DeserializeHistoryFromXml);
                SafeSetString("repositories", Repositories.DeserializeRepositories);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                AllSettingsLoaded = true;
            }
        }

        private static void GetEncoding()
        {
            string encoding = null;
            SafeSetString("encoding", x => encoding = x);

            if (string.IsNullOrEmpty(encoding))
                Encoding = new UTF8Encoding(false);
            else if (encoding.Equals("Default", StringComparison.CurrentCultureIgnoreCase))
                Encoding = Encoding.Default;
            else if (encoding.Equals("Unicode", StringComparison.CurrentCultureIgnoreCase))
                Encoding = new UnicodeEncoding();
            else if (encoding.Equals("ASCII", StringComparison.CurrentCultureIgnoreCase))
                Encoding = new ASCIIEncoding();
            else if (encoding.Equals("UTF7", StringComparison.CurrentCultureIgnoreCase))
                Encoding = new UTF7Encoding();
            else if (encoding.Equals("UTF32", StringComparison.CurrentCultureIgnoreCase))
                Encoding = new UTF32Encoding(true, false);
            else
                Encoding = new UTF8Encoding(false);
        }

        private static void SafeSetBool(string key, Action<bool> actionToPerformIfValueExists)
        {
            SafeSetString(key, x => actionToPerformIfValueExists(x == "True"));
        }

        private static void SafeSetHtmlColor(string key, Action<Color> actionToPerformIfValueExists)
        {
            SafeSetString(key, x => actionToPerformIfValueExists(ColorTranslator.FromHtml(x)));
        }

        private static void SafeSetInt(string key, Action<int> actionToPerformIfValueExists)
        {
            SafeSetString(key, x =>
                                   {
                                       int result;
                                       if (int.TryParse(x, out result))
                                       {
                                           actionToPerformIfValueExists(result);
                                       }
                                   });
        }

        private static void SafeSetString(string key, Action<string> actionToPerformIfValueExists)
        {
            if (Application.UserAppDataRegistry == null) return;
            var value = Application.UserAppDataRegistry.GetValue(key);
            if (value == null)
                return;
            actionToPerformIfValueExists(value.ToString());
        }
    }
}