/*
' Copyright (c) 2011 Christoc.com 
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;


namespace Christoc.Modules.AddThis
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : AddThisSettingsBase
    {

        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //populate the icon listing

                    ddlStyleSelection.Items.Add(new ListItem(Localization.GetString("NoIconSet.Text", LocalResourceFile), "0"));
                    ddlStyleSelection.Items.Add(new ListItem(Localization.GetString("IconSet1.Text", LocalResourceFile), "1"));
                    ddlStyleSelection.Items.Add(new ListItem(Localization.GetString("IconSet2.Text", LocalResourceFile), "2"));
                    ddlStyleSelection.Items.Add(new ListItem(Localization.GetString("IconSet3.Text", LocalResourceFile), "3"));
                    
                    //TODO: allow for choosing of an ICON set
                    
                    if(Settings.Contains("Services"))
                    {
                        txtServices.Text = Settings["Services"].ToString();
                    }

                    if (Settings.Contains("Pubid"))
                    {
                        txtPubid.Text = Settings["Pubid"].ToString();
                    }

                    if (Settings.Contains("BitlyLogin"))
                    {
                        txtBitlyLogin.Text = Settings["BitlyLogin"].ToString();
                    }

                    if (Settings.Contains("BitlyApi"))
                    {
                        txtBitlyApi.Text = Settings["BitlyApi"].ToString();
                    }

                    if (Settings.Contains("TwitterAccount"))
                    {
                        txtTwitterAccount.Text = Settings["TwitterAccount"].ToString();
                    }

                    if (Settings.Contains("IconSet"))
                    {
                        ddlStyleSelection.Items.FindByValue(Settings["IconSet"].ToString()).Selected = true;
                    }

                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                ModuleController modules = new ModuleController();
                modules.UpdateModuleSetting(ModuleId, "Services", txtServices.Text.Trim());
                modules.UpdateModuleSetting(ModuleId, "Pubid", txtPubid.Text.Trim());
                modules.UpdateModuleSetting(ModuleId, "BitlyApi", txtBitlyApi.Text.Trim());
                modules.UpdateModuleSetting(ModuleId, "BitlyLogin", txtBitlyLogin.Text.Trim());
                modules.UpdateModuleSetting(ModuleId, "TwitterAccount", txtTwitterAccount.Text.Trim());
                modules.UpdateModuleSetting(ModuleId, "IconSet", ddlStyleSelection.SelectedValue);
                
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

    }

}

