﻿using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD365VSAddIn.Settings
{
    [Export(typeof(IMainMenu))]
    class ModelSettingsMainMenuAddIn : MainMenuBase
    {
        #region Member variables
        private const string addinName = "SSD365VSAddIn";
        #endregion

        #region Properties
        /// <summary>
        /// Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption
        {
            get
            {
                return AddinResources.ModelSettings;
            }
        }

        /// <summary>
        /// Unique name of the add-in
        /// </summary>
        public override string Name
        {
            get
            {
                return ModelSettingsMainMenuAddIn.addinName;
            }
        }

        #endregion

        #region Callbacks
        /// <summary>
        /// Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        public override void OnClick(AddinEventArgs e)
        {
            try
            {
                // Read the model Settings
                var modelSettings = FetchSettings.FindOrCreateSettings();

                // Send the model settings to the UI
                ModelSettingsUI modelSettingsUI = new ModelSettingsUI();
                var dialogResult = modelSettingsUI.ShowDialog();
                if(dialogResult == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }
        #endregion
    }
}
