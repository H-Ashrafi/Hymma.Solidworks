﻿using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Hymma.SolidTools.Addins
{
    /// <summary>
    /// a button in property manager page
    /// </summary>
    public class PmpButton : PmpButtonBase<IPropertyManagerPageButton>
    {

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="caption"> button text</param>
        /// <param name="tip">tooltip text</param>
        public PmpButton(string caption, string tip = "") : base(swPropertyManagerPageControlType_e.swControlType_Button, caption, tip)
        {
            OnRegister += PmpButton_OnRegister;
        }

        private void PmpButton_OnRegister()
        {
        }
    }
}
