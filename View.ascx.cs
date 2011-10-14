/*
' Copyright (c) 2011  Christoc.com 
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
using System.Web;
using DotNetNuke.Framework;
using DotNetNuke.Services.Exceptions;


namespace Christoc.Modules.AddThis
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The ViewAddThis class displays the content
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : AddThisModuleBase
    {

        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            Load += Page_Load;
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Settings.Contains("Services"))
                {
                    BuildLinks();
                }
                else
                {
                    //todo: display a message about configuring the settings
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        private void BuildLinks()
        {
            //https://www.addthis.com/help/sharing-api#.Tpd1rN5T_FR

            //format
            //http://api.addthis.com/oexchange/0.8/forward/facebook/offer?url=http://addthis.com

            //list of services
            //http://www.addthis.com/services/list#.Tpd7096sc04

            var listOfServices = Settings["Services"].ToString().ToLower().Split(',');
            foreach(var service in listOfServices)
            {

                //get the page title and url
                var tp = (CDefault)Page;
                var pageTitle = HttpUtility.HtmlEncode(tp.Title.Trim());
                var pageUrl = "http://" + PortalAlias.HTTPAlias +Request.RawUrl;

                //we need a new hyperlink to add to the page
                var l = new System.Web.UI.WebControls.HyperLink
                            {
                                NavigateUrl =
                                    String.Format(
                                        "http://api.addthis.com/oexchange/0.8/forward/{0}/offer?url={1}&title={2}",
                                        service, HttpUtility.UrlEncode(pageUrl), pageTitle)
                            };
                
                //substitute in the service we are sharing to, the URL of the page, our publisher ID if included in the settings

                if(Settings.Contains("Pubid"))
                {
                    l.NavigateUrl += String.Format("&pubid={0}", Settings["Pubid"]);
                }

                if (Settings.Contains("BitlyLogin") && Settings.Contains("BitlyApi"))
                {
                    l.NavigateUrl += String.Format("&shortener=bitly&bitly.login={0}&bitly.apiKey={1}", Settings["BitlyLogin"], Settings["BitlyApi"]);
                }

                if(Settings.Contains("TwitterAccount") && service=="twitter")
                {
                    l.NavigateUrl += String.Format("&via={0}", Settings["TwitterAccount"]);
                }


                //add a nofollow to the link to prevent spiders from indexing the share link
                l.Attributes.Add("rel","nofollow");

                //add target=_blank to popup in a new window
                //TODO: make this happen in a DNN modal popup
                l.Target = "_blank";
                
                //setup the "text" value for the link, in the future this might be an image
                l.Text = service;
                
                //add the link to the placeholder
                phAddThis.Controls.Add(l);
            }
        }

    }

}
