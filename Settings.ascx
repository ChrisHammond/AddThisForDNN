<%@ Control Language="C#" AutoEventWireup="false" Inherits="Christoc.Modules.AddThis.Settings" Codebehind="Settings.ascx.cs" %>
<%@ Register TagPrefix="dnn" TagName="label" Src="~/controls/LabelControl.ascx" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<div class="dnnForm dnnAddThisSettings dnnClear" id="dnnAddThisSettings">
	<div class="dnnFormExpandContent"><a href=""><%=Localization.GetString("ExpandAll", Localization.SharedResourceFile)%></a></div>
	<h2 id="dnnSitePanel-ServiceSelection" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("ServiceSelection")%></a></h2>
	<fieldset>
		<div class="dnnFormItem">
			<dnn:label id="lblServices" runat="server" controlname="txtServices" suffix=":" />
			<asp:TextBox ID="txtServices" runat="server" TextMode="MultiLine" />
		</div>	
        <div class="dnnFormItem">
			<dnn:label id="lblPubid" runat="server" controlname="txtPubid" suffix=":" />
			<asp:TextBox ID="txtPubid" runat="server" TextMode="SingleLine" />
		</div>
        <div class="dnnFormItem">
			<dnn:label id="lblTwitterAccount" runat="server" controlname="txtTwitterAccount" suffix=":" />
			<asp:TextBox ID="txtTwitterAccount" runat="server" TextMode="SingleLine" />
		</div>	
        <div class="dnnFormItem">
			<dnn:label id="lblStyleSelection" runat="server" controlname="ddlStyleSelection" suffix=":" />
			<asp:DropDownList ID="ddlStyleSelection" runat="server" />
		</div>

	</fieldset>
    <h2 id="dnnSitePanel-UrlShortener" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded"><%=LocalizeString("UrlShortener")%></a></h2>
	<fieldset>
		<div class="dnnFormItem">
			<dnn:label id="lblBitlyLogin" runat="server" controlname="txtBitlyLogin" suffix=":" />
			<asp:TextBox ID="txtBitlyLogin" runat="server" TextMode="SingleLine" />
		</div>	

        <div class="dnnFormItem">
			<dnn:label id="lblBitlyApi" runat="server" controlname="txtBitlyApi" suffix=":" />
			<asp:TextBox ID="txtBitlyApi" runat="server" TextMode="SingleLine" />
		</div>	

	</fieldset>
</div>