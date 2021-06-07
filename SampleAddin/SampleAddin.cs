﻿using Hymma.SolidTools.SolidAddins;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swpublished;
using System;
using System.Runtime.InteropServices;
using static Hymma.SolidTools.SolidAddins.Logger;
namespace SampleAddin
{
    [ComVisible(true)]
    [Guid("EC861A04-6441-4BD0-A658-E89A0B2A3CDF")]
    [Addin(Title = "Sample_Addin", Description = "Sample Addin Description", LoadAtStartup = true, AddinIcon = "Save_05")]
    public class SampleAddin : AddinMaker, ISwAddin
    {
        public SampleAddin() : base(typeof(SampleAddin))
        {
        }
        private PropertyManagerBuilderX64 _pmp;

        #region Com Registration
        public override bool ConnectToSW(object ThisSW, int Cookie)
        {
            Log($"connecting to solidworks from-> {nameof(ConnectToSW)}");
            return base.ConnectToSW(ThisSW, Cookie);
        }

        public override bool DisconnectFromSW()
        {
            Log("disconnectring from solidworks from {DisconnecFromSW} in Sample Addin");
            return base.DisconnectFromSW();
        }

        [ComRegisterFunctionAttribute]
        public static void RegisterFunction(Type t)
        {
            Log("registering the addin calling from SampleAdidn");
            BaseRegisterFunction(t);
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterFunction(Type t)
        {
            Log("unregistering the addin calling from SampleAddin");
            BaseUnregisterFunction(t);
        }
        #endregion

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override AddinModel GetAddinModel()
        {
            var addin = new AddinModel();
            
            #region commands

            #region command 1
            AddinCommand command1 = new AddinCommand
            {
                CallBackFunction = nameof(ShowMessage),
                EnableMethode = nameof(EnableMethode),
                IconBitmap = Properties.Resources.xtractBlue,
                Name = "command1 Name",
                ToolTip = "command1 tooltip",
                CommandTabTextType = (int)swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow,
                UserId = 0,
                BoxId = 1,
                HintString = "hint for this command"
            };
            #endregion

            #region command2
            AddinCommand command2 = new AddinCommand
            {
                CallBackFunction = nameof(ShowMessage2),
                EnableMethode = nameof(EnableMethode),
                IconBitmap = Properties.Resources.xtractOrange,
                Name = "command2 Name",
                ToolTip = "command 2 's tooltip",
                CommandTabTextType = (int)swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow,
                UserId = 1,
                BoxId = 0,
                HintString = "hint for this command"
            };

            #endregion

            #region command3
            AddinCommand command3 = new AddinCommand();
            command3.CallBackFunction = nameof(ShowPMP);
            command3.EnableMethode = nameof(EnableMethode);
            command3.IconBitmap = Properties.Resources.xtractred;
            command3.Name = "command 3 's Name";
            command3.ToolTip = "command 3 's tooltip";
            command3.CommandTabTextType = (int)swCommandTabButtonTextDisplay_e.swCommandTabButton_TextBelow;
            command3.UserId = 2;
            command3.BoxId = 1;
            command3.HintString = "hint for this command";
            #endregion
            #endregion

            #region command Group
            var cmdGroup = new AddinCommandGroup(7, new[] { command1, command2, command3 },
                "A title for command group",
                "description for command group",
                "tooltip for thic command group",
                "hint of this command gorup",
                Properties.Resources.xtractred);
            #endregion

            #region Command Tabs
            AddinCommandTab tab1 = new AddinCommandTab()
            {
                TabTitle = "tab title",
                Types = new swDocumentTypes_e[] { swDocumentTypes_e.swDocASSEMBLY, swDocumentTypes_e.swDocDRAWING, swDocumentTypes_e.swDocPART },
                CommandGroup = cmdGroup
            };
            addin.CommandTabs = new AddinCommandTab[] { tab1 };
            #endregion

            #region property manager page
            _pmp = new PropertyManagerBuilderX64(this, new PropertyManagerPageUI(Solidworks));
            addin.PropertyManagerPages = new PropertyManagerBuilderX64[] { _pmp };
            #endregion

            return addin;
        }

        public void ShowPMP()
        {
            _pmp.Show();
        }

        public int EnableMethode()
        {
            if (Solidworks.ActiveDoc != null)
                return 1;
            return 0;
        }

        public void ShowMessage()
        {
            Solidworks.SendMsgToUser2("message from SampleAddin", 0, 0);
        }
        public void ShowMessage2()
        {
            Solidworks.SendMsgToUser2("message 2 from SampleAddin", 0, 0);
        }

    }
}