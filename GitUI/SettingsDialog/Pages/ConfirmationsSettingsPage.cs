﻿using GitCommands;
using System.Windows.Forms;

namespace GitUI.SettingsDialog.Pages
{
    public partial class ConfirmationsSettingsPage : SettingsPageBase
    {
        public ConfirmationsSettingsPage()
        {
            InitializeComponent();
            Text = "Confirmations";
            Translate();
        }

        protected override void OnLoadSettings()
        {
            chkAmmend.Checked = Settings.DontConfirmAmmend;
            chkAutoPopStashAfterPull.CheckState = Settings.AutoPopStashAfterPull.ToCheckboxState();
            chkAutoPopStashAfterCheckout.CheckState = Settings.AutoPopStashAfterCheckoutBranch.ToCheckboxState();
            chkPushNewBranch.Checked = Settings.DontConfirmPushNewBranch;
            chkAddTrackingRef.Checked = Settings.DontConfirmAddTrackingRef;
        }

        public override void SaveSettings()
        {
            Settings.DontConfirmAmmend = chkAmmend.Checked;
            Settings.AutoPopStashAfterPull = chkAutoPopStashAfterPull.CheckState.ToBoolean();
            Settings.AutoPopStashAfterCheckoutBranch = chkAutoPopStashAfterCheckout.CheckState.ToBoolean();
            Settings.DontConfirmPushNewBranch = chkPushNewBranch.Checked;
            Settings.DontConfirmAddTrackingRef = chkAddTrackingRef.Checked;
        }

        public static SettingsPageReference GetPageReference()
        {
            return new SettingsPageReferenceByType(typeof(ConfirmationsSettingsPage));
        }
    }

    public static class CheckboxExtension
    {
        public static CheckState ToCheckboxState(this bool booleanValue)
        {
            return booleanValue.ToCheckboxState();
        }

        public static CheckState ToCheckboxState(this bool? booleanValue)
        {
            if (!booleanValue.HasValue)
                return CheckState.Indeterminate;
            return booleanValue == true ? CheckState.Checked : CheckState.Unchecked;
        }

        public static bool? ToBoolean(this CheckState state)
        {
            if (state == CheckState.Indeterminate)
                return null;
            return state == CheckState.Checked;
        }
    }
}
