﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static Hymma.SolidTools.Addins.Logger;

namespace Hymma.SolidTools.Addins
{
    ///<inheritdoc/>
    public abstract class AddinCommandGroupBase : IAddinCommandGroup
    {
        #region protected vars
        /// <summary>
        /// command icons
        /// </summary>
        protected string[] _commandIcons;

        /// <summary>
        /// group icons
        /// </summary>
        protected string[] _groupIcons;
        #endregion

        #region public properties

        /// <inheritdoc/>
        public IEnumerable<AddinCommand> Commands { get; set; }

        ///<inheritdoc/>
        public bool IgnorePrevious { get; set; }
        ///<inheritdoc/>
        public bool IsRegistered { get; set; }
        ///<inheritdoc/>
        public int UserId { get; set; }
        ///<inheritdoc/>
        public string Title { get; set; } = "Title of this AddinCommandGroup";
        ///<inheritdoc/>
        public string Description { get; set; } = "Description of this AddinCommandGroup";
        ///<inheritdoc/>
        public string ToolTip { get; set; } = "Tooltip of this AddinCommandGroup";
        ///<inheritdoc/>
        public string Hint { get; set; } = "Hint of this AddinCommandGroup";
        ///<inheritdoc/>
        public int Position { get; set; } = 0;
        ///<inheritdoc/>
        public bool HasToolbar { get; set; } = true;
        ///<inheritdoc/>
        public bool HasMenue { get; set; } = true;
        ///<inheritdoc/>
        public Bitmap MainIconBitmap { get; set; }

        /// <summary>
        /// returns list of command strips for this command group
        /// </summary>
        public string[] CommandIcons
        {
            get
            {
                Log("getting command icons");
                if (_commandIcons == null)
                {
                    Log("creating new command icons");
                    //get icons
                    var iconBitmaps = Commands.Select(cmd => cmd.IconBitmap).ToArray();

                    Log("list of bitmaps was generated from command list");

                    Log("new instance of IconGenerator was made");
                    //convert all these icons into strips of standard sizes
                    _commandIcons = IconGenerator.GetCommandGroupIconStrips(iconBitmaps, "commandsIcons").ToArray();

                    Log("array of icons were made");
                }

                CheckIconsExist(_commandIcons);

                Log("command icons were generated before so we just returned them this time");
                return _commandIcons;
            }
            set { _commandIcons = value; }
        }


        /// <summary>
        /// returns a list of command group icon in standard solidworks sizes
        /// </summary>
        public string[] GroupIcon
        {
            get
            {
                Log("getting Group icons");
                if (_groupIcons == null)
                {
                    Log("Creating new group icons");
                    //Get main icon in all sizes
                    //NOTE: because main icon is actually one image we will end up just resizing it
                    _groupIcons = IconGenerator.GetCommandGroupIconStrips(new[] { MainIconBitmap }, "mainGroupIcon").ToArray();
                }

                CheckIconsExist(_groupIcons);
                return _groupIcons;
            }
            set { _groupIcons = value; }
        }


        #endregion

        private void CheckIconsExist(string[] fileList)
        {
            foreach (var file in fileList)
            {
                if (!File.Exists(file))
                {
                    Log($"file does not exist {file}");
                    throw new FileNotFoundException($"{file} not found");
                }
            }
        }
    }
}