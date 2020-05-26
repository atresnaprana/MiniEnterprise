<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RptTest.aspx.cs" Inherits="OlshoptrackedBAK.Reports.RptTest" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <telerik:RadButton runat="server" ID="test" onclick="test_Click" Text="download" AutoPostBack="true"></telerik:RadButton>
            <telerik:RadButton runat="server" ID="preview" Text="Preview" AutoPostBack="true"></telerik:RadButton>

        <telerik:RadComboBox ID="RadCmbListCust" EnableCheckAllItemsCheckBox="true" Width="300px" CheckBoxes="true" AllowCustomText="true" AutoPostBack="False" runat="server" EmptyMessage="Select.." DataTextField="TRANS_CODE" DataValueField="CUST_CODE">
        </telerik:RadComboBox>
        <br />
        <telerik:RadLabel ID="TempPath" runat="server"></telerik:RadLabel>
        <br />
     <telerik:ReportViewer ID="ReportViewer1"
                Width="100%"
                Height="650px" runat="server" ShowExportGroup="false" ShowPrintButton="false">
             
     </telerik:ReportViewer>
            <asp:Label runat="server" ID="Label1"></asp:Label>
    <telerik:RadScriptBlock ID="radSript1" runat="server">
        <script>
            var viewer1 = <%= ReportViewer1.ClientID %>;
                        var btn = <%= test.ClientID %>;

            viewer1.OnPrintReportLoadedOriginal = viewer1.OnPrintReportLoaded;
            viewer1.OnExport = function(){
                UpdateStatusLabel("Preparing the report to export....");

            }
            viewer1.OnPrint = function()
            {    

                UpdateStatusLabel("Preparing the report to print....");
                this.PrintReport();
               // __doPostBack('','');

            };
             
            viewer1.OnPrintReportLoaded = function()
            {
                viewer1.OnPrintReportLoadedOriginal();
                UpdateStatusLabel("");
            }  
            function click(){

            }
            function UpdateStatusLabel(msg)
            {
                var label = document.getElementById('<%=Label1.ClientID %>');
                label.innerHTML = msg;
            }                  
            </script>
        </telerik:RadScriptBlock>
</asp:Content>
