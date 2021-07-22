﻿using Hymma.Mathematics;
using Hymma.SolidTools.Core;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hymma.SolidTools.Addins
{
    /// <summary>
    /// Allows add-in applications to manipulate single and multi-row callouts
    /// </summary>
    public class CalloutModel
    {
        private int rowID;

        #region constructors
        /// <summary>
        /// private constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="solidworks"></param>
        private CalloutModel(List<CalloutRow> rows, ISldWorks solidworks)
        {
            //assign event handler that solidworks will use upon creation of callout
            this.Handler = new SolidworksCalloutHandler(this);
            this.Solidworks = (SldWorks)solidworks;
        }

        /// <summary>
        /// create a callout 
        /// </summary>
        /// <param name="rows">list of string in this callout. will be adde to the UI in the same order added to this list</param>
        /// <param name="solidworks">solidworks object</param>
        /// <param name="model">model to add selection </param>
        /// <param name="updateWithSelection">will make callout dependent on selection if set to true.</param>
        public CalloutModel(List<CalloutRow> rows, ISldWorks solidworks, ModelDoc2 model, bool updateWithSelection = true):this(rows,solidworks)
        {
            if (updateWithSelection)
            {
                var selectionMgr = model.SelectionManager as SelectionMgr;
                SwCallout = selectionMgr.CreateCallout2(Rows.Count, Handler);
            }
            else
            {
                var modelExtension = model.Extension;
                SwCallout=modelExtension.CreateCallout(Rows.Count, Handler);
            }
            rows.ForEach(row => AddRowToCallout(row));
            this.Rows = rows;
        }

        /// <summary>
        /// Creates a callout independent of a selection in a <see cref="ModelView"/>
        /// </summary>
        /// <param name="rows">list of string in this callout. will be adde to the UI in the same order added to this list</param>
        /// <param name="solidworks">solidworks object</param>
        /// <param name="modelView">model view to creat the callout in</param>
        public CalloutModel(List<CalloutRow> rows, ISldWorks solidworks, ModelView modelView) : this(rows,solidworks)
        {
            SwCallout = modelView.CreateCallout(Rows.Count, Handler);
            rows.ForEach(row => AddRowToCallout(row));
            this.Rows = rows;
        }
        #endregion

        /// <summary>
        /// Gets or sets whether to ignore the callout value in the given row.
        /// </summary>
        /// Use this API to remove the white space that remains in the callout when ICallout::Value is set to an empty string.<br/>
        ///This property applies only to a callout that is independent of a selection or created with IModelDocExtension::CreateCallout
        public void IgnoreRow(CalloutRow calloutRow)
        {
            _ = SwCallout.IgnoreValue[calloutRow.RowId];
        }

        /// <summary>
        /// get the row id for the value provided
        /// </summary>
        /// <param name="value"></param>
        public List<int> GetRowIds(string value)
        {
            return Rows.Where(r => r.Value == value).Select(r => r.RowId).ToList();
        }

        #region properties

        /// <summary>
        /// each row in a callout has an id and a text value
        /// </summary>
        /// <value>list of rows in a callout </value>
        public List<CalloutRow> Rows { get; }

        /// <summary>
        /// adds a new row to this callout
        /// </summary>
        /// <param name="calloutRow"></param>
        public void AddRowToCallout(CalloutRow calloutRow)
        {
            //increase row id registration
            rowID++;

            //update proeprty of the row
            calloutRow.RowId = rowID;

            //set callout object of the row 
            calloutRow.Callout = SwCallout;

            //map to solidworks
            SwCallout.AddRow(calloutRow);
        }

        /// <summary>
        /// actual solidworks <see cref="ICallout"/> object assigned to by addin
        /// </summary>
        public Callout SwCallout { get; internal set; }

        /// <summary>
        /// solidworks event handler for a callout
        /// </summary>
        public SolidworksCalloutHandler Handler { get; }

        /// <summary>
        /// solidowrks object
        /// </summary>
        public SldWorks Solidworks { get; }

        /// <summary>
        /// Gets or sets the font size for this callout.
        /// </summary>
        public int FontSize { get => SwCallout.FontSize; set => SwCallout.FontSize = value; }

        /// <summary>
        /// Gets or sets the text format for this callout.
        /// </summary>
        public TextFormat TextFormat { get => SwCallout.TextFormat; set => SwCallout.TextFormat = value; }

        /// <summary>
        /// Gets or sets whether to enable the pushpin for this callout. 
        /// </summary>
        public bool EnablePushPin { get => SwCallout.EnablePushPin; set => SwCallout.EnablePushPin = value; }

        /// <summary>
        /// Gets or sets whether the callout text is enclosed within a box
        /// </summary>
        public bool HasTextBox { get => SwCallout.TextBox; set => SwCallout.TextBox = value; }

        /// <summary>
        /// Gets or sets the type of connection at the target point for this callout.
        /// </summary>
        public swCalloutTargetStyle_e TargetStyle { get => (swCalloutTargetStyle_e)SwCallout.TargetStyle; set => SwCallout.TargetStyle = (int)value; }

        /// <summary>
        /// Gets and sets whether to add a colon at the end of the callout label.
        /// </summary>
        public bool SkipColon { get => SwCallout.SkipColon; set => SwCallout.SkipColon = value; }

        /// <summary>
        /// Gets and sets the position of this callout.
        /// </summary>
        public Point Position
        {
            get => new Point((double[])SwCallout.Position.ArrayData);
            set => SwCallout.SetPosition(Solidworks, value);
        }

        /// <summary>
        /// Gets or sets the opaque (background) color for the labels for this callout.
        /// </summary>
        /// <remarks>You must use a <see cref="SysColor"/>; you cannot use any other RGB values. To see system colors, click <strong>Tools > Options > Colors.</strong>  in the SOLIDWORKS user interface</remarks>
        public int OpaqueColor { get => SwCallout.OpaqueColor; set => SwCallout.OpaqueColor = value; }

        /// <summary>
        /// Gets or sets the display of multiple leaders for this callout.  
        /// </summary>
        public bool MultipleLeaders { get => SwCallout.MultipleLeaders; set => SwCallout.MultipleLeaders = value; }

        /// <summary>
        /// Sets the leader properties of the callout. 
        /// </summary>
        /// <param name="visible">True to display the leader, false to not</param>
        /// <param name="multiple">True to display multiple leaders, false to not</param>
        /// <returns>True if the operation is successful, false if not</returns>
        /// <remarks>You can only use this method before the callout is shown or while the callout is hidden.<br/>
        ///If Visible is set to false, then ICallout::TargetStyle is automatically set to swCalloutTargetStyle_None.</remarks>
        public bool LeaderStatus(bool visible, bool multiple)
        {
            return SwCallout.SetLeader(visible, multiple);
        }


        /// <summary>
        /// int is the rowId and string is the value of that row
        /// </summary>
        /// <value>True to use updated text in RowID, false to use original text in RowID</value>
        public Func<int, string, bool> OnValueChanged { get; set; }
        #endregion
    }
    
}