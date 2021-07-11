﻿using Hymma.SolidTools.Addins;
using System.Drawing;

namespace Hymma.SolidTools.Fluent.Addins
{
    /// <summary>
    /// adds a command group to solidworks ui
    /// </summary>
    public class FluentCommandGroup : AddinCommandGroup, IFluentCommandGroup
    {
        private AddinCommandTab Tab { get; }

        /// <summary>
        /// default constructor
        /// </summary>
        public FluentCommandGroup(AddinCommandTab tab)
        {
            this.Tab = tab as FluentCommandTab;
        }

        /// <inheritdoc/>
        public IFluentCommandTab SaveCommnadGroup()
        {
            Tab.CommandGroup = this;
            return Tab.CastTo<IFluentCommandTab>();
        }

        ///<inheritdoc/>
        public AddinCommands Has()
        {
            return new AddinCommands(this);
        }

        ///<inheritdoc/>
        public IFluentCommandGroup And()
        {
            return this;
        }

        ///<inheritdoc/>
        public IFluentCommandGroup WithDescription(string description)
        {
            Description = description;
            return this;

        }

        ///<inheritdoc/>
        public IFluentCommandGroup WithHint(string hint)
        {
            Hint = hint;
            return this;

        }

        ///<inheritdoc/>
        public IFluentCommandGroup WithIcon(Bitmap bitmap)
        {
            MainIconBitmap = bitmap;
            return this;
        }

        ///<inheritdoc/>
        public IFluentCommandGroup WithToolTip(string toolTip)
        {
            ToolTip = toolTip;
            return this;
        }

        ///<inheritdoc/>
        public IFluentCommandGroup WithTitle(string title)
        {
            Title = title;
            return this;
        }
    }
}
