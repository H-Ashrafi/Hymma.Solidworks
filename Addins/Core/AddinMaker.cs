﻿using Microsoft.Win32;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using static Hymma.SolidTools.Addins.Logger;
namespace Hymma.SolidTools.Addins
{
    /// <summary>
    /// registers an <see cref="AddinModel"/> into solidworks
    /// </summary>
    [ComVisible(true)]
    public abstract class AddinMaker
    {

        #region private fields & variables
        /// <summary>
        /// identifier for this addin assigned by SOLIDWORKS    
        /// </summary>
        protected int addinCookie;

        /// <summary>
        /// command manager for this addin assigned by SOLIDWORKS
        /// </summary>
        protected CommandManager _commandManager;

        /// <summary>
        /// a collection of documents and their associated events
        /// </summary>
        protected Hashtable documentsEventsRepo;

        /// <summary>
        /// list of propertye manager pages
        /// </summary>
        protected List<PmpBase> _pmps;

        /// <summary>
        /// list of tabs
        /// </summary>
        protected List<AddinCommandTab> _tabs;

        #endregion

        #region constructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="addin">type of class that inherits from <see cref="ISwAddin"/></param>
        public AddinMaker(Type addin)
        {
            if (typeof(ISwAddin).IsAssignableFrom(addin)
                && addin.TryGetAttribute<AddinAttribute>(false) is AddinAttribute addinAttr)
            {
                Logger.Source = addinAttr.Title;
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// a data model for thie addin
        /// </summary>
        private void GetAddinUI(AddinModel model)
        {
            _pmps = model.PropertyManagerPages.ToList();
            _tabs = model.CommandTabs.ToList();
        }

        /// <summary>
        /// solidowrks object
        /// </summary>
        public ISldWorks Solidworks { get; set; }
        #endregion

        #region com register/un-register
        /// <summary>
        /// registers <see cref="Type"/> provided to COM so solidworks can find it
        /// </summary>
        /// <param name="t">type of class that inherrits from  <see cref="AddinMaker"/></param>
        public static void BaseRegisterFunction(Type t)
        {
            var addinAttribute = t.TryGetAttribute<AddinAttribute>(false) as AddinAttribute;
            if (addinAttribute == null)
                //TODO: log this
                Console.WriteLine("couldnet get the proper attribute from the child class");
            try
            {
                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                RegistryKey addinkey = Registry.LocalMachine.CreateSubKey(keyname);
                addinkey.SetValue(null, 0);

                addinkey.SetValue("Description", addinAttribute.Description);
                addinkey.SetValue("Title", addinAttribute.Title);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                addinkey = Registry.CurrentUser.CreateSubKey(keyname);
                addinkey.SetValue(null, Convert.ToInt32(addinAttribute.LoadAtStartup), RegistryValueKind.DWord);

                //save addin icon in the current assembly folder
                var rm = new ResourceManager($"{t.Name}.Properties.Resources", t.Assembly);
                var addinIcon = rm.GetObject(addinAttribute.AddinIcon) as Bitmap;
                IconGenerator.GetAddinIcon(addinIcon, t.Name);
                RegisterLogger(addinAttribute.Title);
            }
            catch (System.NullReferenceException nl)
            {
                Log($"Error! There was a problem registering this dll: addinModel is null. \n\"" + nl.Message + "\"");
            }

            catch (System.Exception e)
            {
                Log(e);
            }
        }

        /// <summary>
        /// Un-registers <see cref="Type"/> from COM
        /// </summary>
        /// <param name="t">type of class that inherrits from  <see cref="AddinMaker"/></param>
        public static void BaseUnregisterFunction(Type t)
        {
            var swAttr = t.TryGetAttribute<AddinAttribute>(false) as AddinAttribute;
            if (swAttr == null)
                Log("not attrubute found for addin");
            try
            {
                Log("trying to unregister");
                string keyname = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
                Registry.LocalMachine.DeleteSubKey(keyname);

                keyname = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
                Registry.CurrentUser.DeleteSubKey(keyname);

                UnRegisterLogger(swAttr.Title);
            }
            catch (System.NullReferenceException nl)
            {
                Log(nl.Message);

                //TODO:log this
                Console.WriteLine("There was a problem unregistering this dll: " + nl.Message);
            }
            catch (System.Exception e)
            {
                //TODO:log this
                Log(e.Message);
                Console.WriteLine("There was a problem unregistering this dll: " + e.Message);
            }
        }
        #endregion

        /// <summary>
        /// construct the data model for this addin here
        /// </summary>
        /// <returns></returns>
        public abstract AddinModel GetAddinModel();

        #region solidworks integration
        //[EditorBrowsable(EditorBrowsableState.Never)]


        /// <summary>
        /// set <see cref="PmpBase"/> object to null here
        /// </summary>
        private void RemovePMP()
        {
            for (int i = 0; i < _pmps.Count(); i++)
            {
                _pmps[i] = null;
                Log($"PMP {i} set to null");
            }
        }

        private void DetachEventsFromAllDocuments()
        {
            throw new NotImplementedException();
        }

        private void DetachSwEvents()
        {
            throw new NotImplementedException();
        }

        private void RemoveCommandMgr()

        {
            foreach (var tab in _tabs)
            {
                _ = _commandManager.RemoveCommandGroup(tab.CommandGroup.UserId);
                Log($"removed command group with id {tab.CommandGroup.UserId}");
            }
        }
        #endregion

        #region UI
        /// <summary>
        /// Adds commands to the addin
        /// </summary>
        /// <returns></returns>
        public bool AddCommands()
        {
            try
            {
                foreach (var tab in _tabs)
                {
                    //make command groups
                    Log("Adding command group...");
                    tab.CommandGroup.AddCommandGroup(_commandManager);
                    Log("finished setting up commadn group");

                    //make command tabs
                    Log("Adding commadn tab...");
                    tab.AddCommandTab(_commandManager);
                    Log("finished adding command tab");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Events

        public bool AttachEventsToAllDocuments()
        {
            throw new NotImplementedException();
        }

        public bool AttachSwEvents()
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// SOLIDWORKS calls these command once addin is unloaded.
        /// </summary>
        /// <returns></returns>
        public virtual bool DisconnectFromSW()
        {
            RemoveCommandMgr();
            RemovePMP();
            //DetachSwEvents();
            //DetachEventsFromAllDocuments();

            Marshal.ReleaseComObject(_commandManager);
            _commandManager = null;

            Marshal.ReleaseComObject(Solidworks);
            Solidworks = null;

            //The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
            GC.Collect();
            GC.WaitForPendingFinalizers();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return true;
        }

        /// <summary>
        /// SOLIDWORKS calls this method and assigns its params once addin is loaded
        /// </summary>
        /// <param name="ThisSW"></param>
        /// <param name="Cookie"></param>
        /// <returns></returns>
        public virtual bool ConnectToSW(object ThisSW, int Cookie)
        {
            Log("connecting to solidworks from Addin maker base class");
            Solidworks = (ISldWorks)ThisSW;
            addinCookie = Cookie;

            Log($"addin cookie is  {addinCookie} ");
            //Setup callbacks
            Solidworks.SetAddinCallbackInfo2(0, this, addinCookie);


            Log("setting up Addin Model");
            GetAddinUI(GetAddinModel());

            #region Setup the Command Manager

            _commandManager = Solidworks.GetCommandManager(Cookie);


            Log("addin commands . . .");
            var result = AddCommands();
            Log($"finished addin commands successfull? {result}");
            return true;
            #endregion

            #region Setup the Event Handlers
            //addin = (SldWorks)Solidworks;
            //documentsEventsRepo = new Hashtable();

            //this will be called only the first time the addin is loaded
            //this method will attached events to all documents that open after the addin is loaded.

            //AttachSwEvents();

            //Listen for events on all currently open docs
            //we need to call this method here because sometimes user fires the addin while he has some documents open already
            //there are events that will attach event handlers to all documents but until those events are fired this call to the method will suffice
            //AttachEventsToAllDocuments();
            #endregion
        }
    }
}