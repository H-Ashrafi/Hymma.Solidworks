﻿using Hymma.SolidTools.SolidAddins;
using SolidWorks.Interop.sldworks;
using System.Collections.Generic;

namespace SampleAddin
{
    public class PropertyManagerPageUI : PmpUiModel
    {
        public PropertyManagerPageUI(ISldWorks Solidworks)
        {
            this.Solidworks = Solidworks;
            Title = "title of property manager page";
            PmpGroups.Add(new PmpGroup("group box caption") { Controls = GetControlSet1() });
            PmpGroups.Add(new PmpGroup("radio buttons", GetControlSet2()));
            OnHelp = () => { return false; };
        }

        public ISldWorks Solidworks { get; }
        private List<IPmpControl> GetControlSet1()
        {
            var controls = new List<IPmpControl>();

            controls.Add(new PmpCheckBox(true) { Tip = "a tip for a checkbox", Caption = "caption for chckbox" });

            controls.Add(new PmpCheckBox(Properties.Settings.Default.ChkBoxChkd)
            {
                Tip = "a tip for a checkbox 2 ",
                Caption = "caption for chckbox 2",
                OnChecked = (isChecked) =>
                {
                    Solidworks.SendMsgToUser($"you have clicked on check box  {isChecked}");
                    Properties.Settings.Default.ChkBoxChkd = isChecked;
                }
            });

            controls.Add(new PmpRadioButton(true)
            {
                Tip = "radio button on group 1",
                Caption = "caption for radio button on group 1",
                OnChecked = () => { Solidworks.SendMsgToUser("first radio button clicked on"); }

            });
            controls.Add(new PmpRadioButton(false)
            {
                Tip = "radio button on group 1",
                Caption = "caption for radio button on group 1",
                OnChecked = () => { Solidworks.SendMsgToUser("first radio button clicked on"); }
            });

            return controls;
        }

        private List<IPmpControl> GetControlSet2()
        {
            var controls = new List<IPmpControl>();
            controls.Add(new PmpRadioButton(true)
            {
                Tip = "a tip for this radio button",
                Caption = "caption for this radio button",
                OnChecked = () => { Solidworks.SendMsgToUser($"radio button is checked"); }
            });

            controls.Add(new PmpRadioButton()
            {
                Tip = "another tip for this radio button",
                Caption = "yet another caption for a radio button",
                OnChecked = () => { Solidworks.SendMsgToUser($"radio button is checked"); }
            });

            return controls;
        }
    }
}
